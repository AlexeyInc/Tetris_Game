 
using UnityEngine;
using StateSpace;

public class HelpState_ : State {
    private static HelpState_ _instance;

    public static HelpState_ Instance {
        get { 
            return _instance;
        }
    }

    public HelpState_() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ меню помощи_2");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем меню помощи_2");
    }

    public override void UpdateState(StateMachine curMenu) {
        curMenu.ChangeState(MainState_.Instance);
    }
}