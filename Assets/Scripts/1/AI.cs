using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBuns;

public class AI : MonoBehaviour {
     
    public StateMenu stateMenu { get; set; }

    private void Start() {
        stateMenu = new StateMenu();
        stateMenu.CurrentState.ActiveState(); 
    } 

    public void OnClickGame() { 
        stateMenu.Update(1);
    }

    public void OnClickHelp() {
        stateMenu.Update(2);
    }

    public void BackClick() {
        stateMenu.Update();
    }
     
}
