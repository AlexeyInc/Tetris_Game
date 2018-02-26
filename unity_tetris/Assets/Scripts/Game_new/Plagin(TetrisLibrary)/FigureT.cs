using System; 

namespace TetrisLibrary {
    class FigureT : Figure {
        private int[][,] _arraysT;

        public FigureT(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysT = new int[4][,];

            _arraysT[3] = new int[,] {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 1, 1, 1 }
            };
            _arraysT[2] = new int[,] {
                { 1, 0, 0 },
                { 1, 1, 0 },
                { 1, 0, 0 }
            };

            _arraysT[1] = new int[,] {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            _arraysT[0] = new int[,] {
                { 0, 0, 1},
                { 0, 1, 1},
                { 0, 0, 1}
            };
        }

        protected override int[][,] Arrays {
            get {
                return _arraysT;
            }
        }

        public override Figure Clone() {
            Figure f = new FigureT(this.curIndex, this.color);
            return f;
        }
    }
}
