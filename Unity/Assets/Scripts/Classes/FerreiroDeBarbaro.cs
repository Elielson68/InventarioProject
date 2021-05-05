using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem
{
    public class FerreiroDeBarbaro : MonoBehaviour, IFerreiro
    {

        public IEquipamento criarHelmo(GameObject spawnItens)
        {
            return new HelmoBarbaro(spawnItens);
        }
        public IEquipamento criarArmadura(GameObject spawnItens)
        {
            return new ArmaduraBarbaro(spawnItens);
        }

    }
}