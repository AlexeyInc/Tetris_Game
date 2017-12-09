 using StateSpace; 
 
//Base states of menu
public enum States {
    Main,
    Game,
    Help
}

class Controller { 

    StateMachine StateMachine { get; set; }
     
    public void Init() {
        StateMachine = new StateMachine();

        Viewer._instance.ChangeMenu += OnClick;

        OnClick(States.Main);
    }

    //Turn off the current state and turn on following
    private void OnClick(States someState) { 
        switch (someState) {
            case States.Main:
                StateMachine.ChangeState(MainState.Instance); 
                break;
            case States.Game:
                StateMachine.ChangeState(GameState.Instance);
                break;
            case States.Help:
                StateMachine.ChangeState(HelpState.Instance);
                break;
            default:
                break;
        }

        SetupView();
    }

    //----------This_method_makes_me_cry--------------------
    private void SetupView() {   
        Viewer._instance.ModeMenu(StateMachine.isActiveMain,
                                  StateMachine.isActiveGame,
                                  StateMachine.isActiveHelp); 
    }
    //------------------------------------------------------

}
