using UnityEngine;
using TetrisLibrary;

class GameView {

    private MeshRenderer[,] _figuresMaterial;
    private MeshRenderer[,] _previewFigureMesh; 

    private Material[] _figureColors;
       
    public GameView(GameObject[,] figuresStorage, GameObject[,] previewFigureStorage, Material[] figureColors) {

        InitComponents(figuresStorage, previewFigureStorage, figureColors);   
    }

    private void InitComponents(GameObject[,] fStorage, GameObject[,] preview_fStorage, Material[] fColors) {
        _figuresMaterial = new MeshRenderer[fStorage.GetLength(0), fStorage.GetLength(1)];
        _previewFigureMesh = new MeshRenderer[preview_fStorage.GetLength(0), preview_fStorage.GetLength(1)]; 

        for (int row = 0; row < _figuresMaterial.GetLength(0); row++) {
            for (int col = 0; col < _figuresMaterial.GetLength(1); col++) {
                _figuresMaterial[row, col] = fStorage[row, col].GetComponent<MeshRenderer>();
            }
        }

        for (int row = 0; row < _previewFigureMesh.GetLength(0); row++) {
            for (int col = 0; col < _previewFigureMesh.GetLength(1); col++) {
                _previewFigureMesh[row, col] = preview_fStorage[row, col].GetComponent<MeshRenderer>();
            }
        }

        _figureColors = fColors;
    }
     
    public void ViewBoard() { 
        for (int row = 0; row < Board.BoardHeigth; row++) {
            for (int col = 0; col < Board.BoardWidth; col++) {
                _figuresMaterial[row, col].material = GetFigureColor(Board.GetBoardCell(row, col));
            }
        }
    }

    public void PreviewNextFigure(Figure fClone) {
        Figure nextFigure = fClone; 

        for (int row = 0; row < _previewFigureMesh.GetLength(0); row++) {
            for (int col = 0; col < _previewFigureMesh.GetLength(1); col++) {
                _previewFigureMesh[row, col].enabled = false;
            }
        }

        if (nextFigure != null) {
            for (int row = 0; row < nextFigure.FigureHeigth; row++) {
                for (int col = 0; col < nextFigure.FigureWidth; col++) {
                    if (nextFigure[row, col] != 0) {
                        _previewFigureMesh[col, row].material = GetFigureColor(nextFigure.Color);
                        _previewFigureMesh[col, row].enabled = true;
                    }
                }
            }
        }
    }

    public Material GetFigureColor(CellColor color) {//change to private
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
