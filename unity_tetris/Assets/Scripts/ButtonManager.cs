using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyFSM;

public class ButtonManager : MonoBehaviour {

    Button _btn; 

	void Awake() { 
        _btn = this.gameObject.GetComponent<Button>();
        _btn.onClick.AddListener(StateOnClick);
	}

    /// <summary>
    /// The method calls the state by name.
    /// If name of the object contain several words through symbol '_'
    /// at the end there should always be a name of the state.
    /// </summary>
	void StateOnClick() {
        string[] nameMenu = gameObject.name.Split('_'); 
        Controller.Instance.ChangeScenario(nameMenu[nameMenu.Length -1]);
    }
}
