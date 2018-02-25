using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Qestion_script : MonoBehaviour {

    public Material myMaterial;
    public Material myMaterial2;
    public Material myMaterialRed;
    public Material myMaterialPurple;

    // Use this for initialization
    void Start () {
        //this.GetComponent<MeshRenderer>().material = myMaterial;

        //Invoke("ActiveAnim", 2f);
	}

    public void ActiveAnim() {
        this.GetComponent<Animator>().enabled = true;

    }

    public void SetColorGreen() {
        this.GetComponent<MeshRenderer>().material = myMaterial;
    }

    public void setColorRed() {
        this.GetComponent<MeshRenderer>().material = myMaterialRed;
    }

    public void setColorPurple() {
        this.GetComponent<MeshRenderer>().material = myMaterialPurple;
    }

    public void setColorDef() {
        this.GetComponent<MeshRenderer>().material = myMaterial2; 
    }

    public void ActiveAnimClick() {
        this.GetComponent<Animator>().enabled = true;

    }
    public void DeactiveAnimClick() {
        this.GetComponent<Animator>().enabled = false;

    } 

    public void SetTrigger() {
        this.GetComponent<Animator>().SetTrigger("Disapper");
    }

    [Space]
    [Header("Past_component")]
    public GameObject obj;
    public GameObject[] _storeObj;
    public Material _material;

    Material[] _storeMaterial;
    public void SetNoneMaterial() {
        _storeObj = new GameObject[250];
        _storeMaterial = new Material[250];

        for (int i = 0; i < _storeObj.Length; i++) {
            _storeObj[i] = Instantiate(obj, new Vector3(i, 0, 0), Quaternion.identity);
            _storeMaterial[i] = _storeObj[i].GetComponent<MeshRenderer>().material;
        } 
    }

    public void CheckCostProcessing() {
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        stopWatch.Start(); 
        for (int i = 0; i < _storeObj.Length; i++) {
            //_storeObj[i].GetComponent<MeshRenderer>().material = _material;//0.8256
            _storeMaterial[i] = _material;
        }
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
         
        Debug.Log("RunTime: Min:" + ts.Minutes + " Sec: " + ts.Seconds + " Mil: "+ ts.Milliseconds + "Total: " + ts.TotalMilliseconds);
    }
}
