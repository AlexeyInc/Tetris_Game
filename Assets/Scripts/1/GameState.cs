using UnityEngine;
using StateBuns;

public class GameState : State {

    public GameState(StateMenu stateMenu) : base(stateMenu) {

    } 

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ Игровое меню");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем Игровое меню");
    }

    public override void UpdateState(int a) {
        stateMenu.CurrentState = stateMenu.MainState;
    }
}
