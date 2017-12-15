using System.Collections.Generic;
using UnityEngine;

namespace FSM {  

    public class StateMachine { 
        State _curActiveState;

        bool _isFrmSctive = false;

        public bool IsFsmActive {
            get { return _isFrmSctive; }
            set {
                _isFrmSctive = value;
                if (_curActiveState != null) _curActiveState.IsActive = value;
            }
        }

        public StateMachine() {
            _curActiveState = null;
        }

        /// <summary>
        /// Returns current active state
        /// </summary>
        public State CurActiveState {
            get {
                if (_isFrmSctive && (_curActiveState != null)) {
                    return _curActiveState;
                } else {
                    return null;
                }
            }
        }
        /// <summary>
        /// Switch new current state
        /// property IsActive triggers an event
        /// </summary>
        /// <param name="newState"></param>
        public void SwitchState(State newState) {
            if (newState == null) return; 

            if (_curActiveState != null) _curActiveState.IsActive = false;
            _curActiveState = newState;
            if (_isFrmSctive) _curActiveState.IsActive = true;
        }

        /// <summary>
        /// Find state by ID and activate it
        /// </summary>
        /// <param name="stateID"></param>
        public void SwitchState(int key = -1) {
            if (key < 0) return;
            State state = State.GetStateByKey(key);
            if (state == null) return;
            SwitchState(state);
        }

        /// <summary>
        ///  Find state by Name and activate it
        /// </summary>
        /// <param name="stateName"></param>
        public void SwitchState(string stateName = "") {
            if (string.IsNullOrEmpty(stateName)) return;
            State state = State.GetStateByName(stateName);  
            if (state == null) return;
            SwitchState(state);
        } 
    }
}


