using StateSpace;

public class HelpState : State {
    private static HelpState _instance;

    public static HelpState Instance {
        get {
            if (_instance == null) {
                return new HelpState();
            }
            return _instance;
        }
    }

    public HelpState() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState(StateMachine stateMachine) {
        stateMachine.isActiveHelp = true;
    }

    public override void DeactivateState(StateMachine stateMachine) {
        stateMachine.isActiveHelp = false;
    }
     
}