using FSM;
using UnityEngine;

class UIController {

    public delegate void UIStateControllerHandler(int indx, bool active);

    public event UIStateControllerHandler ChangeUIState;

    StateMachine _stateMachine = null;

    public static UIController Instance {
        get {
            return Nested.instance;
        }
    }
    private class Nested {
        internal static readonly UIController instance = new UIController();
    }

    public UIController() {
        _stateMachine = new StateMachine();

        InitUI();
    }

    private void InitUI() {

        State[] arrStates = new State[] { new State ("mainmenu", 0),
                                          new State ("gamemenu", 1),
                                          new State ("help", 2),
                                          new State ("gamerules", 3),
                                          new State ("about", 4),
                                          new State ("newgame", 5),
                                          new State ("gameover", 6)};

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
    /// Сhecks if the state of the game changes
    /// if not, then passes control to stateMachine for change stateMenu
    /// </summary>
    /// <param name="newState">name of new State</param>
    public void ChangeScenario(string newState) {
        string state = newState.ToLower();

        if (state == "newgame") {
            GameManager.Singleton.RestartGame();
        }

        if (state == "gamemenu") {
            GameManager.Singleton.Pause();
        }

        if (state == "exit") {
            Debug.Log("Вы left game.");
            return;
        }

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
