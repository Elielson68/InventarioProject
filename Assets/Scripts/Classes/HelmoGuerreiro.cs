using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem {
    public class HelmoGuerreiro : MonoBehaviour, IEquipamento
    {

        public HelmoGuerreiro(GameObject spawnPosition)
        {
            GameObject spriteGameObject = Instantiate<GameObject>(spawnPosition);
            SpriteItem = spriteGameObject.GetComponent<SpriteRenderer>();
            Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Head/Guerreiro");
            Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
            SpriteItem.sprite = mySprite;
            //SpriteItem.sprite.name = Nome;
            SpriteItem.sortingOrder = 1;
            
            BoxCollider2D boxColliderSprite =  spriteGameObject.GetComponent<BoxCollider2D>();
            boxColliderSprite.offset = new Vector2(0.9557155f, 0.9581932f);
            boxColliderSprite.size = new Vector2(1.903571f, 1.897903f);
            spriteGameObject.tag = "equipavel";

            HelmoGuerreiro component = spriteGameObject.AddComponent<HelmoGuerreiro>();
            component.Nome = Nome;
            component.Tipo = Tipo;
            component.bodyPart = bodyPart;
            component.Classe = Classe;
            component.SpriteItem = SpriteItem;
            component.STR = 8;
            component.AGI = 5;
            component.DEX = 5;
            component.LUK = 3;
            component.Peso = 9;
        }

        public SpriteRenderer SpriteItem { get; set; }
        public int STR { get; private set; } = 6;
        public int AGI { get; private set; } = 3;
        public int DEX { get; private set; } = 4;
        public int LUK { get; private set; } = 5;
        public int Peso { get; private set; } = 9;
        public string Tipo { get; private set; } = "equipavel";
        public string bodyPart { get; private set; } = "Head";
        public string Nome { get; set; } = "Helmo de guerra";
        public string Classe { get; set; } = "Guerreiro";

        public void BuffItem() {
            STR += 2;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                print(!Inventario.Instance.isInventarioFull());
                if (!Inventario.Instance.isInventarioFull())
                    Destroy(gameObject);
            }
        }
        public Item DeepCopy()
        {
            HelmoGuerreiro other = (HelmoGuerreiro)this.MemberwiseClone();
            other.Tipo = Tipo;
            other.bodyPart = bodyPart;
            other.Classe = Classe;
            other.SpriteItem = SpriteItem;
            other.STR = 6;
            other.AGI = 3;
            other.DEX = 4;
            other.LUK = 5;
            other.Peso = 9;
            other.Nome = Nome;
            return other;
        }
    }
}