using MyFSM;
using UnityEngine;

class Controller : MonoBehaviour {
    public static Controller instance;
    StateMachine _stateMachine = null;

    private void Awake() {
        instance = this;
        _stateMachine = new StateMachine();
        Debug.Log(_stateMachine);
    }

    private void Start() {
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
         
        _stateMachine.SwitchState(0);

        _stateMachine.IsFsmActive = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (View.instance != null) {
                _stateMachine.SwitchState("MainMenu");
            }
        }
    }

    public void ChangeScenario(string newState) { 
        if (newState == "NewGame") {
            int val = _stateMachine.CurActiveState.someValue;
            View.instance.UI_Elements[val].SetActive(false);
        }

        if (newState == "Exit") {
            Application.Quit();
        }

        _stateMachine.SwitchState(newState);
    }

    public void OnUIActionEnter() {
        if (_stateMachine == null || _stateMachine.CurActiveState == null) return;
        int val = _stateMachine.CurActiveState.someValue;
        if ((val == -1) || View.instance.UI_Elements.Length == 0) return;
        if (val >= View.instance.UI_Elements.Length) return;

        View.instance.UI_Elements[val].SetActive(true);
    }

    public void OnUIActionExit() {
        if (_stateMachine == null || _stateMachine.CurActiveState == null) return;
        int val = _stateMachine.CurActiveState.someValue;
        if ((val == -1) || View.instance.UI_Elements.Length == 0) return;
        if (val >= View.instance.UI_Elements.Length) return;
        View.instance.UI_Elements[val].SetActive(false);
    }

}
