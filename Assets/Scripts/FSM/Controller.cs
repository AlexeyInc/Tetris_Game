using FSM;
using UnityEngine;

class Controller : MonoBehaviour {
    public static Controller instance;

    private void Awake() {
        instance = this;
    }

    public void ChangeScenario(View view) {
        if (view == null) return;
        State state = view.ActiveState;

        if (state == null) return;

        string name = state.Name;

        if (name == "NewGame") {
            view.SwitchState("HUD");
        }

        if (name == "Exit") {
            Application.Quit();
        }
    }
}
