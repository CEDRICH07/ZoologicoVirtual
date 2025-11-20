using System;

namespace ZoologicoVirtual.Models
{
    /// <summary>
    /// Clase que representa un perro, hereda de Animal
    /// </summary>
    public class Perro : Animal
    {
        // Atributos específicos de Perro
        public string Raza { get; set; }
        public bool EstaEntrenado { get; set; }
        public int NivelEnergia { get; private set; }

        /// <summary>
        /// Constructor que inicializa un perro
        /// </summary>
        public Perro(string nombre, int edad, double peso, string raza, string habitat = "Perrera")
            : base(nombre, edad, peso, habitat)
        {
            Raza = raza;
            EstaEntrenado = false;
            NivelEnergia = 100;
        }

        // Implementación obligatoria del método abstracto
        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡GUAU GUAU! 🐕");
        }

        // Implementación obligatoria del método abstracto
        public override string ObtenerTipo() => "Perro";

        // Sobrescritura del método virtual
        public override void Comer()
        {
            Console.WriteLine($"{Nombre} está devorando croquetas premium 🦴");
            NivelEnergia = Math.Min(100, NivelEnergia + 20);
        }

        /// <summary>
        /// Método específico de perros para jugar
        /// </summary>
        public void Jugar()
        {
            if (NivelEnergia >= 20)
            {
                Console.WriteLine($"{Nombre} está jugando con una pelota 🎾");
                NivelEnergia -= 20;
                Console.WriteLine($"  Energía restante: {NivelEnergia}%");
            }
            else
            {
                Console.WriteLine($"{Nombre} está muy cansado para jugar 😴");
            }
        }

        /// <summary>
        /// Método para entrenar al perro
        /// </summary>
        public void Entrenar()
        {
            if (!EstaEntrenado)
            {
                Console.WriteLine($"Entrenando a {Nombre}...");
                System.Threading.Thread.Sleep(1000);
                EstaEntrenado = true;
                Console.WriteLine($"✓ {Nombre} ahora está entrenado!");
            }
            else
            {
                Console.WriteLine($"{Nombre} ya está entrenado");
            }
        }

        /// <summary>
        /// Método para dar órdenes al perro
        /// </summary>
        public void DarOrdenes()
        {
            if (EstaEntrenado)
            {
                Console.WriteLine($"{Nombre} obedece: Sentado... Quieto... ¡Muy bien! 🎖️");
            }
            else
            {
                Console.WriteLine($"{Nombre} te ignora... Necesita entrenamiento");
            }
        }

        // Sobrescritura de MostrarInformacion para agregar datos específicos
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"  Raza:          {Raza}");
            Console.WriteLine($"  Entrenado:     {(EstaEntrenado ? "Sí" : "No")}");
            Console.WriteLine($"  Energía:       {NivelEnergia}%");
        }
    }
}