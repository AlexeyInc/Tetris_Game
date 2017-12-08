using UnityEngine;
using StateSpace; 

public class GameState_ : State { 
    private static GameState_ _instance;

    public static GameState_ Instance {
        get {
            if (_instance == null) {
                new GameState_();
            }
            return _instance;
        }
    }

    public GameState_() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ Игровое меню_2");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем Игровое меню_2");
    }

    public override void UpdateState(StateMachine curMenu) {
        curMenu.ChangeState(MainState_.Instance);
    }
}