using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class StateMachine
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();

        IState _currentState; //walk

        public void SetState(IState state) //walk
        {
            if (state == _currentState) return;

            _currentState?.OnExit();

            _currentState = state;

            _currentState.OnEnter();
        }

        public void Tick()
        {
            StateTransition stateTransition = CheckForTransition();

            if (stateTransition != null)
            {
                SetState(stateTransition.To);
            }

            _currentState.Tick();
        }

        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;
            }

            foreach (StateTransition stateTransition in _stateTransitions)
            {
                if (stateTransition.Condition() && stateTransition.From == _currentState)
                {
                    return stateTransition;
                }
            }

            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> contidion)
        {
            StateTransition stateTransition = new StateTransition(from, to, contidion);
            _stateTransitions.Add(stateTransition);
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null, to, condition);
            _anyStateTransitions.Add(anyStateTransition);
        }
    }


