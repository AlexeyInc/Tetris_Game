# Tetris_Game 

- The main folder **unity_tetris** contains the implementation of the classic Tetris game using Unity.

- The **vs_frm** folder contains the code that implements [Finite-state machine](https://en.wikipedia.org/wiki/Finite-state_machine) for the UI menu. 

This part of the architecture included in MVC pattern, so  it makes easy to add and switch between the menu windows in the application (each window is state of the machine),
Such architecture allows to use this menu-plagin on any platform, whether it's Console, WPF or Xamarin application.
(included to project by `using TetrisLibrary;`)

- In the folder **vs_fsm_test** there is an FSM testing code in the console application.
 

Game architecture is implemented in such a way that each figure in Tetris derived from the abstract base class `Figure`,
which contains the basic properties necessary to manage the figure on the game grid. 
Thus, it is easy to add any new figures of arbitrary shape.

>Menu view
![image](https://user-images.githubusercontent.com/29926552/46169029-b0b5e000-c2a2-11e8-9379-5e9eff089faa.png)
![image](https://user-images.githubusercontent.com/29926552/46168916-6cc2db00-c2a2-11e8-8e1b-1268f189955a.png)
![image](https://user-images.githubusercontent.com/29926552/46168959-8401c880-c2a2-11e8-84cc-9e214511de4f.png)

>Game view
![tetris](https://user-images.githubusercontent.com/29926552/46169853-e1971480-c2a4-11e8-8e01-6860d89cc9da.gif)
