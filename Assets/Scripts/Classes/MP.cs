using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public class HP : MonoBehaviour, IConsumivel
    {
        public HP(SpriteRenderer spawnPosition)
        {
            SpriteItem = Instantiate<SpriteRenderer>(spawnPosition);
            Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Helmet/4");
            Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
            SpriteItem.sprite = mySprite;
            SpriteItem.sortingOrder = 1;
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
    }
}