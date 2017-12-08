
namespace StateSpace {

    public abstract class State {
        public virtual void ActiveState() { }
        public virtual void DeactivateState() { }
        public virtual void UpdateState(StateMachine menu) { }
    }

    public class StateMachine {
        public State CurrentState { get; private set; }

        public StateMachine() {
            CurrentState = null;
        }

        public void ChangeState(State newState) {
            if (CurrentState != null) {
                CurrentState.DeactivateState();
            }
            CurrentState = newState;
            CurrentState.ActiveState();
        }

        public void Update() {
            if (CurrentState != null) {
                CurrentState.UpdateState(this);
            }
        }
    }
}

