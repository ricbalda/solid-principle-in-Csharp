using System;
using System.Collections.Generic;

namespace SOLID101
{
    /// <summary>
    /// Sistema de menú interactivo con navegación por flechas.
    /// Permite seleccionar entre diferentes principios SOLID y submódulos.
    /// </summary>
    public class MenuSystem
    {
        private int currentMenuLevel = 0; // 0 = menú principal, 1 = submenú
        private int selectedOptionMain = 0;
        private int selectedOptionSub = 0;
        private bool running = true;

        private readonly List<MenuItem> mainMenuItems = new()
        {
            new MenuItem("SRP - Single Responsibility Principle", "Una clase debe tener una única razón para cambiar"),
            new MenuItem("OCP - Open/Closed Principle", "Abierto para extensión, cerrado para modificación"),
            new MenuItem("LSP - Liskov Substitution Principle", "Las subclases deben poder sustituir a sus clases base"),
            new MenuItem("ISP - Interface Segregation Principle", "Los clientes no deben depender de interfaces que no usan"),
            new MenuItem("DIP - Dependency Inversion Principle", "Depender de abstracciones, no de concreciones"),
            new MenuItem("Salir", "Terminar la aplicación")
        };

        private readonly List<MenuItem> subMenuItems = new()
        {
            new MenuItem("Ver Descripción", "Muestra información detallada del principio"),
            new MenuItem("Ejecutar Demo", "Ejecuta una demostración práctica"),
            new MenuItem("Volver", "Regresa al menú principal")
        };

        public void Run()
        {
            while (running)
            {
                ClearScreen();
                
                if (currentMenuLevel == 0)
                {
                    DisplayMainMenu();
                    HandleMainMenuInput();
                }
                else if (currentMenuLevel == 1)
                {
                    DisplaySubMenu(selectedOptionMain);
                    HandleSubMenuInput();
                }
            }

            ClearScreen();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("           ¡Gracias por usar el Menú SOLID 101!");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           EJEMPLOS DE PRINCIPIOS SOLID EN C#              ║");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("║  Navegación: ↑↓ Arriba/Abajo | Enter: Seleccionar        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            for (int i = 0; i < mainMenuItems.Count; i++)
            {
                string prefix = selectedOptionMain == i ? "➤ " : "  ";
                string highlight = selectedOptionMain == i ? "\x1b[32;1m" : "";
                string reset = selectedOptionMain == i ? "\x1b[0m" : "";

                Console.WriteLine($"{prefix}{highlight}[{i + 1}] {mainMenuItems[i].Title}{reset}");
            }

            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
        }

        private void DisplaySubMenu(int principleIndex)
        {
            var principle = mainMenuItems[principleIndex];

            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  {principle.Title,-57}║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.WriteLine("📋 DESCRIPCIÓN:");
            Console.WriteLine(principle.Description);
            Console.WriteLine();
            
            Console.WriteLine("OPCIONES:");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            for (int i = 0; i < subMenuItems.Count; i++)
            {
                string prefix = selectedOptionSub == i ? "➤ " : "  ";
                string highlight = selectedOptionSub == i ? "\x1b[32;1m" : "";
                string reset = selectedOptionSub == i ? "\x1b[0m" : "";

                Console.WriteLine($"{prefix}{highlight}[{i + 1}] {subMenuItems[i].Title}{reset}");
            }

            Console.WriteLine();
            Console.WriteLine("Navegación: ↑↓ Arriba/Abajo | Enter: Seleccionar");
            Console.WriteLine("─────────────────────────────────────────────────────────────");
        }

        private void HandleMainMenuInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedOptionMain = (selectedOptionMain - 1 + mainMenuItems.Count) % mainMenuItems.Count;
                    break;

                case ConsoleKey.DownArrow:
                    selectedOptionMain = (selectedOptionMain + 1) % mainMenuItems.Count;
                    break;

                case ConsoleKey.Enter:
                    if (selectedOptionMain == mainMenuItems.Count - 1)
                    {
                        running = false;
                    }
                    else
                    {
                        currentMenuLevel = 1;
                        selectedOptionSub = 0;
                    }
                    break;
            }
        }

        private void HandleSubMenuInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedOptionSub = (selectedOptionSub - 1 + subMenuItems.Count) % subMenuItems.Count;
                    break;

                case ConsoleKey.DownArrow:
                    selectedOptionSub = (selectedOptionSub + 1) % subMenuItems.Count;
                    break;

                case ConsoleKey.Enter:
                    ExecuteSubMenuAction();
                    break;
            }
        }

        private void ExecuteSubMenuAction()
        {
            ClearScreen();

            switch (selectedOptionSub)
            {
                case 0: // Ver Descripción
                    DisplayPrincipleDetails(selectedOptionMain);
                    break;

                case 1: // Ejecutar Demo
                    DemoRunner.RunDemo(selectedOptionMain);
                    break;

                case 2: // Volver
                    currentMenuLevel = 0;
                    selectedOptionSub = 0;
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("Presiona cualquier tecla para volver al submenú...");
            Console.ReadKey(true);
            selectedOptionSub = 0;
        }

        private void DisplayPrincipleDetails(int principleIndex)
        {
            PrincipleDescriptions.DisplayDetails(principleIndex);
        }

        private void ClearScreen()
        {
            Console.Clear();
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public MenuItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
