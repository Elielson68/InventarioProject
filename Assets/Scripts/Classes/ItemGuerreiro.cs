using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public class ItemGuerreiro : MonoBehaviour, IEquipamento
    {
        public ItemGuerreiro(string nome, string tipo, string body, string classe, int []atributes)
        {
            Nome = nome;
            Tipo = tipo;
            bodyPart = body;
            Classe = classe;
            STR = atributes[0];
            AGI = atributes[1];
            DEX = atributes[2];
            LUK = atributes[3];
        }
        public SpriteRenderer SpriteItem { get; set; }
        public int STR { get; private set; }
        public int AGI { get; private set; }
        public int DEX { get; private set; }
        public int LUK { get; private set; }
        public int Peso { get; private set; }
        public string Tipo { get; private set; } 
        public string bodyPart {get; private set;} 
        public string Nome { get; set; } 
        public int Index { get; set; }
        public string Classe { get; set; }


        public void BuffItem(){
            STR += 3;
            AGI -= 1;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //Destroy(gameObject);
                //collision.GetComponent<Inventario>().AdicionarItemInventarioGeral(this.GetComponent<Item>());
            }
        }
        public Item DeepCopy()
        {
            ItemGuerreiro other = (ItemGuerreiro)this.MemberwiseClone();
            return other;
        }
    }
}