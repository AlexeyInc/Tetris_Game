using System; 

namespace TetrisLibrary {

    public class FigureS : Figure {

        private int[][,] _arraysS;

        public FigureS(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysS = new int[2][,];

            _arraysS[0] = new int[,] {
                { 1, 0, 0, },
                { 1, 1, 0, },
                { 0, 1, 0  }
            };
            _arraysS[1] = new int[,] { 
                { 0, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
        }

        protected override int[][,] Arrays {
            get { return _arraysS; }
        }

        public override Figure Clone() {
            Figure f = new FigureS(this.curIndex, this.color);
            return f;
        }
    }
}
