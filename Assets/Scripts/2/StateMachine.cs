
namespace StateSpace {

    public abstract class State {
        public abstract void ActiveState();
        public abstract void DeactivateState();
        public abstract void UpdateState(StateMachine menu);
    }

    public class StateMachine {
        public State CurrentState { get; private set; }

        public StateMachine() {
            CurrentState = null;
        }

        public void ChangeState(State _newState) {
            if (CurrentState != null) {
                CurrentState.DeactivateState();
            }
            CurrentState = _newState;
            CurrentState.ActiveState();
        }

        public void Update() {
            if (CurrentState != null) {
                CurrentState.UpdateState(this);
            }
        }
    }
}

