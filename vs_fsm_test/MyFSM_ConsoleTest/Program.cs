using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace MyFSM_ConsoleTest {

    delegate void MenuStateHandler();

    class Program {

        public static List<MenuStateHandler> listConsoleMenu = new List<MenuStateHandler>();

        static void Main(string[] args) {

        #region Add menu states
            Program.listConsoleMenu.Add(MainMenu);
            Program.listConsoleMenu.Add(GameMenu);
            Program.listConsoleMenu.Add(HelpMenu);
            Program.listConsoleMenu.Add(RulesMenu);
            Program.listConsoleMenu.Add(AboutMenu);
            Program.listConsoleMenu.Add(NewGameMenu);
            Program.listConsoleMenu.Add(ExitMenu);
        #endregion

            Controller.Instance.ChangeUIState += ChangeStateMenu;
            Controller.Instance.ActiveFSM();

            string val = "";
            do {
                Controller.Instance.ChangeScenario(val);

                Console.WriteLine("Для выхода введите close.");
                val = Console.ReadLine();
            } while (val != "close");
        }

        static void ChangeStateMenu(int indx, bool value) {
            if (value) {
                listConsoleMenu[indx]();
            } else {
                OffCurrentState(listConsoleMenu[indx].Method.ToString().Split(' ').Last()); 
            }
        }

        static void MainMenu() {
            Console.WriteLine("Мы в главном меню, выберите куда идти:");
            Console.WriteLine("Game\nHelp");
            Console.WriteLine("------------------");
        }

        static void GameMenu() {
            Console.WriteLine("Мы в меню игры, выберите куда идти:");
            Console.WriteLine("New_Game\nExit");
            Console.WriteLine("Назад_(MainMenu)");
            Console.WriteLine("------------------");

        }

        static void HelpMenu() {
            Console.WriteLine("Мы в меню помощи, выберите куда идти:");
            Console.WriteLine("Rules_(gamerules)\nAbout_(about)");
            Console.WriteLine("Назад_(MainMenu)");
            Console.WriteLine("------------------");
        }

        static void RulesMenu() {
            Console.WriteLine("Мы в меню правил");
            Console.WriteLine("Назад_(Help)");
            Console.WriteLine("------------------");
        }

        static void AboutMenu() {
            Console.WriteLine("Мы в меню об разработчике");
            Console.WriteLine("Назад_(Help)");
            Console.WriteLine("------------------");
        }

        static void NewGameMenu() {
            Console.Clear();
            Console.WriteLine("Мы начали новую игру");
            Console.WriteLine("Вернуться в главное меню_(MainMenu)");
            Console.WriteLine("------------------");
        }
        static void ExitMenu() {
            Console.Clear();
            Console.WriteLine("Мы покинули игру");
            Console.WriteLine("Вернуться в главное меню_(MainMenu)");
            Console.WriteLine("------------------");
        }

        public static void OffCurrentState(string name) {
            Console.WriteLine($"--------------------------------\nМы покинули сотояние: '{name}'\n-------------------------------\n");
        }
    }
}
