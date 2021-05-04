using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventarioSystem{
    public class FerreiroDeGuerreiro: MonoBehaviour, IFerreiro{
        public GameObject spawnItens;
        public void Start()
        {
            print(criarHelmo().Nome);
            spawnItens.transform.Translate(2, 0, 0);
            criarArmadura();
            spawnItens.transform.Translate(2, 0, 0);
            criarArmadura();
            spawnItens.transform.Translate(2, 0, 0);
            criarArmadura();
        }
        public IEquipamento criarHelmo(){
            return new HelmoGuerreiro(spawnItens);
        }
        public IEquipamento criarArmadura(){
            return new ArmaduraGuerreiro(spawnItens);
        }
    }
}