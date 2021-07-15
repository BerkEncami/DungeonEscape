using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class EnemyController : MonoBehaviour, IEntityController
    {
        [Header("Movements")]
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] Transform[] patrols;

        [Header("Attacks")]
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] float maxAttackTime = 2f;

 

        StateMachine _stateMachine;
        IEntityController _player;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
        }

        private IEnumerator Start()
        {
       
            IMover mover = new Mover(this, moveSpeed);
            IAnimation animation = new PlayerAnimations(GetComponent<Animator>());
            IFlip flip = new Flip(this);
            IHealth health = GetComponent<IHealth>();
            IAttacker attacker = GetComponent<IAttacker>();
            IStopEdge stopEdge = GetComponent<IStopEdge>();

            Idle idle = new Idle(mover, animation);
            Walk walk = new Walk(this, mover, animation, flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(mover, flip, animation, stopEdge, IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(), flip, animation, attacker, maxAttackTime, IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(health, animation);
            Dead dead = new Dead(this, animation);
         ;

            _stateMachine.AddTransition(idle, walk, () => idle.IsIdle == false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);

            _stateMachine.AddAnyState(dead, () => health.IsDead);
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);

            _stateMachine.AddTransition(takeHit, chasePlayer, () => takeHit.IsTakeHit == false);

            _stateMachine.SetState(idle);

            yield return null;
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private float DistanceFromMeToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }

        private bool IsPlayerRightSide()
        {
            Vector3 result = _player.transform.position - this.transform.position;

            if (result.x > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


