 
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

        //------------------
        //internal State CurrentState { get; private set; } 
        //public StateMenu() { 
        //    CurrentState = null;
        //}

        //public void ChangeState(State _newState) {
        //    if (CurrentState != null) {
        //        CurrentState.DeactivateState(); 
        //    }
        //    CurrentState = _newState;
        //    CurrentState.ActiveState();
        //} 

        //public void Update(string name) {
        //    if (CurrentState != null) {
        //        switch (name) {
        //            case "Game":
        //                CurrentState.UpdateState(GameState.Instance);
        //                break;
        //            case "Help":
        //                CurrentState.UpdateState(HelpState.Instance);
        //                break;
        //            default: Debug.Log("Не подошел ни один из ключей");
        //                break;
        //        } 
        //    }
        //}
        //------------
    }
} 
