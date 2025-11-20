using System;
using ZoologicoVirtual.UI;

namespace ZoologicoVirtual
{
    /// <summary>
    /// Punto de entrada principal de la aplicación
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Configurar consola para UTF-8 (emojis)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Crear e iniciar el menú principal
            MenuManager menu = new MenuManager();
            menu.MostrarMenuPrincipal();
        }
    }
}