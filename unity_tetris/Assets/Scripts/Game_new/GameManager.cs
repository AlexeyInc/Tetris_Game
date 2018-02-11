using System;  
using UnityEngine;
using TetrisLibrary;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
     
    public double speed;
    public double increaseSpeed;

    [Header("Game Component")]
    [SerializeField]
    private GameObject _figurePart;
    [SerializeField]
    private Transform _figureHolder;
    [SerializeField]
    private Transform _previewFigureHolder;
    [SerializeField]
    private Material[] _figureColors;

    [Header("UI")]
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Text _scoreText;
     
    private int _score;
    private double _scoreCounter = 50;

    private GameObject[,] _figuresStorage;
    private GameObject[,] _previewFigureStorage;

    private int _prevHeigth = 4,
                _prevWidth = 4;

    private GameField _gameFiledObj;
    private TimeSystem _timeSystemObj;
    private InputSystem _inputSystemObj;
    private GameView _gameViewObj;
      
    private void Start() { 
        InitGameComponent(); 
    }

    void InitGameComponent() {
        _gameFiledObj = new GameField(16, 10);

        _figuresStorage = new GameObject[Board.BoardHeigth, Board.BoardWidth];
        _previewFigureStorage = new GameObject[_prevHeigth, _prevWidth];
        InitBoard();
        InitPreviewBoard();

        _gameViewObj = new GameView(_figuresStorage, _previewFigureStorage, _figureColors); 

        _gameFiledObj.OnStateChanged += _gameViewObj.ViewBoard; 
        _gameFiledObj.OnAddFigure += CheckFullRows;

        if (PlaceNewFigure()) {

            _inputSystemObj = new InputSystem();
            _inputSystemObj.Init(_gameFiledObj, _gameViewObj);

            _timeSystemObj = new TimeSystem();
            _timeSystemObj.Init(_gameFiledObj, speed);
        } 
    }


    private void InitBoard() {
        for (int row = 0; row < Board.BoardHeigth; row++) {
            for (int col = 0; col < Board.BoardWidth; col++) {
                _figuresStorage[row, col] = Instantiate(_figurePart);
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
                _previewFigureStorage[row, col].SetActive(false);
            }
        }
    }

    private bool PlaceNewFigure() {
        if (_gameFiledObj.PalaceFigure()) {
            _gameViewObj.PreviewNextFigure(_gameFiledObj.GetNextFigure());
            return true;
        } else {
            _gameViewObj.PreviewNextFigure(null);
            return false;
        }
    }
      
    private void CheckFullRows() { 
        _score += _gameFiledObj.RemoveFullRows();
        if (_score > _scoreCounter) {
            _scoreCounter += 20;
            _timeSystemObj.SetNewSpeed(increaseSpeed);
        }
        _scoreText.text = "Score: " + _score.ToString();

        if (!PlaceNewFigure()) {
            GameOver();
        }  
    }

    private void GameOver() {
        _timeSystemObj.SetPause(true);
        _gameOverPanel.SetActive(true); 
    } 

    public void RestartGame() {
        _gameOverPanel.SetActive(false);
        _gameFiledObj.Clear();
        _score = 0;

        if (PlaceNewFigure()) {
            _timeSystemObj.SetPause(false); 
        }
    } 
} 
 