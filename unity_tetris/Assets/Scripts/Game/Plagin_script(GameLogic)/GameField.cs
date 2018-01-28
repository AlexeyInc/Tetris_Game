using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris_library {

    class GameField : Grid { 

        public Tetromino Current; 

        public bool IsFalling { get; private set; }

        public GameField(int heigth, int width) : base(heigth, width) { 
            Current = Tetromino.RandomTetromino();
            PlaceTetromino(Current);
            IsFalling = true;
        }

        /// <summary>
		/// Помещает новую фигуру на верх поля
		/// </summary>
		/// <param name="t">Новая фигура</param>
		/// <returns>true, если фигуру удалось полностью поместить на поле, иначе - false</returns>
        public bool PlaceTetromino(Tetromino t) { 
            t = t.MoveTo(0, GridWidth / 2 - 1);
            Current = t;

            int count = SetTetromino(t, false);
            //if (count != 4) {
            //    return false;
            //}
            //IsFalling = true;
            //return true;
            IsFalling = (count == 4);
            return IsFalling;
        }  

        /// <summary>
		/// Поворачивает текущую фигуру по часовой стрелке
		/// </summary>
		/// <returns>true в случае успеха, иначе - false</returns>
        public bool RotateTetromino() {
            
            if (Current == Tetromino.Zero) return false;
             
            Tetromino t = RotateTetromino(Current);
             
            if (t != Tetromino.Zero) {
                Current = t;
                return true;
            }
            return false;
        }

        /// <summary>
		/// Смещает фигуру влево
		/// </summary>
		/// <returns>true в случае успеха и false - в случае неудачи</returns>
        public bool MoveLeft() {
            if (Current == Tetromino.Zero) return false;

            if (MoveLeft(Current)) {
                Current = Current.MoveLeft();
                return true;
            }
            return false;
        }

        /// <summary>
		/// Смещает фигуру вправо
		/// </summary>
		/// <returns>true в случае успеха и false - в случае неудачи</returns>
        public bool MoveRigth() {
            if (Current == Tetromino.Zero) return false;

            if (MoveRight(Current)) {
                Current = Current.MoveRight();
                return true;
            }
            return false;
        }

        /// <summary>
		/// Смещает фигуру вниз
		/// </summary>
		/// <returns>true в случае успеха и false - в случае неудачи</returns>
        public bool MoveDown() {
            if (Current == Tetromino.Zero) return false;
            if (MoveDown(Current)) {
                Current = Current.MoveDown();
                return true;
            }
            return false;
        }

        /// <summary>
		/// Смещает фигуру вниз до предела
		/// </summary>
		/// <returns>true в случае успеха и false - в случае неудачи</returns>
        public bool Drop() {
            if (Current == Tetromino.Zero) return false;

            while (Current != Tetromino.Zero) {
                DoStep();
            }
            return true;
        }

        /// <summary>
        /// Смещает фигуру вниз на одну позицию если это возможно, иначе - останавливает падение
        /// </summary> 
        public void DoStep() {
            if (Current != Tetromino.Zero) {
                 
                IsFalling = MoveDown(Current);
                if (IsFalling) { 
                    Current = Current.MoveDown(); 

                } else {
                    Current = Tetromino.Zero;
                } 
            } else { 
                IsFalling = false;
            }
        }

        public override void Clear() {
            base.Clear();

            IsFalling = false;
            Current = Tetromino.Zero;
        }
    }
} 