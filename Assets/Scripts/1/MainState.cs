using UnityEngine;
using StateBuns;
using System.Collections.Generic;

public class MainState : State { 

    public MainState(StateMenu stateMenu) : base(stateMenu) {
        
    }

    //-------------
    //private static MainState _instance; 

    //private MainState() {
    //    if (_instance != null) {
    //        return;  
    //    }
    //    _instance = this;
    //}

    //public static MainState Instance {
    //    get {
    //        if (_instance == null) {
    //            return new MainState(); 
    //        }
    //        return _instance;
    //    }
    //}
    //-------------

    public override void ActiveState() {
        Debug.Log("ВКЛЮЧАЕМ главное меню");
    }

    public override void DeactivateState() {
        Debug.Log("Выключаем главное меню");
    }

    public override void UpdateState(int num) {
        switch (num) {
            case 1:
                stateMenu.CurrentState = stateMenu.GameState;
                break;
            case 2:
                stateMenu.CurrentState = stateMenu.HelpState;
                break;
            default: Debug.Log("Ключ не найден");
                break;
        } 
    }
}
