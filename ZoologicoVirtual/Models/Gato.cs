using System;

namespace ZoologicoVirtual.Models
{
    /// <summary>
    /// Clase que representa un gato, hereda de Animal
    /// </summary>
    public class Gato : Animal
    {
        // Atributos específicos de Gato
        public string ColorPelaje { get; set; }
        public bool EsJugueton { get; set; }
        public int NivelAfecto { get; private set; }

        /// <summary>
        /// Constructor que inicializa un gato
        /// </summary>
        public Gato(string nombre, int edad, double peso, string color, string habitat = "Gatería")
            : base(nombre, edad, peso, habitat)
        {
            ColorPelaje = color;
            EsJugueton = true;
            NivelAfecto = 50;
        }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡MIAU MIAU! 🐱");
        }

        public override string ObtenerTipo() => "Gato";

        public override void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo pescado fresco 🐟");
            NivelAfecto += 10;
        }

        /// <summary>
        /// Método específico para que el gato ronronee
        /// </summary>
        public void Ronronear()
        {
            if (NivelAfecto >= 60)
            {
                Console.WriteLine($"{Nombre} ronronea felizmente... purrr purrr 😸");
            }
            else
            {
                Console.WriteLine($"{Nombre} no tiene ganas de ronronear 😾");
            }
        }

        /// <summary>
        /// Método para acariciar al gato y aumentar su afecto
        /// </summary>
        public void Acariciar()
        {
            NivelAfecto = Math.Min(100, NivelAfecto + 15);
            Console.WriteLine($"Acariciaste a {Nombre}");
            Console.WriteLine($"  Nivel de afecto: {NivelAfecto}%");
            
            if (NivelAfecto >= 80)
            {
                Ronronear();
            }
        }

        /// <summary>
        /// Método para que el gato cace un juguete
        /// </summary>
        public void CazarJuguete()
        {
            if (EsJugueton)
            {
                Console.WriteLine($"{Nombre} está cazando un ratón de juguete 🐭");
                Console.WriteLine("  ¡Lo atrapó!");
            }
            else
            {
                Console.WriteLine($"{Nombre} está demasiado perezoso para cazar");
            }
        }

        public override void Dormir()
        {
            Console.WriteLine($"{Nombre} se enrolla y duerme en una caja 📦😴");
            NivelAfecto = Math.Max(30, NivelAfecto - 5);
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"  Color:         {ColorPelaje}");
            Console.WriteLine($"  Juguetón:      {(EsJugueton ? "Sí" : "No")}");
            Console.WriteLine($"  Afecto:        {NivelAfecto}%");
        }
    }
}