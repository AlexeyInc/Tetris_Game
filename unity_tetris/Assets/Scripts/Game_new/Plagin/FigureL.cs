using System; 

namespace TetrisLibrary {

    class FigureL : Figure {
        private int[][,] _arraysL;

        public FigureL(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysL = new int[4][,];

            _arraysL[3] = new int[,] {
                { 1, 1, 1, },
                { 1, 0, 0, },
                { 0, 0, 0, }
            };
            _arraysL[2] = new int[,] {
                { 0, 1, 1 },
                { 0, 0, 1 },
                { 0, 0, 1 }
            };

            _arraysL[1] = new int[,] {
                { 0, 0, 0 },
                { 0, 0, 1 },
                { 1, 1, 1 }
            };

            _arraysL[0] = new int[,] {
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 1, 0 }
            }; 
        }

        protected override int[][,] Arrays {
            get {
                return _arraysL;
            }
        }

        public override Figure Clone() {
            Figure f = new FigureL(this.curIndex, this.color);
            return f;
        }
    }
}