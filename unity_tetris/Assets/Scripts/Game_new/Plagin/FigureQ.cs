using System; 

namespace TetrisLibrary {
    class FigureQ : Figure {
        private int[][,] _arraysQ;

        public FigureQ(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysQ = new int[1][,];

            _arraysQ[0] = new int[,] { 
                { 1, 1},
                { 1, 1} 
            }; 
        }

        protected override int[][,] Arrays {
            get {
                return _arraysQ;
            }
        }

        public override Figure Clone() {
            Figure f = new FigureQ(this.curIndex, this.color);
            return f;
        }
    }
}
