using System.Collections.Generic;
using UnityEngine;

namespace FSM {

    public delegate void ChangeStateHandler();

    interface IState {
        event ChangeStateHandler OnStateEnter;
        event ChangeStateHandler OnStateExit; 
    }

    public class State : IState {
        /// <summary>
        /// List of all states;
        /// </summary>
        static List<State> listStates = new List<State>();

        private bool _isActive = false;
        private int _id = -1;
        private string _name = "Zero_state";

        //some value associated with the current state
        //this variable can be expanded
        public int someValue = -1;

        public event ChangeStateHandler OnStateEnter;
        public event ChangeStateHandler OnStateExit;

        /// <summary>
        /// Initialize give state Id and add to listStates;
        /// </summary>
        public State() {
            _id = listStates.Count; //simple getter ID
            listStates.Add(this);
            _name = "new state #" + (listStates.Count - 1).ToString();
        }

        public State(string name, int someValue) : this(){
            Name = name;
            this.someValue = someValue;
        }
         
        /// <summary>
        /// Check on valid name and get name state;
        /// </summary>
        public string Name {
            get { return _name; }
            set {
                if (string.IsNullOrEmpty(value.Trim())) {
                    return;
                }
                _name = value;
            }
        }

        /// <summary>
        /// Just for avoid questions that appear with the text;
        /// Eng/Rus? What register? etc.
        /// </summary>
        public int ID {
            get { return _id; } 
        }

        /// <summary>
        /// Set active curState and call UI event
        /// </summary>
        public bool IsActive {
            get { return _isActive; }
            set {
                if (!_isActive && value) {
                    if (OnStateEnter != null) OnStateEnter();
                }
                if(_isActive && !value) {
                    if (OnStateExit != null) OnStateExit(); 
                }
                _isActive = value;
            }
        }

        public void Destroy() {
            if (listStates.Contains(this)) {
                listStates.Remove(this);
            }
        } 

        #region Public static methods
        /// <summary>
        /// Find stets in lisrStates by ID
        /// </summary>
        /// <param name="id">ID state</param>
        /// <returns></returns>
        static public State GetStateByID(int id) {
            foreach (State state in listStates) {
                if (state._id == id) {
                    return state;
                }
            }
            return null;
        }

        /// <summary>
        /// Find stets in lisrStates by Name
        /// </summary>
        /// <param name="id">_name state</param>
        /// <returns></returns>
        static public State GetStateByName(string name) {
            if (string.IsNullOrEmpty(name.Trim())) {
                return null;
            } 
            foreach (State state in listStates) {
                if (state._name == name) {
                    return state;
                }
            }
            return null;
        }

        static public bool operator ==(State stateOne, State stateTwo) {
            if (Equals(stateOne, null) && Equals(stateTwo, null)) return true;
            if (Equals(stateOne, null) || Equals(stateTwo, null) &&
                !Equals(stateOne, stateTwo)) return false;
            return stateOne.ID == stateTwo.ID;
        }

        static public bool operator !=(State stateOne, State stateTwo) {
            return !(stateOne == stateTwo);
        }
        #endregion 
    } 
}


