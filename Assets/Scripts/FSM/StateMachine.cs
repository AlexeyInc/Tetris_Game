
namespace StateSpace {

    public abstract class State {
        public virtual void ActiveState(StateMachine stateMachine) { }
        public virtual void DeactivateState(StateMachine stateMachine) { } 
    }

    public class StateMachine {
        public State CurrentState { get; private set; }

        public bool isActiveMain, isActiveGame, isActiveHelp;
        
        public StateMachine() {
            CurrentState = null;
        }

        public void ChangeState(State newState) {
            if (CurrentState != null) {
                CurrentState.DeactivateState(this);
            }
            CurrentState = newState;
            CurrentState.ActiveState(this);
        }

        public void GetMode(out bool menu, 
                            out bool game,
                            out bool help) {
            menu = isActiveMain;
            game = isActiveGame;
            help = isActiveHelp;
        }
    }
}

