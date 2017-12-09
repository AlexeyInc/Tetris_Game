using StateSpace;

public class MainState : State {
    private static MainState _instance;

    public static MainState Instance {
        get {
            if (_instance == null) {
                return new MainState();
            }
            return _instance;
        }
    }

    public MainState() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState(StateMachine stateMachine) {
        stateMachine.isActiveMain = true;
    }

    public override void DeactivateState(StateMachine stateMachine) {
        stateMachine.isActiveMain = false;
    }
     
}
