using System;

namespace InventarioSystem{
    public class HP : IConsumivel
    {
        public string Nome { get; set; }

        public string Tipo{get; private set;} = "consumivel";
        public void Consumir()
        {
            Console.WriteLine("Vida restaurada!");
        }
    }
}