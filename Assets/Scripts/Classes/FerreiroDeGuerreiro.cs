using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public class FerreiroDeGuerreiro: MonoBehaviour, IFerreiro{
        
        public IEquipamento criarHelmo(GameObject spawnItens)
        {
            return new HelmoGuerreiro(spawnItens);
        }
        public IEquipamento criarArmadura(GameObject spawnItens)
        {
            return new ArmaduraGuerreiro(spawnItens);
        }
        public IEquipamento criarEspada(GameObject spawnItens)
        {
            return new EspadaGuerreiro(spawnItens);
        }
        public IEquipamento criarBota(GameObject spawnItens)
        {
            return new BotaGuerreiro(spawnItens);
        }
        public IEquipamento criarLuva(GameObject spawnItens)
        {
            return new LuvaGuerreiro(spawnItens);
        }
        public IEquipamento criarAnel(GameObject spawnItens)
        {
            return new AnelGuerreiro(spawnItens);
        }
        public IEquipamento criarItemGuerreiro(string nome, string tipo, string body, string classe, int []atri)
        {
            return new ItemGuerreiro(nome, tipo, body, classe, atri);
        }
    }
}