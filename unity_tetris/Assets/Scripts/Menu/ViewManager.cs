 using UnityEngine;
using System.Collections.Generic;
using FSM;

public class ViewManager : MonoBehaviour {

    [SerializeField]
    Transform _menuHolder;
    [SerializeField]
    GameObject[] UI_Elements;

    IDictionary<int, GameObject> listMenuPrefabs;
    bool[] isInstantiatedPrefab; 

    private void Start() { 
        listMenuPrefabs = new Dictionary<int, GameObject>();
        isInstantiatedPrefab = new bool[UI_Elements.Length];

        UIController.Instance.ChangeUIState += SetUI_Active;
        UIController.Instance.ActiveFSM(); 
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UIController.Instance.ChangeScenario("MainMenu");
        }
    }

    /// <summary>
    /// Activate/Diactivate UI menu 
    /// </summary>
    /// <param name="indx">number menu in list</param>
    /// <param name="value">activation mode</param>
    public void SetUI_Active(int indx, bool value) {
        if (indx >= UI_Elements.Length) return;

        CheckOnExistInHierarchy(indx);
         
        listMenuPrefabs[indx].SetActive(value); 
    }

    private void CheckOnExistInHierarchy(int i) {
        if (!isInstantiatedPrefab[i]) {
            GameObject menuObj = Instantiate(UI_Elements[i]);
            menuObj.transform.SetParent(_menuHolder); 
            listMenuPrefabs[i] = menuObj;

            isInstantiatedPrefab[i] = true;
        }
    }
}
