using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TakeHit : IState
    {
        IAnimation _animation;

        float _maxDelayTime = 0.3f;
        float _currentDelayTime = 0f;

        public bool IsTakeHit { get; private set; }

        public TakeHit(IHealth health, IAnimation animation)
        {
            _animation = animation;
            health.OnHealthChanged += (currentHealth, maxHealth) => OnEnter();
        }

        public void OnEnter()
        {
            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime > _maxDelayTime && IsTakeHit)
            {
                _animation.TakeHitAnimation();
                IsTakeHit = false;
            }

            Debug.Log("Take Hit Tick");
        }
    }


