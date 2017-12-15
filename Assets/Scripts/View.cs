 using UnityEngine;
using System.Collections.Generic;
using MyFSM;

public class View : MonoBehaviour {

    private static View _instance;

    public GameObject[] UI_Elements; 

    public static View Instance {
        get {
            if (_instance == null) {
                new View();
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this; 
    }  

    public void OnMenuButtonClick_Name(string newStateName) {
        Controller.Instance.ChangeScenario(newStateName);
    } 
}
