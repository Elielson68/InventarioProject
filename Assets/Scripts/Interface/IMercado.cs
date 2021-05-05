using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public interface IMercado{
        IConsumivel criarPoteVida(GameObject spawnItens);
        IConsumivel criarPoteMana(GameObject spawnItens);
    }
}