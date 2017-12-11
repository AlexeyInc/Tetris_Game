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

        public State CurActiveState {
            get {
                if (_isFrmSctive && (_curActiveState != null)) {
                    return _curActiveState;
                } else {
                    return null;
                }
            }
        } 

        public void SwitchState(State newState) {
            if (newState == null) return; 

            if (_curActiveState != null) _curActiveState.IsActive = false;
            _curActiveState = newState;
            if (_isFrmSctive) _curActiveState.IsActive = true;
        }

        public void SwitchState(int stateID = -1) {
            if (stateID < 0) return;
            State state = State.GetStateByID(stateID);
            if (state == null) return;
            SwitchState(state);
        }

        public void SwitchState(string stateName = "") {
            if (string.IsNullOrEmpty(stateName)) return;
            State state = State.GetStateByName(stateName);  
            if (state == null) return;
            SwitchState(state);
        } 
    }
}


