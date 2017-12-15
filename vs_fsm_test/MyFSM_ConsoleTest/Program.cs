using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace MyFSM_ConsoleTest {

    delegate void MenuMethod();

    class Program {

        public static List<MenuMethod> listConsoleMenu = new List<MenuMethod>();

        static void Main(string[] args) {
            Program.listConsoleMenu.Add(OnMainMenu);
            Program.listConsoleMenu.Add(OnGameMenu);
            Program.listConsoleMenu.Add(OnHelpMenu);
            Program.listConsoleMenu.Add(OnRulesMenu);
            Program.listConsoleMenu.Add(OnAboutMenu);
            Program.listConsoleMenu.Add(OnNewGameMenu);
            Program.listConsoleMenu.Add(OnExitMenu);

            int val = 0;
            do {
                Controller.Instance.ChangeScenario(val);

                Console.WriteLine("Для выхода введите 420.");
                val = int.Parse(Console.ReadLine());
            } while (val != 420);
        }

        static void OnMainMenu() {
            Console.WriteLine("Мы в главном меню, выберите куда идти:");
            Console.WriteLine("Game_1\nHelp_2");
            Console.WriteLine("------------------");
        }

        static void OnGameMenu() {
            Console.WriteLine("Мы в меню игры, выберите куда идти:");
            Console.WriteLine("New_Game_5\nExit_6");
            Console.WriteLine("Назад_0");
            Console.WriteLine("------------------");

        }

        static void OnHelpMenu() {
            Console.WriteLine("Мы в меню помощи, выберите куда идти:");
            Console.WriteLine("Rules_3\nAbout_4");
            Console.WriteLine("Назад_0");
            Console.WriteLine("------------------");
        }

        static void OnRulesMenu() {
            Console.WriteLine("Мы в меню правил");
            Console.WriteLine("Назад_2");
            Console.WriteLine("------------------");
        }

        static void OnAboutMenu() {
            Console.WriteLine("Мы в меню об разработчике");
            Console.WriteLine("Назад_2");
            Console.WriteLine("------------------");
        }

        static void OnNewGameMenu() {
            Console.Clear();
            Console.WriteLine("Мы начали новую игру");
            Console.WriteLine("Вернуться в главное меню_0");
            Console.WriteLine("------------------");
        }
        static void OnExitMenu() {
            Console.Clear();
            Console.WriteLine("Мы покинули игру");
            Console.WriteLine("Вернуться в главное меню_0");
            Console.WriteLine("------------------");
        }

        public static void OffCurrentState(string name) {
            Console.WriteLine($"--------------------------------\nМы покинули сотояние: '{name}'\n----------------------------\n");
        }
    }
}
