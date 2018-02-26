using System; 

namespace TetrisLibrary {

     public abstract class Figure {

        protected abstract int[][,] Arrays { get; }
        public abstract Figure Clone();

        protected int curIndex; 
        protected CellColor color;

        /// <summary>
        /// Возвращает высоту фигуры
        /// </summary>
        /// <>
        public int FigureHeigth {
            get {
                return Arrays[curIndex].GetLength(0);
            }
        }

        /// <summary>
        /// Возвращает ширину фигуры
        /// </summary>
        public int FigureWidth {
            get {
                return Arrays[curIndex].GetLength(1);
            }
        }

        /// <summary>
        /// Возвращает текущую фигуру
        /// </summary>
        public int[,] GetCurrentFigure() {
            return Arrays[curIndex];
        }

        /// <summary>
        /// Возвращает цвет фигуры
        /// </summary>
        public CellColor Color {
            get {
                return color;
            }
        }

        /// <summary>
        /// Вращает фигуру с помощью смены индекса в массиве фигур
        /// </summary>
        public void RotateFigure() {
            curIndex = curIndex == Arrays.Length - 1 ? 0 : ++curIndex;  
        }

        /// <summary>
        /// Классика жанра
        /// </summary>
        public int this[int row, int col] {
            get {
                try { 
                    return Arrays[curIndex][row, col];
                } catch (IndexOutOfRangeException) { 
                    return 0;
                }
            }
        } 
    }
}
