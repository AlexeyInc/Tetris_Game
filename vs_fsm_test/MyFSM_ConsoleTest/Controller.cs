using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFSM;

namespace MyFSM_ConsoleTest {
    class Controller {
        static Controller _instance;

        StateMachine _stateMachine = null; 

        public static Controller Instance {
            get {
                if (_instance == null) {
                    return new Controller();
                }
                return _instance;
            }
        }

        public Controller() {
            _instance = this;
            _stateMachine = new StateMachine(); 

            InitUI();
        }

        private void InitUI() {

            State[] arrStates = new State[5] { new State ("MainMenu", 0),
                                           new State ("Game", 1),
                                           new State ("Help", 2),
                                           new State ("GameRules", 3),
                                           new State ("About", 4) };
            foreach (State st in arrStates) {
                st.OnStateEnter += OnUIActionEnter;
                st.OnStateExit += OnUIActionExit;
            } 

            _stateMachine.IsFsmActive = true;
        }

        public void ChangeScenario(int numState) {
            if (numState == 5 || numState == 6) { 
                Program.listConsoleMenu[numState]();
                return;
            } 

            _stateMachine.SwitchState(numState);
        }

        void OnUIActionEnter() {
            if (_stateMachine == null || _stateMachine.CurActiveState == null) return;

            int val = _stateMachine.CurActiveState.keyValue;
            if ((val == -1) || Program.listConsoleMenu.Count == 0) return;
            if (val >= Program.listConsoleMenu.Count) return;

            Program.listConsoleMenu[val]();
        }

        void OnUIActionExit() {
            if (_stateMachine == null || _stateMachine.CurActiveState == null) return; 

            Program.OffCurrentState(_stateMachine.CurActiveState.Name);
        }
    }
}
