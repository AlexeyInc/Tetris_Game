using System; 

namespace TetrisLibrary {

    public class FigureI : Figure {

        private int[][,] _arraysI;

        public FigureI(int turnIndex, CellColor color) {
            this.curIndex = turnIndex;
            this.color = color;

            _arraysI = new int[2][,];

            _arraysI[0] = new int[,] {
                { 0, 1, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 1, 0, 0 }
            };
            _arraysI[1] = new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 0 } 
            };
        }

        protected override int[][,] Arrays {
            get { return _arraysI; }
        }

        public override Figure Clone() {
            Figure f = new FigureI(this.curIndex, this.color);
            return f;
        }
    }
}
