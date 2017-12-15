using System;
using System.Collections.Generic; 

namespace MyFSM
{
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
        private string _name = "Zero_state";

        //some value associated with the current state
        //this variable can be expanded
        public int keyValue = -1;

        public event ChangeStateHandler OnStateEnter;
        public event ChangeStateHandler OnStateExit;

        /// <summary>
        /// Initialize give state Id and add to listStates;
        /// </summary>
        public State() { 
            listStates.Add(this);
            _name = "new state #" + (listStates.Count - 1).ToString();
        }

        public State(string name, int keyValue) : this() {
            this._name = name;
            this.keyValue = keyValue;
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
        public int KeyValue {
            get { return keyValue; }
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
                if (_isActive && !value) {
                    if (OnStateExit != null) OnStateExit();
                }
                _isActive = value;
            }
        } 

        #region Public static methods
        /// <summary>
        /// Find stets in lisrStates by ID
        /// </summary>
        /// <param name="id">ID state</param>
        /// <returns></returns>
        static public State GetStateByKey(int keyVal) {
            foreach (State state in listStates) {
                if (state.KeyValue == keyVal) {
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
                if (state.Name == name) {
                    return state;
                }
            }
            return null;
        } 
        #endregion 
    }
}
