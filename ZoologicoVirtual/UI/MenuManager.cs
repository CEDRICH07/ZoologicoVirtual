using System;
using ZoologicoVirtual.Models;
using ZoologicoVirtual.Services;

namespace ZoologicoVirtual.UI
{
    /// <summary>
    /// Clase que maneja toda la interfaz de usuario
    /// Aplica el principio de Single Responsibility (SOLID)
    /// </summary>
    public class MenuManager
    {
        private ZoologicoService zoologico;
        
        /// <summary>
        /// Constructor que inicializa el zoológico con datos de ejemplo
        /// </summary>
        public MenuManager()
        {
            zoologico = new ZoologicoService("Zoo Paradise", 30);
            InicializarDatos();
        }
        
        /// <summary>
        /// Carga algunos animales de ejemplo al iniciar
        /// </summary>
        private void InicializarDatos()
        {
            zoologico.AgregarAnimal(new Perro("Max", 5, 25.5, "Labrador"));
            zoologico.AgregarAnimal(new Gato("Luna", 3, 4.2, "Negro"));
            zoologico.AgregarAnimal(new Pajaro("Piolín", 2, 0.5, true, "Corto"));
        }
        
        /// <summary>
        /// Muestra un banner decorativo al inicio
        /// </summary>
        private void MostrarBanner()
        {
            Console.WriteLine(@"
    ███████╗ ██████╗  ██╗   ██╗ ██████╗ ██╗  ██╗███████╗██████╗ 
    ╚══███╔╝██╔═══██╗ ██║   ██║██╔════╝ ██║  ██║██╔════╝██╔══██╗
      ███╔╝ ██║   ██║ ██║   ██║██║  ███╗███████║█████╗  ██████╔╝
     ███╔╝  ██║   ██║ ██║   ██║██║   ██║██╔══██║██╔══╝  ██╔══██╗
    ███████╗╚██████╔╝ ╚██████╔╝╚██████╔╝██║  ██║███████╗██║  ██║
    ╚══════╝ ╚═════╝   ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
                     🌿 ZOO PARADISE 🌿
");
        }
        
        /// <summary>
        /// Muestra y maneja el menú principal
        /// </summary>
        public void MostrarMenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                MostrarBanner();
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║         MENÚ PRINCIPAL                 ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("  1. 🐾 Agregar nuevo animal");
                Console.WriteLine("  2. 📋 Ver todos los animales");
                Console.WriteLine("  3. 🎮 Interactuar con un animal");
                Console.WriteLine("  4. 🍽️  Alimentar a todos");
                Console.WriteLine("  5. 🎵 Concierto de animales");
                Console.WriteLine("  6. 💉 Vacunar a todos");
                Console.WriteLine("  7. 🧮 Calcular edad promedio (recursivo)");
                Console.WriteLine("  8. 📊 Ver estadísticas");
                Console.WriteLine("  9. 🚪 Salir");
                Console.WriteLine("\n════════════════════════════════════════");
                Console.Write("  Selecciona una opción: ");
                string opcion = Console.ReadLine() ?? "0"; // Manejo de posible valor null
                switch (opcion)
                {
                    case "1": AgregarAnimal(); break;
                    case "2": VerAnimales(); break;
                    case "3": InteractuarConAnimal(); break;
                    case "4": zoologico.AlimentarTodos(); Pausar(); break;
                    case "5": zoologico.ConciertoAnimal(); Pausar(); break;
                    case "6": zoologico.VacunarTodos(); Pausar(); break;
                    case "7": MostrarEdadPromedioRecursivo(); break;  // Nueva opción
                    case "8": zoologico.MostrarEstadisticas(); Pausar(); break;
                    case "9": salir = true; break;
                    default: 
                        Console.WriteLine("\n❌ Opción inválida"); 
                        Pausar(); 
                        break;
                }
            }
            Console.WriteLine("\n¡Gracias por visitar el zoológico! 👋\n");
        }
        
        /// <summary>
        /// Menú para agregar un nuevo animal
        /// </summary>
        private void AgregarAnimal()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║      AGREGAR NUEVO ANIMAL              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("  1. 🐕 Perro");
            Console.WriteLine("  2. 🐱 Gato");
            Console.WriteLine("  3. 🐦 Pájaro");
            Console.Write("\n  Tipo de animal: ");
            string? tipo = Console.ReadLine(); // Usar tipo nullable
            
            if (string.IsNullOrWhiteSpace(tipo) || !int.TryParse(tipo, out int tipoAnimal))
            {
                Console.WriteLine("\n❌ Tipo de animal no válido");
                Pausar();
                return;
            }

            Console.Write("  Nombre: ");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("\n❌ El nombre no puede estar vacío");
                Pausar();
                return;
            }

            Console.Write("  Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad) || edad < 0)
            {
                Console.WriteLine("\n❌ Edad no válida");
                Pausar();
                return;
            }

            Console.Write("  Peso (kg): ");
            if (!double.TryParse(Console.ReadLine(), out double peso) || peso <= 0)
            {
                Console.WriteLine("\n❌ Peso no válido");
                Pausar();
                return;
            }

            Animal? nuevoAnimal = null; // Declarar como nullable
            
            switch (tipoAnimal)
            {
                case 1:
                    Console.Write("  Raza: ");
                    string? raza = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(raza))
                    {
                        Console.WriteLine("\n❌ La raza no puede estar vacía");
                        Pausar();
                        return;
                    }
                    nuevoAnimal = new Perro(nombre, edad, peso, raza);
                    break;
                case 2:
                    Console.Write("  Color: ");
                    string? color = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(color))
                    {
                        Console.WriteLine("\n❌ El color no puede estar vacío");
                        Pausar();
                        return;
                    }
                    nuevoAnimal = new Gato(nombre, edad, peso, color);
                    break;
                case 3:
                    Console.Write("  ¿Puede volar? (s/n): ");
                    string? respuestaVuelo = Console.ReadLine();
                    bool vuela = respuestaVuelo?.Trim().ToLower() == "s";
                    
                    Console.Write("  Tipo de pico (opcional): ");
                    string tipoPico = Console.ReadLine()?.Trim() ?? "Corto";
                    
                    nuevoAnimal = new Pajaro(nombre, edad, peso, vuela, tipoPico);
                    break;
                default:
                    Console.WriteLine("\n❌ Tipo de animal no válido");
                    Pausar();
                    return;
            }
            
            if (nuevoAnimal != null)
            {
                zoologico.AgregarAnimal(nuevoAnimal);
            }
            Pausar();
        }
        
        /// <summary>
        /// Muestra la lista de animales
        /// </summary>
        private void VerAnimales()
        {
            Console.Clear();
            zoologico.ListarAnimales();
            Pausar();
        }
        
        /// <summary>
        /// Permite interactuar con un animal específico
        /// </summary>
        private void InteractuarConAnimal()
        {
            Console.Clear();
            zoologico.ListarAnimales();
            Console.Write("\n  Selecciona un animal (número): ");
            
            if (!int.TryParse(Console.ReadLine(), out int indice) || indice <= 0)
            {
                Console.WriteLine("\n❌ Selección no válida");
                Pausar();
                return;
            }
            
            Animal? animal = zoologico.ObtenerAnimal(indice - 1); // Usar tipo nullable
            if (animal != null)
            {
                MenuInteraccionAnimal(animal);
            }
            else
            {
                Console.WriteLine("\n❌ Animal no encontrado");
                Pausar();
            }
        }
        
        /// <summary>
        /// Menú de interacción con un animal específico
        /// </summary>
        private void MenuInteraccionAnimal(Animal animal)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                animal.MostrarInformacion();
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║         ACCIONES DISPONIBLES           ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("  1. 🔊 Hacer sonido");
                Console.WriteLine("  2. 🍗 Comer");
                Console.WriteLine("  3. 😴 Dormir");
                Console.WriteLine("  4. 💉 Vacunar");
                
                // Acciones específicas según el tipo de animal
                if (animal is Perro)
                {
                    Console.WriteLine("  5. 🎾 Jugar");
                    Console.WriteLine("  6. 🏆 Entrenar");
                    Console.WriteLine("  7. 📜 Dar órdenes");
                }
                else if (animal is Gato)
                {
                    Console.WriteLine("  5. ✋ Acariciar");
                    Console.WriteLine("  6. 😺 Ronronear");
                    Console.WriteLine("  7. 🐭 Cazar juguete");
                }
                else if (animal is Pajaro)
                {
                    Console.WriteLine("  5. ✈️ Volar");
                    Console.WriteLine("  6. 🎵 Cantar");
                    Console.WriteLine("  7. 🪹 Anidar");
                }
                
                Console.WriteLine("  8. ↩️  Volver");
                Console.WriteLine("\n════════════════════════════════════════");
                Console.Write("  Selecciona una acción: ");
                string opcion = Console.ReadLine() ?? "0"; // Manejo de posible valor null
                
                switch (opcion)
                {
                    case "1":
                        animal.HacerSonido();
                        Pausar();
                        break;
                    case "2":
                        animal.Comer();
                        Pausar();
                        break;
                    case "3":
                        animal.Dormir();
                        Pausar();
                        break;
                    case "4":
                        if (!animal.EstaVacunado)
                        {
                            animal.Vacunar();
                        }
                        else
                        {
                            Console.WriteLine($"\n❌ {animal.Nombre} ya está vacunado");
                        }
                        Pausar();
                        break;
                    case "5":
                        EjecutarAccionEspecifica(animal, 5);
                        Pausar();
                        break;
                    case "6":
                        EjecutarAccionEspecifica(animal, 6);
                        Pausar();
                        break;
                    case "7":
                        EjecutarAccionEspecifica(animal, 7);
                        Pausar();
                        break;
                    case "8":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida");
                        Pausar();
                        break;
                }
            }
        }
        
        /// <summary>
        /// Ejecuta acciones específicas según el tipo de animal y la opción seleccionada
        /// </summary>
        private void EjecutarAccionEspecifica(Animal animal, int opcion)
        {
            if (animal is Perro perro)
            {
                switch (opcion)
                {
                    case 5: perro.Jugar(); break;
                    case 6: perro.Entrenar(); break;
                    case 7: perro.DarOrdenes(); break;
                }
            }
            else if (animal is Gato gato)
            {
                switch (opcion)
                {
                    case 5: gato.Acariciar(); break;
                    case 6: gato.Ronronear(); break;
                    case 7: gato.CazarJuguete(); break;
                }
            }
            else if (animal is Pajaro pajaro)
            {
                switch (opcion)
                {
                    case 5: pajaro.Volar(); break;
                    case 6: pajaro.CantarCancion(); break;
                    case 7: pajaro.Anidar(); break;
                }
            }
        }

        
        /// <summary>
        /// Muestra el cálculo recursivo del promedio de edades
        /// </summary>
        private void MostrarEdadPromedioRecursivo()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║  CÁLCULO RECURSIVO DE EDADES PROMEDIO  ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            // Mostrar los pasos detallados del cálculo recursivo
            zoologico.MostrarCalculoRecursivo();

            // También mostrar el resultado simple
            double promedio = zoologico.CalcularEdadPromedioRecursivo();
            Console.WriteLine($"\n🎯 EDAD PROMEDIO FINAL: {promedio:F2} años");

            Pausar();
        }
        
        /// <summary>
        /// Pausa la ejecución y espera que el usuario presione una tecla
        /// </summary>
        private void Pausar()
        {
            Console.WriteLine("\n\n════════════════════════════════════════");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}