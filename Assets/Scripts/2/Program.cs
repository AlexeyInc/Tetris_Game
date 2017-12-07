using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateSpace;

public class Program : MonoBehaviour {
    //public Canvas MainMenuCanvas, GameMenuCanvas, HelpMenuCanvas; 

    public StateMachine StateMachine { get; set; }

    private void Start() {
        StateMachine = new StateMachine();
        StateMachine.ChangeState(MainState_.Instance);
    }

    //Методы выключают текущее состояние и включает следующее 

    public void OnClickGame() {
        StateMachine.ChangeState(GameState_.Instance);
    }

    public void OnClickHelp() {
        StateMachine.ChangeState(HelpState_.Instance);
    }

    //Выключает текущее состояния и возвращает в главное меню

    public void BackClick() {
        StateMachine.Update();
    }
}
