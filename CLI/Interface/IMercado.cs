using System;

namespace InventarioSystem{
    public interface IMercado{
        IConsumivel criarPoteVida();
        IConsumivel criarPoteMana();
    }
}