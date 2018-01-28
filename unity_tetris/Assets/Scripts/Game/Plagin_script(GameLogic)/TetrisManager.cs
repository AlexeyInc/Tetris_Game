using System;
using UnityEngine;

namespace Tetris_library {

    class TetrisManager {
        public Tetromino NextTetromino;

        private int _score, _tetrDropped;

        public int Score {
            get { return _score; }
            set { _score = value; }
        }

        public int TetrominesDropped {
            get { return _tetrDropped; }
            set {
                _tetrDropped = value;
                OnStateChanged();
            }
        }

        private bool _gameOver, _paused, _tetrChanged;

        public bool GameOver {
            get {
                return _gameOver;
            }
            set {
                _gameOver = value;
                OnStateChanged();
            }
        } 

        public bool Paused {
            get { return _paused; }
            set {
                if (!_paused && value) { 
                    _paused = value;
                    OnStateChanged();
                }
                if (_paused && !value) { 
                    _paused = value;
                    OnStateChanged();
                }
            }
        }

        public bool TetrominoChanged {
            get { return _tetrChanged; }
            set {
                _tetrChanged = value;
                OnStateChanged();
            }
        }
         
		public TetrisManager() {
            Score = 0;
            TetrominesDropped = 0;
            NextTetromino = Tetromino.RandomTetromino();
            GameOver = false;
            Paused = false;
            TetrominoChanged = false; 
        }
         
        public void Over() {
            GameOver = true;
        }

        public delegate void StateHandler();
        public event StateHandler StateChanged;
        protected virtual void OnStateChanged() {
            if (StateChanged != null) {
                StateChanged();
            }
        }
    }
}
