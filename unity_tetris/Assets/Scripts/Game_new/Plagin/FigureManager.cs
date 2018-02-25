using System; 

namespace TetrisLibrary {

    public class FigureManager {

         private Figure[] _arr;
        System.Random rand;

        public FigureManager() { 
            _arr = new Figure[] {
                new FigureI(0, CellColor.Green),
                new FigureZ(0, CellColor.Red),
                new FigureS(0, CellColor.Orange),
                new FigureQ(0, CellColor.Yellow),
                new FigureT(0, CellColor.Pink), 
                new FigureL(0, CellColor.Purple),
                new FigureL2(0, CellColor.Blue)
            };
            rand = new System.Random();
        }

        public Figure GetRandom() {
            return _arr[rand.Next(0, _arr.Length)];
        }
    }
}
