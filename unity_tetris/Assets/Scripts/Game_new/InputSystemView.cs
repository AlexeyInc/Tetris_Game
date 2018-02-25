using System; 
using UnityEngine;

public class InputSystemView : MonoBehaviour {
     
    public Action RigthClick;
    public Action LeftClick;
    public Action DownClick;
    public Action DropClick;
    public Action RotateClick;

    public bool Pause { get; set; } 

    void Update() {

        if (!Pause) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                LeftClick();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                RigthClick();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                DownClick();
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                DropClick();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                RotateClick();
            }
        } 
    }
}