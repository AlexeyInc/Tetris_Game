using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris_library {

    public enum TileType { Empty, Red, Green, Blue, Yellow, Orange, Purple, White, NoValue }
      
    public class Grid {
        public int GridHeigth { get; private set; }
        public int GridWidth { get; private set; }

        public TileType[,] _tiles;//сдлеать приватным

        public TileType this[int row, int col] {
            get {
                try {
                    return _tiles[row, col];
                } catch (IndexOutOfRangeException) { 
                    return TileType.NoValue; 
                }
            }
        }

        public Grid(int heigth, int width) {
            this.GridHeigth = heigth;
            this.GridWidth = width;

            _tiles = new TileType[this.GridHeigth, this.GridWidth]; 

            for (int row = 0; row < GridHeigth; row++) {
                for (int col = 0; col < GridWidth; col++) {
                    _tiles[row, col] = TileType.Empty;
                }
            }
        }

        //======[ Модификация ячеек ]====

        public bool SetCell(int row, int col, TileType type) {
            try {
                _tiles[row, col] = type;
                return true;
            } catch (IndexOutOfRangeException) {
                return false;
            }
        }

        ///<summary>
        ///Помещает фигуру t на поле _tiles
        ///</summary>
        ///<returns>Количество клеток фигуры, которые удалось поместить на поле</returns>
        public int SetTetromino(Tetromino t, bool rewrite) {
            int res = 4; 

            try {
                if (_tiles[t.arrPosY[0], t.arrPosX[0]] == TileType.Empty || rewrite) {
                    _tiles[t.arrPosY[0], t.arrPosX[0]] = t.type;
                } else {
                    --res;
                }
            } catch (IndexOutOfRangeException) {
                --res;
            }

            try {
                if (_tiles[t.arrPosY[1], t.arrPosX[1]] == TileType.Empty || rewrite) {
                    _tiles[t.arrPosY[1], t.arrPosX[1]] = t.type;
                } else {
                    --res;
                }
            } catch (IndexOutOfRangeException) {
                --res;
            }

            try {
                if (_tiles[t.arrPosY[2], t.arrPosX[2]] == TileType.Empty || rewrite) {
                    _tiles[t.arrPosY[2], t.arrPosX[2]] = t.type;
                } else {
                    --res;
                }
            } catch (IndexOutOfRangeException) {
                --res;
            }

            try {
                if (_tiles[t.arrPosY[3], t.arrPosX[3]] == TileType.Empty || rewrite) {
                    _tiles[t.arrPosY[3], t.arrPosX[3]] = t.type;
                } else {
                    --res;
                }
            } catch (IndexOutOfRangeException) {
                --res;
            }

            return res;
        }

        ///<summary>
        ///Проверяет свободны ли клетки на поле
        ///</summary>
        ///<returns>Свобдны ли клетки фигуры передаваемой в качестве параметре</returns>
        public bool IsEmpty(Tetromino t) { 
            if (this[t.arrPosY[0], t.arrPosX[0]] != TileType.Empty) return false;
            if (this[t.arrPosY[1], t.arrPosX[1]] != TileType.Empty) return false;
            if (this[t.arrPosY[2], t.arrPosX[2]] != TileType.Empty) return false;
            if (this[t.arrPosY[3], t.arrPosX[3]] != TileType.Empty) return false;
            return true;
        }

        ///<summary>
        ///Проверяет свободна ли конкретная клетка на поле
        ///</summary>
        ///<returns>Состояние клетки</returns>
        public bool IsEmpty(int row, int col) {
            if (this[row, col] != TileType.Empty) return false;
            return true;
        }

        protected void EraseTetromino(Tetromino t) {
            t.type = TileType.Empty;
            SetTetromino(t, true);
        }

        /// <summary>
		/// Осуществляет сдвиг выбранной ячейки вниз, если это возможно
		/// </summary>
		/// <param name="row">Строка</param>
		/// <param name="col">Столбец</param>
		/// <returns>Возможность дальнейшего сдвига</returns>
        protected bool MoveDown(int row, int col) {
            if (_tiles[row, col] != TileType.Empty) {

                if (_tiles[row + 1, col] == TileType.Empty) {
                    _tiles[row + 1, col] = _tiles[row, col];
                    _tiles[row, col] = TileType.Empty;
                }
                return _tiles[row + 2, col] == TileType.Empty;//still can move it down
            }
            return false;
        }

        /// <summary>
		/// Передвигает совокупность ячеек вниз
		/// </summary>
		/// <param name="t">tetromino - several cell</param>
		/// <returns>Успех сдвига</returns>
        protected bool MoveDown(Tetromino t) { 
            Tetromino tLower = t.MoveDown(); 
            t.type = TileType.Empty;
            SetTetromino(t, true);

            if (IsEmpty(tLower)) {
                //Debug.Log("Can move down"); 
                SetTetromino(tLower, false);
                 
                return true;
            } 
            t.type = tLower.type;
            SetTetromino(t, false); 

            return false;
        }
         
        /// <summary>
		/// Осуществляет сдвиг выбранной ячейки вправо, если это возможно
		/// </summary>
		/// <param name="row">Строка</param>
		/// <param name="col">Столбец</param>
		/// <returns>Возможность дальнейшего сдвига</returns>
        protected bool MoveRigth(int row, int col) { 
            if (_tiles[row, col] != TileType.Empty) {
                if (_tiles[row, col + 1] == TileType.Empty) {
                    _tiles[row, col + 1] = _tiles[row, col];
                    _tiles[row, col] = TileType.Empty;

                    return _tiles[row, col + 1] == TileType.Empty;
                }
            }
            return false;
        }

        /// <summary>
		/// Передвигает совокупность ячеек вправо
		/// </summary>
		/// <param name="f">Фигура - совокупность ячеек</param>
		/// <returns>Успешность сдвига</returns>
        protected bool MoveRight(Tetromino t) {
            Tetromino moved = t.MoveRight();

            t.type = TileType.Empty;
            SetTetromino(t, true);

            if (IsEmpty(moved)) {
                SetTetromino(moved, false);

                return true;
            }

            t.type = moved.type;
            SetTetromino(t, false);

            return false;
        }
         
        /// <summary>
		/// Осуществляет сдвиг выбранной ячейки влево, если это возможно
		/// </summary>
		/// <param name="row">Строка</param>
		/// <param name="col">Столбец</param>
		/// <returns>Возможность дальнейшего сдвига</returns>
        protected bool MoveLeft(int row, int col) { 
            if (_tiles[row, col] != TileType.Empty) {
                if (_tiles[row, col - 1] == TileType.Empty) {
                    _tiles[row, col - 1] = _tiles[row, col];
                    _tiles[row, col] = TileType.Empty;
                }
                return _tiles[row, col - 1] == TileType.Empty; 
            }
            return false;
        }

        /// <summary>
		/// Передвигает совокупность ячеек влево
		/// </summary>
		/// <param name="f">Фигура - совокупность ячеек</param>
		/// <returns>Успешность сдвига</returns>
        protected bool MoveLeft(Tetromino t) {
            Tetromino moved = t.MoveLeft();

            t.type = TileType.Empty;
            SetTetromino(t, true);

            if (IsEmpty(moved)) {
                SetTetromino(moved, false);

                return true;
            }

            t.type = moved.type;
            SetTetromino(t, false);

            return false;
        }
          
        protected Tetromino RotateTetromino(Tetromino t) {
            if (t.type == TileType.Orange) return Tetromino.Zero;//kostyl for can't rotate square

            Tetromino rotated = t.Rotate(),
                      rotated2; 

            t.type = TileType.Empty;
            SetTetromino(t, true);
            t.type = rotated.type;

            if (IsEmpty(rotated)) {
                SetTetromino(rotated, false);
                return rotated;
            }

            rotated2 = rotated.MoveDown();
            if (IsEmpty(rotated2)) {
                SetTetromino(rotated2, false);
                return rotated2;
            }

            rotated2 = rotated.MoveLeft();
            if (IsEmpty(rotated2)) {
                SetTetromino(rotated2, false);
                return rotated2;
            }

            rotated2 = rotated.MoveRight();
            if (IsEmpty(rotated2)) {
                SetTetromino(rotated2, false);
                return rotated2;
            }

            //if any variant don't help
            SetTetromino(t, false); 
            return Tetromino.Zero;
        }

        /// <summary>
		/// Удаляет заполненные ряды и поля со смещением всех лежащих выше вниз
		/// </summary>
		/// <returns>Количество уничтоженных ячеек</returns>
        public int RemoveFullRows() {
            List<int> listFullRows = new List<int>();

            for (int row = 0; row < GridHeigth; row++) {

                bool fullrow = true;
                for (int col = 0; col < GridWidth; col++) {
                    if (_tiles[row, col] == TileType.Empty) {
                        fullrow = false;
                        break;
                    }
                }

                if (fullrow) listFullRows.Add(row);
            }

            foreach (int fullRow in listFullRows) {
                for (int row = fullRow - 1; row > 0; row--) {
                    for (int col = 0; col < GridWidth; col++) {

                        _tiles[row + 1, col] = _tiles[row, col];

                        if (IsRowEmpty(row + 1))
                            break;
                    }
                }
            }

            return GridWidth * listFullRows.Count;
        }

        private bool IsRowEmpty(int row) {
            for (int col = 0; col < GridWidth; col++) {
                if (_tiles[row, col] != TileType.Empty)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Заполняет игровое поле дефолтными значениями
        /// </summary>
        public virtual void Clear() {
            for (int row = 0; row < GridHeigth; row++) {
                for (int col = 0; col < GridWidth; col++) {
                    SetCell(row, col, TileType.Empty);
                }
            }
        }
    }
}
