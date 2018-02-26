 using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

    Button _btn; 

    void Awake() {
        _btn = this.gameObject.GetComponent<Button>();
        _btn.onClick.AddListener(RestartGame); 
    }
     
    void RestartGame() {  
        UIController.Instance.ChangeScenario("newgame");
    }
}
