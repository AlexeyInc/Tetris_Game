using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TetrisLibrary {

    public enum CellColor { Default, Red, Green, Yellow, Blue, Pink, Purple, Orange, NoValue };

    public class Board {

        public static int BoardHeigth { get; private set; }
        public static int BoardWidth { get; private set; }
         
        protected int _shiftRow;
        protected int _shiftCol;

        protected static CellColor[,] board;
         
        public Board(int heigth, int width) {
            BoardHeigth = heigth;
            BoardWidth = width;

            _shiftCol = BoardWidth / 2 - 1;
            _shiftRow = 0;

            board = new CellColor[BoardHeigth, BoardWidth];
            Clear();
        }

        /// <summary>
        /// Удаляет заполненные ряды и поля со смещением всех лежащих выше вниз
        /// </summary>
        /// <returns>Количество уничтоженных ячеек</returns>
        public int RemoveFullRows(ref List<int> listFullRows) { 

            for (int row = 0; row < BoardHeigth; row++) {

                bool fullrow = true;
                for (int col = 0; col < BoardWidth; col++) {
                    if (board[row, col] == CellColor.Default) {
                        fullrow = false;
                        break;
                    }
                }

                if (fullrow) listFullRows.Add(row);
            }

            foreach (int fullRow in listFullRows) {
                for (int row = fullRow - 1; row > 0; row--) {
                    for (int col = 0; col < BoardWidth; col++) {

                        board[row + 1, col] = board[row, col];

                        if (IsRowEmpty(row + 1))
                            break;
                    }
                }
            }

            return BoardWidth * listFullRows.Count;
        }

        private bool IsRowEmpty(int row) {
            for (int col = 0; col < BoardWidth; col++) {
                if (board[row, col] != CellColor.Default)
                    return false;
            }
            return true;
        }

        protected bool IsCellEqual(int row, int col, CellColor color) {
            try {
                if (board[row, col] == color)
                    return true;
                else
                    return false;
            } catch (IndexOutOfRangeException) {
                return false;
            }
        }

        /// <summary>
		/// Возвращает цвет конкретной клетки на поле
		/// </summary> 
        public static CellColor GetBoardCell(int row, int col) {
            if (row < BoardHeigth && col < BoardWidth) {
                return board[row, col]; 
            } else {
                return CellColor.NoValue;
            }
        }

        /// <summary>
		/// Уичищает игровое поле, устанавливая цвет всех клеток по-умолчанию
		/// </summary> 
        public virtual void Clear() {
            for (int row = 0; row < BoardHeigth; row++) {
                for (int col = 0; col < BoardWidth; col++) {
                    board[row, col] = CellColor.Default;
                }
            }
        }
    }
}
