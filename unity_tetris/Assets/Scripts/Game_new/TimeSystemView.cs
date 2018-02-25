using System;  
using UnityEngine;

public class TimeSystemView : MonoBehaviour {

    public Action Tick;

    public double GameSpeed { get; set; } 
    public bool Pause { get; set; }

    private double _speedCounter = 0;
      
	void Update () { 
        if (_speedCounter > GameSpeed && GameSpeed > 0 && !Pause) {
            _speedCounter = 0; 
            Tick();
        }

        _speedCounter += Time.deltaTime; 
    }
}
