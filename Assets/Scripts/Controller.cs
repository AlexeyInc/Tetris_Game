using MyFSM;
using UnityEngine;

class Controller : MonoBehaviour {
    static Controller _instance;
     
    StateMachine _stateMachine = null;

    public static Controller Instance {
        get {
            if (_instance == null) {
                new Controller();
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
        _stateMachine = new StateMachine(); 
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
            if (View.Instance != null) {
                _stateMachine.SwitchState("MainMenu");
            }
        }
    }

    /// <summary>
    /// checks if the state of the game changes
    /// if not, then passes control to stateMachine for change stateMenu
    /// </summary>
    /// <param name="newState">name of new State</param>
    public void ChangeScenario(string newState) { 
        if (newState == "NewGame") {
            int val = _stateMachine.CurActiveState.someValue;
            View.Instance.UI_Elements[val].SetActive(false);
        }

        if (newState == "Exit") {
            Application.Quit();
        }

        _stateMachine.SwitchState(newState);
    }

     void OnUIActionEnter() {
        if (_stateMachine == null || _stateMachine.CurActiveState == null) return;

        int val = _stateMachine.CurActiveState.someValue; 
        if ((val == -1) || View.Instance.UI_Elements.Length == 0) return;
        if (val >= View.Instance.UI_Elements.Length) return;

        View.Instance.UI_Elements[val].SetActive(true);
    }

     void OnUIActionExit() {
        if (_stateMachine == null || _stateMachine.CurActiveState == null) return;

        int val = _stateMachine.CurActiveState.someValue;
        if ((val == -1) || View.Instance.UI_Elements.Length == 0) return;
        if (val >= View.Instance.UI_Elements.Length) return;

        View.Instance.UI_Elements[val].SetActive(false);
    }

}
