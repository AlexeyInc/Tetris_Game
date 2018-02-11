using System; 
using UnityEngine;
using TetrisLibrary;
 
class TimeSystem {

    private TimeSystemView _view;

    public TimeSystem() {
        _view = new GameObject("TimeSystem_obj").AddComponent<TimeSystemView>();
    }
     
    public void Init(GameField GF, double speed) { 
        _view.Tick += GF.DoStep;
        _view.GameSpeed = speed;
    }

    public void SetNewSpeed(double incrSpeed) {
        if (_view.GameSpeed > incrSpeed) {
            _view.GameSpeed -= incrSpeed;
        }
    } 

    public void SetPause(bool isActive) {
        _view.Pause = isActive;
    }
} 
