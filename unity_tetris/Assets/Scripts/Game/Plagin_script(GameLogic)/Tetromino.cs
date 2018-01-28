using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris_library {
     
    public struct Tetromino {  

        public int[] arrPosX;
        public int[] arrPosY;

        public TileType type; 

        public static readonly Tetromino Zero = new Tetromino(TileType.Empty);

        public Tetromino(TileType type) : this() { 
            arrPosX = new int[4];
            arrPosY = new int[4];
             
            arrPosX[0] = 0; arrPosY[0] = 0; 
            this.type = type;

            if (this.type == TileType.White) {
                Debug.Log("Свершилось");
            }
            switch (this.type) {
                //##
                // ##
                case TileType.Red:
                    arrPosX[1] = -1; arrPosY[1] = 1;
                    arrPosX[2] = 0;  arrPosY[2] = 1;
                    arrPosX[3] = 1;  arrPosY[3] = 0;
                    break;
                // ##
                //##
                case TileType.White:
                    arrPosX[1] = -1; arrPosY[1] = 0;
                    arrPosX[2] = 0;  arrPosY[2] = 1;
                    arrPosX[3] = 1;  arrPosY[3] = 1; 
                    break;
                //####
                case TileType.Yellow:
                    arrPosX[1] = -1; arrPosY[1] = 0;
                    arrPosX[2] = 1;  arrPosY[2] = 0;
                    arrPosX[3] = 2;  arrPosY[3] = 0; 
                    break;
                //##
                //##
                case TileType.Orange:
                    arrPosX[1] = 1; arrPosY[1] = 0;
                    arrPosX[2] = 0; arrPosY[2] = 1;
                    arrPosX[3] = 1; arrPosY[3] = 1; 
                    break;
                //  #
                //###
                case TileType.Green:
                    arrPosX[1] = -1; arrPosY[1] = 0;
                    arrPosX[2] = 1; arrPosY[2] = 0;
                    arrPosX[3] = 1; arrPosY[3] = 1; 
                    break;
                //#  
                //###
                case TileType.Blue:
                    arrPosX[1] = -1; arrPosY[1] = 1;
                    arrPosX[2] = -1; arrPosY[2] = 0;
                    arrPosX[3] = 1;  arrPosY[3] = 0; 
                    break;
                // #
                //###
                case TileType.Purple:
                    arrPosX[1] = -1; arrPosY[1] = 0;
                    arrPosX[2] = 0;  arrPosY[2] = 1;
                    arrPosX[3] = 1;  arrPosY[3] = 0; 
                    break; 
                default:
                    for (int i = 0; i < 4; i++)
                        arrPosX[i] = arrPosY[i] = 0;
                    break;
            }
        }

        /// <summary>
        /// Перемещает фигуру в положение x=col, y=row
        /// </summary>
        /// <returns>Перемещённую фигуру</returns>
        public Tetromino MoveTo(int row, int col) {
            Tetromino resTetromino = new Tetromino(this.type);
            resTetromino.arrPosX[0] = col; resTetromino.arrPosY[0] = row;

            int dx = col - this.arrPosX[0], dy = row - this.arrPosY[0];
            resTetromino.arrPosX[1] = arrPosX[1] + dx; resTetromino.arrPosY[1] = arrPosY[1] + dy;
            resTetromino.arrPosX[2] = arrPosX[2] + dx; resTetromino.arrPosY[2] = arrPosY[2] + dy;
            resTetromino.arrPosX[3] = arrPosX[3] + dx; resTetromino.arrPosY[3] = arrPosY[3] + dy;

            return resTetromino;
        }
         
        /// <summary>
		/// Смещает фигуру вниз
		/// </summary>
		/// <returns>Смещённую фигуру</returns>
        public Tetromino MoveDown() {
            return MoveTo(arrPosY[0] + 1, arrPosX[0]); 
        }

        /// <summary>
        /// Смещает фигуру вверх
        /// </summary>
        /// <returns>Смещённую фигуру</returns>
        public Tetromino MoveUp() {
            return MoveTo(arrPosY[0] - 1, arrPosX[0]);
        }

        /// <summary>
		/// Смещает фигуру вправо
		/// </summary>
		/// <returns>Смещённую фигуру</returns>
		public Tetromino MoveRight() { 
            return MoveTo(arrPosY[0], arrPosX[0] + 1);
        }

        /// <summary>
        /// Смещает фигуру влево
        /// </summary>
        /// <returns>Смещённую фигуру</returns>
        public Tetromino MoveLeft() {
            return MoveTo(arrPosY[0], arrPosX[0] - 1);
        }

        /// <summary>
        /// Поворачивает фигуру
        /// </summary>
        /// <returns>Повернутую фигуру</returns>
        public Tetromino Rotate() {
            Tetromino resTetromino = Clone();

            resTetromino.arrPosX[1] = RotateRow(arrPosY[1]); resTetromino.arrPosY[1] = RotateCol(arrPosX[1]);
            resTetromino.arrPosX[2] = RotateRow(arrPosY[2]); resTetromino.arrPosY[2] = RotateCol(arrPosX[2]);
            resTetromino.arrPosX[3] = RotateRow(arrPosY[3]); resTetromino.arrPosY[3] = RotateCol(arrPosX[3]);

            return resTetromino;
        }

        int RotateRow(int row) {
            return arrPosX[0] - row + arrPosY[0];
        }

        int RotateCol(int col) {
            return arrPosY[0] - arrPosX[0] + col;
        }

        private Tetromino Clone() {
            Tetromino res = new Tetromino(this.type);
            res.arrPosX[0] = this.arrPosX[0]; res.arrPosY[0] = this.arrPosY[0];
            res.arrPosX[1] = this.arrPosX[1]; res.arrPosY[1] = this.arrPosY[1];
            res.arrPosX[2] = this.arrPosX[2]; res.arrPosY[2] = this.arrPosY[2];
            res.arrPosX[3] = this.arrPosX[3]; res.arrPosY[3] = this.arrPosY[3];
            return res;
        }

        /// <summary>
        /// Создает одну из семи фигур
        /// </summary>
        /// <returns>Случайную фигуру</returns>
        public static Tetromino RandomTetromino() {
            System.Random rand = new System.Random();
            TileType typeTetromino = (TileType)rand.Next(1,8);
            return new Tetromino(typeTetromino);
        }

        /// <summary>
        /// Сравнивает две фигуры
        /// </summary>
        /// <returns>true если фигуры равны, иначе - false</returns>
        public static bool operator ==(Tetromino t1, Tetromino t2) {
            return t1.type == t2.type && t1.arrPosX[0] == t2.arrPosX[0] && t1.arrPosY[0] == t2.arrPosY[0] &&
                t1.arrPosX[1] == t2.arrPosX[1] && t1.arrPosX[2] == t2.arrPosX[2] && t1.arrPosX[3] == t2.arrPosX[3] &&
                t1.arrPosY[1] == t2.arrPosY[1] && t1.arrPosY[2] == t2.arrPosY[2] && t1.arrPosY[3] == t2.arrPosY[3];
        }
        public static bool operator !=(Tetromino t1, Tetromino t2) {
            return !(t1 == t2);
        }
    }
}