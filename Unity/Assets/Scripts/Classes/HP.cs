using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public class HP : MonoBehaviour, IConsumivel
    {
        public HP()
        {

        }
        public HP(GameObject spawnPosition)
        {
            GameObject spriteGameObject = Instantiate<GameObject>(spawnPosition);
            spriteGameObject.transform.localScale = new Vector3(12, 14, 0);
            SpriteItem = spriteGameObject.GetComponent<SpriteRenderer>();
            Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Mercado/Misc/HP");
            Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
            
            SpriteItem.sprite = mySprite;
            
            SpriteItem.sortingOrder = 1;
            BoxCollider2D boxColliderSprite = spriteGameObject.GetComponent<BoxCollider2D>();
            boxColliderSprite.offset = new Vector2(0.0492785871f, 0.055150032f);
            boxColliderSprite.size = new Vector2(0.103928745f, 0.115270615f);
            spriteGameObject.tag = "consumivel";

            HP component = spriteGameObject.AddComponent<HP>();
            component.Nome = Nome;
            component.Tipo = Tipo;
            component.SpriteItem = SpriteItem;
        }
        public SpriteRenderer SpriteItem { get; set; }
        public string Nome { get; set; }
        public string Tipo{get; private set;} = "consumivel";
        public void Consumir()
        {
            Console.WriteLine("Mana restaurada!");
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!Inventario.Instance.isInventarioFull())
                    Destroy(gameObject);
            }
        }

        public Item DeepCopy()
        {
            HP other = (HP) this.MemberwiseClone();
            return other;
        }
    }
}