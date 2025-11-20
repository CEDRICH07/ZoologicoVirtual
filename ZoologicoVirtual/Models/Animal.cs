using System;

namespace ZoologicoVirtual.Models
{
    /// <summary>
    /// Clase base abstracta que representa un animal genérico del zoológico
    /// Aplica el principio de Abstracción y sirve como base para la Herencia
    /// </summary>
    public abstract class Animal
    {
        // Propiedades públicas con encapsulamiento automático
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public string Habitat { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EstaVacunado { get; set; }

        /// <summary>
        /// Constructor protegido para ser usado por las clases derivadas
        /// </summary>
        protected Animal(string nombre, int edad, double peso, string habitat = "Por asignar")
        {
            Nombre = nombre;
            Edad = edad;
            Peso = peso;
            Habitat = habitat;
            FechaIngreso = DateTime.Now;
            EstaVacunado = false;
        }

        // Métodos abstractos (DEBEN ser implementados por clases hijas)
        public abstract void HacerSonido();
        public abstract string ObtenerTipo();
        
        // Métodos virtuales (PUEDEN ser sobrescritos por clases hijas)
        public virtual void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo...");
        }

        public virtual void Dormir()
        {
            Console.WriteLine($"{Nombre} está durmiendo... Zzz");
        }

        /// <summary>
        /// Método para vacunar al animal
        /// </summary>
        public void Vacunar()
        {
            EstaVacunado = true;
            Console.WriteLine($"✓ {Nombre} ha sido vacunado correctamente");
        }

        /// <summary>
        /// Muestra la información básica del animal
        /// </summary>
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"\n╔══════════════════════════════════════╗");
            Console.WriteLine($"║  {ObtenerTipo().ToUpper().PadRight(36)}║");
            Console.WriteLine($"╚══════════════════════════════════════╝");
            Console.WriteLine($"  Nombre:        {Nombre}");
            Console.WriteLine($"  Edad:          {Edad} años");
            Console.WriteLine($"  Peso:          {Peso} kg");
            Console.WriteLine($"  Hábitat:       {Habitat}");
            Console.WriteLine($"  Ingreso:       {FechaIngreso:dd/MM/yyyy}");
            Console.WriteLine($"  Vacunado:      {(EstaVacunado ? "Sí ✓" : "No ✗")}");
        }
    }
}