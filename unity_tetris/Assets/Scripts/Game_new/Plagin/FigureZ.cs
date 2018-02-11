using System; 

namespace TetrisLibrary {
    public class FigureZ : Figure {

        private int[][,] _arraysZ;

        public FigureZ(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysZ = new int[2][,];

            _arraysZ[0] = new int[,] { 
                { 1, 1, 0, },
                { 0, 1, 1, },
                { 0, 0, 0, }
            };
            _arraysZ[1] = new int[,] {
                { 0, 0, 1 },
                { 0, 1, 1 },
                { 0, 1, 0 }
            };
        }

        protected override int[][,] Arrays {
            get {
                return _arraysZ;
            }
        }
         
        public override Figure Clone() {
            Figure f = new FigureZ(this.curIndex, this.color);
            return f;
        }
    }
}
