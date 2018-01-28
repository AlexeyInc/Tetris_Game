using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tetris_library;
  
public class GameView : MonoBehaviour {

    public GameObject tetrImage_test;//delete

    [SerializeField]
    private GameObject _tetrominoImage; 
    [SerializeField]
    private Canvas _gameCanvas;
    [SerializeField]
    private Canvas _UICanvas;
    [SerializeField]
    private Text _scoreText;
    [SerializeField] 
    private Text _tetrominesDropped;
    [SerializeField]
    private Transform _gameTetrominoHolder;
    [SerializeField]
    private Transform _previewTetrominoHolder;
    [SerializeField]
    private Transform _fixedTetrominesHolder;

    private GameObject[] _curTetrominoParts;
    private GameObject[] _previewTetrominoParts;
    private GameObject[,] _fixedTetrominesStorage;
     
    private Tetris_library.Grid _gridPreviewObj;
    private GameField _gameFieldObj;
    private TetrisManager _tetrisManagerObj;
    private float _gameSpeed = 0.6f; 

    private void Start() {
         
        _gameFieldObj = new GameField(21, 12);
        _fixedTetrominesStorage = new GameObject[_gameFieldObj.GridHeigth, _gameFieldObj.GridWidth];

        _gridPreviewObj = new Tetris_library.Grid(4, 4); 
        _tetrisManagerObj = new TetrisManager();  
         
        InitCurretAndPreviewTetromino(); 
        InitializeFieldTeromines(); 

        OnNewGame();
    }

    void InitCurretAndPreviewTetromino() {
        _curTetrominoParts = new GameObject[4];
        _previewTetrominoParts = new GameObject[4];

        for (int i = 0; i < _curTetrominoParts.Length; i++) {
            _curTetrominoParts[i] = Instantiate(_tetrominoImage, new Vector3(0, _gameFieldObj.GridHeigth + 2, 0), Quaternion.identity);
            _curTetrominoParts[i].transform.SetParent(_gameTetrominoHolder);
            _previewTetrominoParts[i] = Instantiate(_tetrominoImage, new Vector3(0, _gameFieldObj.GridHeigth + 2, 0), Quaternion.identity);
            _previewTetrominoParts[i].transform.SetParent(_previewTetrominoHolder);
        }
    } 

    void InitializeFieldTeromines() {
        for (int row = 0; row < _gameFieldObj.GridHeigth; row++) {
            for (int col = 0; col < _gameFieldObj.GridWidth; col++) {
                _fixedTetrominesStorage[row, col] = Instantiate(_tetrominoImage, new Vector3(col, row, 0), Quaternion.identity);
                _fixedTetrominesStorage[row, col].transform.SetParent(_fixedTetrominesHolder);
                _fixedTetrominesStorage[row, col].SetActive(false);  
            }
        }
    }
    
    /// <summary>
    /// Создает новую игру, устанавливает следующую фигуру, запускает игровой цикл
    /// </summary>
    public void OnNewGame() { 
        _tetrisManagerObj.StateChanged += Game_StateChanged;
        SetScore(0);
        _tetrisManagerObj.GameOver = false;
        _tetrisManagerObj.NextTetromino = Tetromino.RandomTetromino();
        SetPreviewTetromino();

        _gameFieldObj.Clear();
        _UICanvas.gameObject.SetActive(false);
         
        StartCoroutine("GameCycle");  
    }

    void Game_StateChanged() {
        _scoreText.text = "Score: " + _tetrisManagerObj.Score.ToString();
        _tetrominesDropped.text = "Dropped: " + _tetrisManagerObj.TetrominesDropped.ToString();
    }

    IEnumerator GameCycle() {
        while (!_tetrisManagerObj.Paused) {  
             
            _gameFieldObj.DoStep();
            MoveTetromino();
             
            if (!_gameFieldObj.IsFalling) { 
                SetScore(_tetrisManagerObj.Score + _gameFieldObj.RemoveFullRows() * 10); 
                ViewFixedTetromines();

                if (_gameFieldObj.PlaceTetromino(_tetrisManagerObj.NextTetromino)) {
                    ResetCurTetromino();

                    _tetrisManagerObj.NextTetromino = Tetromino.RandomTetromino();
                     
                    _tetrisManagerObj.TetrominesDropped++; 

                    _gridPreviewObj.Clear();
                    _gridPreviewObj.SetTetromino(_tetrisManagerObj.NextTetromino.MoveTo(1, 1), false);
                    SetPreviewTetromino(); 
                } else {
                    OnGameOver();
                } 
            }  
            yield return new WaitForSeconds(_gameSpeed);
        }
    }
     
    private void MoveTetromino() {
        if (_gameFieldObj.Current != Tetromino.Zero) {
            for (int i = 0; i < _curTetrominoParts.Length; i++) {
                _curTetrominoParts[i].transform.position = new Vector3(_gameFieldObj.Current.arrPosX[i], _gameFieldObj.Current.arrPosY[i], 0);
            }
        }
    }

    private void ViewFixedTetromines() {
        for (int row = 0; row < _gameFieldObj.GridHeigth; row++) {
            for (int col = 0; col < _gameFieldObj.GridWidth; col++) { 

                if (_gameFieldObj._tiles[row, col] != TileType.Empty) {
                    _fixedTetrominesStorage[row, col].GetComponent<MeshRenderer>().material.color = GetTetrominoColor(_gameFieldObj._tiles[row, col]);
                    _fixedTetrominesStorage[row, col].SetActive(true);
                } else {
                    _fixedTetrominesStorage[row, col].SetActive(false);
                }
            }
        }
    }

    private void SetPreviewTetromino() {
        if (_tetrisManagerObj.NextTetromino != Tetromino.Zero) {
            for (int i = 0; i < _previewTetrominoParts.Length; i++) {
                _previewTetrominoParts[i].transform.localPosition = new Vector3(_tetrisManagerObj.NextTetromino.arrPosX[i], _tetrisManagerObj.NextTetromino.arrPosY[i], 0);
                _previewTetrominoParts[i].GetComponent<MeshRenderer>().material.color = GetTetrominoColor(_tetrisManagerObj.NextTetromino.type);
            }
        }
    }
     
    private void ResetCurTetromino() {
        for (int i = 0; i < _curTetrominoParts.Length; i++) {
            _curTetrominoParts[i].transform.position = new Vector3(0, _gameFieldObj.GridHeigth + 2, 0);
            _curTetrominoParts[i].GetComponent<MeshRenderer>().material.color = GetTetrominoColor(_gameFieldObj.Current.type);
        }
    }

    private Color GetTetrominoColor(TileType type) {
        switch (type) {
            case TileType.Blue:
                return Color.blue;
            case TileType.Red:
                return Color.red;
            case TileType.White:
                return Color.white;
            case TileType.Green:
                return Color.green;
            case TileType.Yellow:
                return Color.yellow;
            case TileType.Purple:
                return Color.cyan;
            case TileType.Orange:
                return Color.magenta;
            default:
                Debug.Log(type.ToString());
                Debug.Log("Ни один из вариантов не пошел");
                return Color.clear;
        }
    }
       
    private void SetScore(int nScore) {
        _tetrisManagerObj.Score = nScore;
    }

    private void SetPause(bool enable) {
        if (_tetrisManagerObj.GameOver) return;
        _tetrisManagerObj.Paused = enable;

        if (!enable) StartCoroutine("GameCycle");
    }

    private void OnGameOver() {
        _tetrisManagerObj.Over(); 
        StopAllCoroutines();
        _UICanvas.gameObject.SetActive(true);
    }

    private void Update() { 
	    if(_tetrisManagerObj.GameOver) return;

        if (Input.GetKeyDown(KeyCode.A)) {
            _gameFieldObj.MoveRigth();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            _gameFieldObj.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            _gameFieldObj.Drop(); 
        } 
        if (Input.GetKeyDown(KeyCode.W)) {
            _gameFieldObj.MoveDown(); 
        }
        if (Input.GetKeyDown(KeyCode.Q)) { 
            _gameFieldObj.RotateTetromino(); 
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            SetPause(!_tetrisManagerObj.Paused);
        } 
    }
}

/* 
 * SetScore(_tetrisManagerObj.Score += 5);
   public void ViewTiles() {
        for (int row = 0; row < _gameFieldObj.GridHeigth; row++) {
            for (int col = 0; col < _gameFieldObj.GridWidth; col++) {
                if (_gameFieldObj._tiles[row, col] != TileType.Empty && _gameFieldObj._tiles[row, col] != TileType.NoValue) {
                    Instantiate(tetrImage_test, new Vector3(col,row, 0), Quaternion.identity);
                }
            } 
        }
    }
    
    if (_tetrisManagerObj.TetrominesDropped % 15 == 0 && _tetrisManagerObj.Score != 0) {
        if (gameSpeed > 0.4f) {
            gameSpeed -= 0.1f;
        }
    } 
     */
