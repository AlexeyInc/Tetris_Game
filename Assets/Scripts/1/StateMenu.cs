 
namespace StateBuns
{ 
    public abstract class State {

        protected readonly StateMenu stateMenu;

        public State(StateMenu stateMenu) {
            this.stateMenu = stateMenu;
        }

        public abstract void ActiveState();
        public abstract void DeactivateState();
        public abstract void UpdateState(int numState);
    }

    public class StateMenu { 

        internal State CurrentState { get; set; }
        internal State MainState { get; set; }
        internal State GameState { get; set; }
        internal State HelpState { get; set; }

        public StateMenu() {
            MainState = new MainState(this);
            GameState = new GameState(this);
            HelpState = new HelpState(this);
            CurrentState = MainState;
        }

        public void Update(int num = 0) {
            CurrentState.DeactivateState();
            CurrentState.UpdateState(num);
            CurrentState.ActiveState();
        }  
    }
} 
