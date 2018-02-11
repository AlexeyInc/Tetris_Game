using System; 
using UnityEngine;

public class InputSystemView : MonoBehaviour {
     
    public Action RigthClick;
    public Action LeftClick;
    public Action DownClick;
    public Action DropClick;
    public Action RotateClick;
     
    void Update() {
       
        if (Input.GetKeyDown(KeyCode.D)) {
            LeftClick();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            RigthClick();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            DownClick();
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            DropClick();
        }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            RotateClick();
        }
    }
}