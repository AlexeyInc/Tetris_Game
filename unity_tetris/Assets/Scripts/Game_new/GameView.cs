using UnityEngine;
using TetrisLibrary;

class GameView {

    private GameObject[,] _figuresStorage;
    private GameObject[,] _previewFigureStorage;

    private Material[] _figureColors;
       
    public GameView(GameObject[,] figuresStorage, 
                    GameObject[,] previewFigureStorage,  
                    Material[] figureColors
            ) {
        _figuresStorage = figuresStorage;
        _previewFigureStorage = previewFigureStorage; 
        _figureColors = figureColors;
    }


    public void ViewBoard() { 
        for (int row = 0; row < Board.BoardHeigth; row++) {
            for (int col = 0; col < Board.BoardWidth; col++) {
                _figuresStorage[row, col].GetComponent<MeshRenderer>().material = GetFigureColor(Board.GetBoardCell(row, col)); 
            }
        }
    }

    public void PreviewNextFigure(Figure fClone) {
        Figure nextFigure = fClone;

        for (int row = 0; row < _previewFigureStorage.GetLength(0); row++) {
            for (int col = 0; col < _previewFigureStorage.GetLength(1); col++) {
                _previewFigureStorage[row, col].SetActive(false);
            }
        }

        if (nextFigure != null) {
            for (int row = 0; row < nextFigure.FigureHeigth; row++) {
                for (int col = 0; col < nextFigure.FigureWidth; col++) {
                    if (nextFigure[row, col] != 0) {
                        _previewFigureStorage[col, row].GetComponent<MeshRenderer>().material = GetFigureColor(nextFigure.Color);
                        _previewFigureStorage[col, row].SetActive(true);
                    }
                }
            }
        } 
    }

    private Material GetFigureColor(CellColor color) {
        switch (color) {
            case CellColor.Default:
                return _figureColors[0];
            case CellColor.Red:
                return _figureColors[1];
            case CellColor.Green:
                return _figureColors[2];
            case CellColor.Yellow:
                return _figureColors[3];
            case CellColor.Blue:
                return _figureColors[4];
            case CellColor.Orange:
                return _figureColors[5];
            case CellColor.Purple:
                return _figureColors[6];
            case CellColor.Pink:
                return _figureColors[7];
            default:
                Debug.Log("Ни один из цветов не подошел.");
                return _figureColors[0]; 
        }
    }
}
