using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public class MP : MonoBehaviour, IConsumivel
    {
        public MP(GameObject spawnPosition)
        {
            GameObject spriteGameObject = Instantiate<GameObject>(spawnPosition);
            spriteGameObject.transform.localScale = new Vector3(8, 8, 0);
            SpriteItem = spriteGameObject.GetComponent<SpriteRenderer>();
            Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Mercado/Misc/MP");
            Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
            SpriteItem.sprite = mySprite;
            
            SpriteItem.sortingOrder = 1;

            BoxCollider2D boxColliderSprite = spriteGameObject.GetComponent<BoxCollider2D>();
            boxColliderSprite.offset = new Vector2(0.0633318648f, 0.10949409f);
            boxColliderSprite.size = new Vector2(0.13059248f, 0.217591524f);
            spriteGameObject.tag = "consumivel";

            MP component = spriteGameObject.AddComponent<MP>();
            component.Nome = Nome;
            component.Tipo = Tipo;
            component.SpriteItem = SpriteItem;

        }
        public SpriteRenderer SpriteItem { get; set; }
        public string Nome { get; set; }

        public string Tipo{get; private set;} = "consumivel";
        public void Consumir()
        {
            Console.WriteLine("Vida restaurada!");
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        public Item DeepCopy()
        {
            MP other = (MP)this.MemberwiseClone();
            return other;
        }
    }
}