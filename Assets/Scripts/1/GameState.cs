using UnityEngine;
using StateBuns;

public class GameState : State {

    public GameState(StateMenu stateMenu) : base(stateMenu) {

    }

    //-------------
    //private static GameState _instance;

    //private GameState() {
    //    if (_instance != null) {
    //        return; // change only to _instance = this;
    //    }
    //    _instance = this;
    //}

    //public static GameState Instance {
    //    get {
    //        if (_instance == null) {
    //            new GameState();//change to return new MainState();
    //        }
    //        return _instance;
    //    }
    //}
    //-------------

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
