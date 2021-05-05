using System;
using System.Collections.Generic;
using UnityEngine;
using InventarioSystem;
namespace InventarioSystem{
    interface IFerreiro{
        IEquipamento criarHelmo(GameObject spawnItens);
        IEquipamento criarArmadura(GameObject spawnItens);
    }
}