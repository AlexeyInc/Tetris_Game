using System.Collections.Generic;
using UnityEngine;

//namespace FSM {  

//    public class StateMachine {

//        static List<State> listStates = new List<State>();

//        State _curActiveState;

//        bool _isFsmActive = false;

//        /// <summary>
//        /// Activate state machine
//        /// Is current state is set - activate it
//        /// </summary>
//        public bool IsFsmActive {
//            get { return _isFsmActive; }
//            set {
//                _isFsmActive = value;
//                if (_curActiveState != null) _curActiveState.IsActive = value;
//            }
//        }

//        public StateMachine() {
//            _curActiveState = null;
//        }

//        /// <summary>
//        /// Returns current active state
//        /// </summary>
//        public State CurActiveState {
//            get {
//                if (_isFsmActive && (_curActiveState != null)) {
//                    return _curActiveState;
//                } else {
//                    return null;
//                }
//            }
//        }
//        /// <summary>
//        /// Switch new current state
//        /// property IsActive triggers an event
//        /// </summary>
//        /// <param name="newState"></param>
//        public void SwitchState(State newState) {
//            if (newState == null) return;
            
//            if (_curActiveState != null) _curActiveState.IsActive = false;
//            _curActiveState = newState;
//            if (_isFsmActive) _curActiveState.IsActive = true;
//        }

//        /// <summary>
//        /// Find state by Key and activate it
//        /// </summary>
//        /// <param name="stateKey"></param>
//        public void SwitchState(int key = -1) {
//            if (key < 0) return;
//            State state = GetStateByKey(key);
//            if (state == null) return;
//            SwitchState(state);
//        }

//        /// <summary>
//        ///  Find state by Name and activate it
//        /// </summary>
//        /// <param name="stateName"></param>
//        public void SwitchState(string stateName = "") {
//            if (string.IsNullOrEmpty(stateName)) return;
//            State state = GetStateByName(stateName);  
//            if (state == null) return;
//            SwitchState(state);
//        }
         
//        /// <summary>
//        /// Find stets in lisrStates by ID
//        /// </summary>
//        /// <param name="id">ID state</param>
//        /// <returns></returns>
//        private State GetStateByKey(int key) {
//            foreach (State state in listStates) {
//                if (state.Key == key) {
//                    return state;
//                }
//            }
//            return null;
//        }

//        /// <summary>
//        /// Find stets in lisrStates by Name
//        /// </summary>
//        /// <param name="id">_name state</param>
//        /// <returns></returns>
//        private State GetStateByName(string name) {
//            if (string.IsNullOrEmpty(name.Trim())) {
//                return null;
//            }
//            foreach (State state in listStates) {
//                if (state.Name == name) {
//                    return state;
//                }
//            }
//            return null;
//        } 

//        /// <summary>
//        /// Add new state to the list States
//        /// </summary>
//        /// <param name="state">new State object</param>
//        /// <returns></returns>
//        public bool AddState(State state) {
//            if (state == null) return false;

//            for (int i = 0; i < listStates.Count; i++) {
//                if(listStates[i] == state) {
//                    return false;
//                }
//            }
//            listStates.Add(state);
//            return true;
//        }

//        public void AddStates(params State[] states) {
//            if (states.Length == 0) return;

//            foreach (State item in states) {
//                if (AddState(item)) {
//                    AddState(item);
//                } 
//            } 
//        }
         
//    }
//}


