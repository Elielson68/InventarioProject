using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventarioSystem{

    public class MercadoVila: MonoBehaviour, IMercado
    {

        public IConsumivel criarPoteVida(GameObject spawnItens)
        {
            return new HP(spawnItens);
        }
        public IConsumivel criarPoteMana(GameObject spawnItens)
        {
            return new MP(spawnItens);
        }
    }
}