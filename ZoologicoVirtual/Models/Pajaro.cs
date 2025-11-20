using System;

namespace ZoologicoVirtual.Models
{
    /// <summary>
    /// Clase que representa un pájaro, hereda de Animal
    /// </summary>
    public class Pajaro : Animal
    {
        // Atributos específicos de Pajaro
        public bool PuedeVolar { get; set; }
        public string TipoPico { get; set; }
        public double EnvergaduraAlas { get; set; }

        /// <summary>
        /// Constructor que inicializa un pájaro
        /// </summary>
        public Pajaro(string nombre, int edad, double peso, bool vuela, string tipoPico = "Corto", string habitat = "Aviario")
            : base(nombre, edad, peso, habitat)
        {
            PuedeVolar = vuela;
            TipoPico = tipoPico;
            EnvergaduraAlas = vuela ? peso * 15 : 0;
        }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡PIO PIO! 🐦");
        }

        public override string ObtenerTipo() => "Pájaro";

        public override void Comer()
        {
            Console.WriteLine($"{Nombre} está picoteando semillas 🌾");
        }

        /// <summary>
        /// Método específico para que el pájaro vuele
        /// </summary>
        public void Volar()
        {
            if (PuedeVolar)
            {
                Console.WriteLine($"{Nombre} despliega sus alas ({EnvergaduraAlas:F1} cm)");
                Console.WriteLine($"  ¡Está volando alto en el cielo! 🕊️");
            }
            else
            {
                Console.WriteLine($"{Nombre} no puede volar 😢");
                Console.WriteLine("  Pero es feliz en tierra firme");
            }
        }

        /// <summary>
        /// Método para que el pájaro cante
        /// </summary>
        public void CantarCancion()
        {
            Console.WriteLine($"{Nombre} canta una hermosa melodía:");
            Console.WriteLine("  ♪ ♫ ♪ ♫ ¡Qué bonito canto! 🎵");
        }

        /// <summary>
        /// Método para que el pájaro construya un nido
        /// </summary>
        public void Anidar()
        {
            Console.WriteLine($"{Nombre} está construyendo un nido 🪹");
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"  Puede volar:   {(PuedeVolar ? "Sí" : "No")}");
            Console.WriteLine($"  Tipo de pico:  {TipoPico}");
            Console.WriteLine($"  Envergadura:   {EnvergaduraAlas:F1} cm");
        }
    }
}