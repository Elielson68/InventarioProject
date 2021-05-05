using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem
{
    public class AnelGuerreiro : MonoBehaviour, IEquipamento
    {

        public AnelGuerreiro(GameObject spawnPosition)
        {
            GameObject spriteGameObject = Instantiate<GameObject>(spawnPosition);
            SpriteItem = spriteGameObject.GetComponent<SpriteRenderer>();
            Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Hand/Finger/Guerreiro");
            Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
            SpriteItem.sprite = mySprite;
            SpriteItem.sortingOrder = 1;

            BoxCollider2D boxColliderSprite = spriteGameObject.GetComponent<BoxCollider2D>();
            boxColliderSprite.offset = new Vector2(0.9557155f, 0.9581932f);
            boxColliderSprite.size = new Vector2(1.903571f, 1.897903f);
            spriteGameObject.tag = "equipavel";

            AnelGuerreiro component = spriteGameObject.AddComponent<AnelGuerreiro>();
            component.Nome = Nome;
            component.Tipo = Tipo;
            component.bodyPart = bodyPart;
            component.Classe = Classe;
            component.SpriteItem = SpriteItem;
        }

        public SpriteRenderer SpriteItem { get; set; }
        public int STR { get; private set; } = 6;
        public int AGI { get; private set; } = 3;
        public int DEX { get; private set; } = 4;
        public int LUK { get; private set; } = 5;
        public int Peso { get; private set; } = 9;
        public string Tipo { get; private set; } = "equipavel";
        public string bodyPart { get; private set; } = "Hand/Finger";
        public string Nome { get; set; } = "Anel de guerra";
        public string Classe { get; set; } = "Guerreiro";

        public void BuffItem()
        {
            STR += 2;
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
            AnelGuerreiro other = (AnelGuerreiro) this.MemberwiseClone();
            return other;
        }

    }
}