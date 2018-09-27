# MyTetris_Game 

- The main folder **unity_tetris** contains the implementation of the classic Tetris game using Unity.

- The **vs_frm** folder contains the code that implements [Finite-state machine](https://en.wikipedia.org/wiki/Finite-state_machine) for the UI menu. (included to project by `using TetrisLibrary;`)
This part of the architecture included in MVC pattern, so  it makes easy to add and switch between the menu windows in the application (each window is state of the machine),
Such architecture allows to use this menu-plagin on any platform, whether it's Console, WPF or Xamarin application.

- In the folder **vs_fsm_test** there is an FSM testing code in the console application.
 

Game architecture is implemented in such a way that each figure in Tetris derived from the abstract base class `Figure`,
which contains the basic properties necessary to manage the figure on the game grid. 
Thus, it is easy to add any new figures of arbitrary shape.
