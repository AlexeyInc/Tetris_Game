 using UnityEngine; 

public class Viewer : MonoBehaviour {

    public delegate void StateHandlerDel(States someState); 
    public event StateHandlerDel ChangeMenu;

    public GameObject c_MainMenu,
                  c_GameMenu,
                  c_HelpMenu;

    public static Viewer _instance; 

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
        Controller prog = new Controller();
        prog.Init();
    }

    public void OnClickGame() {
        ChangeMenu(States.Game);
    }

    public void OnClickHelp() {
        ChangeMenu(States.Help);
    }

    public void OnClickBackHelp() {
        ChangeMenu(States.Main);
    }

    public void OnClickBackGame() {
        ChangeMenu(States.Main);
    }

    public void ModeMenu(bool valMain, bool valGame, bool valHelp) {
 
        c_MainMenu.SetActive(valMain);
        c_GameMenu.SetActive(valGame);
        c_HelpMenu.SetActive(valHelp);
    }  

    public void SetActive() {
        c_MainMenu.SetActive(true);
    }
}
