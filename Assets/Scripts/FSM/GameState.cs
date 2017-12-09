using UnityEngine;
using StateSpace; 

public class GameState : State { 
    private static GameState _instance;

    public static GameState Instance {
        get {
            if (_instance == null) {
                return new GameState();
            }
            return _instance;
        }
    }

    public GameState() {
        if (_instance != null) {
            return;
        }
        _instance = this;
    }

    public override void ActiveState(StateMachine stateMachine) {
        stateMachine.isActiveGame = true;
    }

    public override void DeactivateState(StateMachine stateMachine) {
        stateMachine.isActiveGame = false;
    } 
}