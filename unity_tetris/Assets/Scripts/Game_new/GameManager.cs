using System;  
using UnityEngine;
using TetrisLibrary;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
  
public class GameManager : MonoBehaviour {

    [Header("Game properties")]
    public double speed;
    public double decreaseSpeed;
    public float timeBetweenCellDisapper = 0.1f;
    public float timeAfterDisapperCell = 0.2f;
    public float timeBeforePlaceNextFigure = 0.2f;
     
    [Header("Game Component")]
    [SerializeField]
    private GameObject _backgroundIMG;
    [SerializeField]
    private GameObject _figurePart;
    [SerializeField]
    private Transform _figureHolder;
    [SerializeField]
    private Transform _previewFigureHolder; 
    [SerializeField]
    private Material[] _figureColors;
      
    private static GameManager _instance; 
    private delegate bool FuncHandler();
      
    private double _scoreCounter = 30;
    private double _currentSpeed;

    private GameObject[,] _figuresStorage;
    private GameObject[,] _previewFigureStorage;
    private Animator[,] _figuresAnimator;

    private int _prevHeigth = 4,
                _prevWidth = 4;

    private GameField _gameFiledObj;
    private GameView _gameViewObj;

    private TimeSystem _timeSystemObj;
    private InputSystem _inputSystemObj;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    private void Start() { 
        InitGameComponent(); 
    }

    public static GameManager Singleton {
        get {
            return _instance;
        }
    }
      
    void InitGameComponent() { 
        _gameFiledObj = new GameField(18, 11);

        _figuresStorage = new GameObject[Board.BoardHeigth, Board.BoardWidth];
        _figuresAnimator = new Animator[Board.BoardHeigth, Board.BoardWidth]; 
        _previewFigureStorage = new GameObject[_prevHeigth, _prevWidth];

        InitBoard();
        InitPreviewBoard();

        _gameViewObj = new GameView(_figuresStorage, _previewFigureStorage, _figureColors); 

        _gameFiledObj.OnStateChanged += _gameViewObj.ViewBoard; 
        _gameFiledObj.OnAddFigure += CheckFullRows;

        _inputSystemObj = new InputSystem();
        _inputSystemObj.Init(_gameFiledObj, _gameViewObj);

        _timeSystemObj = new TimeSystem();
        _timeSystemObj.Init(_gameFiledObj, speed);

        _currentSpeed = speed;
        Instantiate(_backgroundIMG);
    }
     
    private void InitBoard() {
        for (int row = 0; row < Board.BoardHeigth; row++) {
            for (int col = 0; col < Board.BoardWidth; col++) {
                GameObject backingObj = Instantiate(_figurePart);
                backingObj.transform.SetParent(_figureHolder);
                backingObj.transform.localPosition = new Vector3(-col, -row, 1);

                _figuresStorage[row, col] = Instantiate(_figurePart);
                _figuresAnimator[row, col] = _figuresStorage[row, col].GetComponent<Animator>();
                _figuresStorage[row, col].transform.SetParent(_figureHolder);
                _figuresStorage[row, col].transform.localPosition = new Vector3(-col, -row, 0);
                _figuresStorage[row, col].GetComponent<MeshRenderer>().material = _figureColors[0];
            }
        }
    }

    private void InitPreviewBoard() {
        for (int row = 0; row < _previewFigureStorage.GetLength(0); row++) {
            for (int col = 0; col < _previewFigureStorage.GetLength(1); col++) {
                _previewFigureStorage[row, col] = Instantiate(_figurePart);
                _previewFigureStorage[row, col].transform.SetParent(_previewFigureHolder);
                _previewFigureStorage[row, col].transform.localPosition = new Vector3(-row, -col, 0); 
            }
        }
    }

    private bool PlaceNewFigure() {
        if (_gameFiledObj.PalaceFigure()) {
            _gameViewObj.PreviewNextFigure(_gameFiledObj.GetNextFigure());
            return true;
        } else {
            _gameViewObj.PreviewNextFigure(null);
            GameOver();
            return false;
        }
    }
      
    private void CheckFullRows() {
        List<int> fullRows = new List<int>();

        int count = _gameFiledObj.RemoveFullRows(ref fullRows);

        if (count > 0) {
            Pause();
            UpdateScore(count);

            DeleteFullRows(fullRows);  
        } 
        else {
            PlaceNewFigure(); 
        }
    }

    void DeleteFullRows(List<int> listRows) { 
        foreach (int row in listRows) {
            if (row != listRows[listRows.Count - 1]) {
               StartCoroutine(DeleteAnimationPlay(row));
            } else {
               StartCoroutine(DeleteAnimationPlay(row, PlaceNewFigure));
            }
        }   
    }
     
    IEnumerator DeleteAnimationPlay(int row, FuncHandler PlaceNextFigue = null) {
        for (int col = Board.BoardWidth - 1; col >= 0; col--) {

             _figuresAnimator[row,col].SetTrigger("Disapper");  

            yield return new WaitForSeconds(timeBetweenCellDisapper);
        }
        yield return new WaitForSeconds(timeAfterDisapperCell);

        for (int col = 0; col < Board.BoardWidth; col++) { 
            _figuresStorage[row, col].GetComponent<MeshRenderer>().material = _figureColors[0];
            _figuresAnimator[row, col].SetTrigger("Disapper");
        }

        if (PlaceNextFigue != null) {
            yield return new WaitForSeconds(timeBeforePlaceNextFigure);

            PlaceNextFigue();
            Unpause();
        }
    }
     
    void UpdateScore(int value) {
        if (value > 1) {
            value *= 2;
        }
        if (Score.Singleton.SetScore(value) > _scoreCounter) {
            _scoreCounter += 20;
            _currentSpeed -= decreaseSpeed;
            _timeSystemObj.SetNewSpeed(_currentSpeed);
        } 
    } 

    private void GameOver() {
        Pause(); 
        UIController.Instance.ChangeScenario("gameover");
    } 

    public void RestartGame() {  
        _gameFiledObj.Clear();

        if (PlaceNewFigure()) {
            Unpause();
        }

        if (Score.Singleton != null) {
            Score.Singleton.SetScore(-1);
        }
       
        _currentSpeed = speed;
        _timeSystemObj.SetNewSpeed(_currentSpeed); 
    }

    public void Pause() {
        _timeSystemObj.SetPause(true);
        _inputSystemObj.SetPause(true);
    }

    public void Unpause() {
        _timeSystemObj.SetPause(false);
        _inputSystemObj.SetPause(false);
    } 
} 
