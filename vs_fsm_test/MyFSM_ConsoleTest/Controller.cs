using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFSM;

namespace MyFSM_ConsoleTest {
    class Controller {

        public delegate void UIStateControllerHandler(int indx, bool active);

        public event UIStateControllerHandler ChangeUIState;

        StateMachine _stateMachine = null;

        public static Controller Instance {
            get {
                return Nested.instance;
            }
        }
        private class Nested {
            internal static readonly Controller instance = new Controller();
        }

        public Controller() {
            _stateMachine = new StateMachine();

            InitUI();
        }

        private void InitUI() {

            State[] arrStates = new State[7] { new State ("mainmenu", 0),
                                           new State ("game", 1),
                                           new State ("help", 2),
                                           new State ("gamerules", 3),
                                           new State ("about", 4),
                                           new State ("newgame", 5),
                                           new State ("exit", 6)};

            foreach (State st in arrStates) {
                st.OnStateEnter += OnUIActionEnter;
                st.OnStateExit += OnUIActionExit;
            }
            _stateMachine.AddStates(arrStates);
        }

        public void ActiveFSM() {
            if (!_stateMachine.IsFsmActive) {
                _stateMachine.SwitchState("mainmenu");
                _stateMachine.IsFsmActive = true;
            }
        }

        /// <summary>
        /// checks if the state of the game changes
        /// if not, then passes control to stateMachine for change stateMenu
        /// </summary>
        /// <param name="newState">name of new State</param>
        public void ChangeScenario(string newState) {
            string state = newState.ToLower(); 

            _stateMachine.SwitchState(state);
        }

        private void OnUIActionEnter() {
            if (_stateMachine == null || _stateMachine.CurActiveState == null) return;

            int index = _stateMachine.CurActiveState.Key;
            if (ChangeUIState != null) ChangeUIState(index, true); 
        }

        private void OnUIActionExit() {
            if (_stateMachine == null || _stateMachine.CurActiveState == null) return;

            int index = _stateMachine.CurActiveState.Key;
            if (ChangeUIState != null) ChangeUIState(index, false);
        } 
    }
}
