using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventarioSystem{

    public class MercadoVila: MonoBehaviour, IMercado
    {

        public SpriteRenderer spawnItens;
        public IConsumivel criarPoteVida(){
            return new HP(spawnItens);
        }
        public IConsumivel criarPoteMana(){
            return new MP(spawnItens);
        }
    }
}