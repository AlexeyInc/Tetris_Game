using System; 
using UnityEngine;
using TetrisLibrary;

class InputSystem {

    private InputSystemView _view;

    public InputSystem() {
        _view = new GameObject("InputSystem_obj").AddComponent<InputSystemView>(); 
    }

    public void Init(GameField gameField, GameView gameView) { 
        _view.RigthClick += gameField.MoveRigth; 

        _view.LeftClick += gameField.MoveLeft; 

        _view.DownClick += gameField.MoveDown; 

        _view.RotateClick += gameField.Rotate; 

        _view.DropClick += gameField.Drop;  
    }

    public void SetPause(bool isActive) {
        _view.Pause = isActive;
    }
} 