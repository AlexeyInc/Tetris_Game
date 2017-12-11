using System.Collections.Generic;
using UnityEngine;

namespace FSM { 
    interface IStateMachine {
        bool AddState(State state);
        bool AddStates(State states);
        bool RemoveState(State oldState, State sewState, bool releaseStatic = false);
    }

    public class StateMachine {
        List<State> listAvailableStates = new List<State>();

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

        public State ActiveState {
            get {
                if (_isFrmSctive && (_curActiveState != null)) {
                    return _curActiveState;
                } else {
                    return null;
                }
            }
        }

        public bool AddState(State newState) {
            if (newState == null) return false;
            for (int i = 0; i < listAvailableStates.Count; i++) {
                if (listAvailableStates[i] == newState) return false;
            }
            listAvailableStates.Add(newState);

            return true;
        }

        public bool AddStates(params State[] aStates) {
            if (aStates.Length == 0) return false;
            foreach (State item in aStates) {
                if (!AddState(item)) {
                    return false;
                }
            }
            return true;
        }

        public bool RemoveState(State oldState, State setState, bool releaseStatic = false) {
            if (oldState != null) return false;
            if ((setState != null) && (oldState == setState)) return false;

            if (listAvailableStates.Contains(oldState)) {
                listAvailableStates.Remove(oldState);

                if (_curActiveState == oldState) {
                    oldState.IsActive = false;
                    if (setState == null) return false;
                    setState.IsActive = true;
                }
                if (releaseStatic) {

                }
            }
            return false;
        }

        public void SwitchState(State newState) {
            if (newState == null) return;
            
            if (this[newState.Name] == null) {
                AddState(newState);
            } 

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

        //public List<string> GetAvailableStates_Names or ID

        public State this[string name] {
            get {
                if (string.IsNullOrEmpty(name.Trim())) return null;
                for (int n = 0; n < listAvailableStates.Count; n++) {
                    if (listAvailableStates[n].Name == name) return listAvailableStates[n];
                }
                return null;
            }
        }
    }
}


