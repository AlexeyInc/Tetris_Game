using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateSpace;
 

class Program : MonoBehaviour { 
     
    public StateMachine StateMachine { get; set; }

    private void Start() {
        StateMachine = new StateMachine();
        StateMachine.ChangeState(MainState_.Instance);
    }

    //Methods turn off the current state and include the following

    public void OnClickGame() {
        StateMachine.ChangeState(GameState_.Instance);
    }

    public void OnClickHelp() {
        StateMachine.ChangeState(HelpState_.Instance);
    }

    //Turns off the current state and returns to the main menu

    public void BackClick() {
        StateMachine.Update();
    }
}
