 using UnityEngine;
using StateSpace;

public class MainState_ : State {
    private static MainState_ _instance;

    public static MainState_ Instance {
        get { 
            return _instance;
        }
    }

    public MainState_() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ главное меню_2");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем главное меню_2");
    }

    public override void UpdateState(StateMachine menu) {
        //no any logic 
    }
}
