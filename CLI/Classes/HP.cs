using System;

namespace InventarioSystem{
    public class MP : IConsumivel
    {
        public string Nome { get; set; }
        public string Tipo{get; private set;} = "consumivel";
        public void Consumir()
        {
            Console.WriteLine("Mana restaurada!");
        }
    }
}