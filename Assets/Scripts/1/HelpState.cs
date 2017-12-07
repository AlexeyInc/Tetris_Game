using StateBuns;
using UnityEngine;

public class HelpState : State {

    public HelpState(StateMenu stateMenu) : base(stateMenu) {

    } 

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ меню Помощи");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем меню Помощи");
    }

    public override void UpdateState(int a) {
        stateMenu.CurrentState = stateMenu.MainState;
    }
}
