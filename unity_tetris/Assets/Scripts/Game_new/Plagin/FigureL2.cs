using System; 

namespace TetrisLibrary {
    class FigureL2 : Figure {
        private int[][,] _arraysL2;

        public FigureL2(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysL2 = new int[4][,];

            _arraysL2[3] = new int[,] {
                { 0, 0, 1, },
                { 0, 0, 1, },
                { 0, 1, 1, }
            };
            _arraysL2[2] = new int[,] {
                { 0, 0, 0 },
                { 1, 0, 0 },
                { 1, 1, 1 }
            };

            _arraysL2[1] = new int[,] {
                { 1, 1, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 }
            };

            _arraysL2[0] = new int[,] {
                { 1, 1, 1 },
                { 0, 0, 1 },
                { 0, 0, 0 }
            };
        }

        protected override int[][,] Arrays {
            get {
                return _arraysL2;
            }
        }

        public override Figure Clone() {
            Figure f = new FigureL2(this.curIndex, this.color);
            return f;
        }
    }
}