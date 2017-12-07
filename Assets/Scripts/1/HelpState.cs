using StateBuns;
using UnityEngine;

public class HelpState : State {

    public HelpState(StateMenu stateMenu) : base(stateMenu) {

    }

    //-------------
    //private static HelpState _instance;

    //private HelpState() {
    //    if (_instance != null) {
    //        return;  
    //    }
    //    _instance = this;
    //}

    //public static HelpState Instance {
    //    get {
    //        if (_instance == null) {
    //            return new HelpState(); 
    //        }
    //        return _instance;
    //    }
    //}
    //-------------

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
