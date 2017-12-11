 using UnityEngine;
using System.Collections.Generic;
using MyFSM;

public class View : MonoBehaviour {

    public static View instance;

    public GameObject[] UI_Elements;  

    private void Awake() {
        instance = this; 
    }  

    public void OnMenuButtonClick_Name(string newStateName) {
        Controller.instance.ChangeScenario(newStateName);
    } 
}
