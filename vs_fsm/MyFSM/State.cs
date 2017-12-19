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

        private bool _isActive = false;
        private string _name = "Zero_state";
        private int keyValue = -1;

        public event ChangeStateHandler OnStateEnter;
        public event ChangeStateHandler OnStateExit;

        /// <summary>
        /// Initialize. Give state Name and Key 
        /// </summary>
        public State(string name, int keyVal) {
            Name = name;
            this.keyValue = keyVal;
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
        /// Numeric key use for avoid questions that appear with the text;
        /// Eng/Rus? What register? etc.
        /// </summary>
        public int Key {
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
    }
}
