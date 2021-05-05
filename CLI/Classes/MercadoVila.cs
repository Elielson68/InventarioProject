using System;

namespace InventarioSystem{
    public class MercadoVila: IMercado{
        public IConsumivel criarPoteVida(){
            return new HP();
        }
        public IConsumivel criarPoteMana(){
            return new MP();
        }
    }
}