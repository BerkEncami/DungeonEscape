using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Idle : IState
    {
        IMover _mover;
        IAnimation _animation;

        float _maxStandTime;
        float _currentStandTime = 0f;

        public bool IsIdle { get; private set; }

        public Idle(IMover mover,IAnimation animation)
        {
            _mover = mover;
            _animation = animation;
        }

        public void OnEnter()
        {
            IsIdle = true;
            _animation.MoveAnimation(0f);

            _maxStandTime = Random.Range(4f, 10f);
        }

        public void OnExit()
        {
            _currentStandTime = 0f;
        }

        public void Tick()
        {
            _mover.Tick(0f);

            _currentStandTime += Time.deltaTime;

            if (_currentStandTime > _maxStandTime)
            {
                IsIdle = false;
            }

            Debug.Log("Idle Tick");
        }
    }


