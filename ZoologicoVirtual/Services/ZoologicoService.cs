using System;
using System.Collections.Generic;
using System.Linq;
using ZoologicoVirtual.Models;

namespace ZoologicoVirtual.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio del zoológico
    /// Aplica el principio de Single Responsibility (SOLID)
    /// </summary>
    public class ZoologicoService
    {
        private List<Animal> animales;
        public string NombreZoologico { get; set; }
        public int CapacidadMaxima { get; set; }

        /// <summary>
        /// Constructor del servicio del zoológico
        /// </summary>
        public ZoologicoService(string nombre = "Zoológico Virtual", int capacidad = 50)
        {
            animales = new List<Animal>();
            NombreZoologico = nombre;
            CapacidadMaxima = capacidad;
        }

        /// <summary>
        /// Agrega un animal al zoológico
        /// </summary>
        public bool AgregarAnimal(Animal animal)
        {
            if (animales.Count >= CapacidadMaxima)
            {
                Console.WriteLine("❌ El zoológico está lleno");
                return false;
            }

            animales.Add(animal);
            Console.WriteLine($"✓ {animal.Nombre} ha sido agregado al zoológico");
            return true;
        }

        /// <summary>
        /// Lista todos los animales del zoológico
        /// </summary>
        public void ListarAnimales()
        {
            if (animales.Count == 0)
            {
                Console.WriteLine("No hay animales en el zoológico");
                return;
            }

            Console.WriteLine($"\n╔══════════════════════════════════════════════╗");
            Console.WriteLine($"║  ANIMALES EN {NombreZoologico.ToUpper().PadRight(28)}║");
            Console.WriteLine($"╚══════════════════════════════════════════════╝");
            Console.WriteLine($"Total: {animales.Count}/{CapacidadMaxima}\n");

            for (int i = 0; i < animales.Count; i++)
            {
                var animal = animales[i];
                Console.WriteLine($"  [{i + 1}] {animal.Nombre.PadRight(15)} - {animal.ObtenerTipo().PadRight(10)} - {animal.Habitat}");
            }
        }

        /// <summary>
        /// Obtiene un animal por su índice
        /// </summary>
        public Animal? ObtenerAnimal(int indice)
        {
            if (indice >= 0 && indice < animales.Count)
            {
                return animales[indice];
            }
            return null;
        }

        /// <summary>
        /// Alimenta a todos los animales
        /// </summary>
        public void AlimentarTodos()
        {
            Console.WriteLine("\n🍽️  HORA DE ALIMENTACIÓN\n");
            foreach (var animal in animales)
            {
                animal.Comer();
            }
        }

        /// <summary>
        /// Hace que todos los animales hagan sonido
        /// </summary>
        public void ConciertoAnimal()
        {
            Console.WriteLine("\n🎵 CONCIERTO DE ANIMALES\n");
            foreach (var animal in animales)
            {
                animal.HacerSonido();
            }
        }

        /// <summary>
        /// Vacuna a todos los animales que no estén vacunados
        /// </summary>
        public void VacunarTodos()
        {
            Console.WriteLine("\n💉 CAMPAÑA DE VACUNACIÓN\n");
            foreach (var animal in animales)
            {
                if (!animal.EstaVacunado)
                {
                    animal.Vacunar();
                }
            }
        }

        /// <summary>
        /// Calcula el promedio de edad de todos los animales usando recursividad
        /// </summary>
        public double CalcularEdadPromedioRecursivo()
        {
            if (animales.Count == 0) 
                return 0;
            
            return CalcularSumaEdadesRecursivo(0) / (double)animales.Count;
        }
        
        /// <summary>
        /// Método auxiliar recursivo para calcular la suma de edades
        /// </summary>
        private int CalcularSumaEdadesRecursivo(int indice)
        {
            // Caso base: cuando llegamos al final de la lista
            if (indice >= animales.Count)
                return 0;
            
            // Llamada recursiva: suma la edad actual + suma del resto
            return animales[indice].Edad + CalcularSumaEdadesRecursivo(indice + 1);
        }
        
        /// <summary>
        /// Muestra un detalle visual del cálculo recursivo para fines educativos
        /// </summary>
        public void MostrarCalculoRecursivo()
        {
            if (animales.Count == 0)
            {
                Console.WriteLine("\n❌ No hay animales en el zoológico para calcular el promedio.");
                return;
            }
            
            Console.WriteLine("\n🧮 CÁLCULO RECURSIVO DEL PROMEDIO DE EDADES");
            Console.WriteLine("══════════════════════════════════════════════");
            
            // Mostrar cada paso del cálculo
            Console.WriteLine($"Nombres de animales: {string.Join(", ", animales.Select(a => a.Nombre))}");
            Console.WriteLine($"Edades: {string.Join(", ", animales.Select(a => a.Edad))}\n");
            
            int sumaTotal = MostrarPasosRecursivos(0);
            double promedio = (double)sumaTotal / animales.Count;
            
            Console.WriteLine($"\n🔢 Resultados:");
            Console.WriteLine($"  Suma total de edades: {sumaTotal} años");
            Console.WriteLine($"  Número de animales: {animales.Count}");
            Console.WriteLine($"  Edad promedio: {promedio:F2} años");
        }
        
        /// <summary>
        /// Método recursivo que muestra visualmente cada paso del cálculo
        /// </summary>
        private int MostrarPasosRecursivos(int indice, int nivel = 0)
        {
            if (indice >= animales.Count)
            {
                Console.WriteLine($"{new string(' ', nivel * 4)}→ Llegamos al final de la lista");
                return 0;
            }
            
            Console.WriteLine($"{new string(' ', nivel * 4)}→ Paso {indice + 1}: {animales[indice].Nombre} tiene {animales[indice].Edad} años");
            
            int sumaResto = MostrarPasosRecursivos(indice + 1, nivel + 1);
            int sumaTotal = animales[indice].Edad + sumaResto;
            
            if (nivel > 0)
            {
                Console.WriteLine($"{new string(' ', nivel * 4)}← Regresando: {animales[indice].Edad} + {sumaResto} = {sumaTotal}");
            }
            else
            {
                Console.WriteLine($"← Resultado final: suma total = {sumaTotal}");
            }
            
            return sumaTotal;
        }

        /// <summary>
        /// Muestra estadísticas del zoológico
        /// </summary>
        public void MostrarEstadisticas()
        {
            var perros = animales.OfType<Perro>().Count();
            var gatos = animales.OfType<Gato>().Count();
            var pajaros = animales.OfType<Pajaro>().Count();
            var vacunados = animales.Count(a => a.EstaVacunado);

            Console.WriteLine("\n📊 ESTADÍSTICAS DEL ZOOLÓGICO");
            Console.WriteLine("════════════════════════════════");
            Console.WriteLine($"  Perros:           {perros}");
            Console.WriteLine($"  Gatos:            {gatos}");
            Console.WriteLine($"  Pájaros:          {pajaros}");
            Console.WriteLine($"  Total:            {animales.Count}");
            Console.WriteLine($"  Vacunados:        {vacunados}/{animales.Count}");
            Console.WriteLine($"  Capacidad usada:  {(animales.Count * 100.0 / CapacidadMaxima):F1}%");
        }
    }
}