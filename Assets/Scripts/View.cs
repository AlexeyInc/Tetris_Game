 using UnityEngine;
using System.Collections.Generic;
using FSM;

public class View : MonoBehaviour {

    public static View instance;

    public GameObject[] UI_Elements;
    StateMachine _stateMachine = null;

    public State ActiveState {
        get {
            if (_stateMachine != null || _stateMachine.IsFsmActive || _stateMachine.ActiveState != null) { 
                return _stateMachine.ActiveState;
            } else {
                return null;
            }
        }
    }

    private void Awake() {
        instance = this;
        InitUI();
    }

    void InitUI() {
        _stateMachine = new StateMachine(); 
        State[] arrStates = new State[6] { new State ("MainMenu", 0),
                                           new State ("Game", 1),
                                           new State ("Help", 2),
                                           new State ("GameRules", 3),
                                           new State ("About", 4),
                                           new State ("NewGame", 5) }; 

        foreach (State st in arrStates) {
            st.OnStateEnter += OnUIActionEnter;
            st.OnStateExit += OnUIActionExit;
        }  
         
        _stateMachine.AddStates(arrStates);
        _stateMachine.SwitchState(_stateMachine["MainMenu"]);
        
        _stateMachine.IsFsmActive = true; 
    }

    public void OnUIActionEnter() {
        if (_stateMachine == null || _stateMachine.ActiveState == null) return;
        int val = _stateMachine.ActiveState.someValue;
        if ((val == -1) || UI_Elements.Length == 0) return;
        if (val >= UI_Elements.Length) return;

        UI_Elements[val].SetActive(true);

        if (_stateMachine.ActiveState.Name == "NewGame" || _stateMachine.ActiveState.Name == "Exit") {
            if (Controller.instance != null) {
                Controller.instance.ChangeScenario(this);
            }
        }
    }

    public void OnUIActionExit() {
        if (_stateMachine == null || _stateMachine.ActiveState == null) return;
        int val = _stateMachine.ActiveState.someValue;
        if ((val == -1) || UI_Elements.Length == 0) return;
        if (val >= UI_Elements.Length) return;
        UI_Elements[val].SetActive(false); 
    }

    public void OnMenuButtonClick_Name(string newStateName) { 
        _stateMachine.SwitchState(newStateName);
    }

    public void SwitchState(string Name = "") {
        if (_stateMachine == null) return;
        _stateMachine.SwitchState(Name);
    } 
}
