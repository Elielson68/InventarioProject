using System;

namespace InventarioSystem{
    public interface IFerreiro{
        IEquipamento criarHelmo();
        IEquipamento criarArmadura();
    }
}