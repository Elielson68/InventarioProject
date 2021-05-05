using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventarioSystem;
public class OvelhaInutil : MonoBehaviour, Inutil
{
    public OvelhaInutil(GameObject spawnPosition)
    {
        GameObject spriteGameObject = Instantiate<GameObject>(spawnPosition);
        spriteGameObject.transform.localScale = new Vector3(8, 8, 0);
        SpriteItem = spriteGameObject.GetComponent<SpriteRenderer>();
        Texture2D textureHelmo = Resources.Load<Texture2D>("SetWarrior/Icons/Lixo/Sheep");
        Sprite mySprite = Sprite.Create(textureHelmo, new Rect(0.0f, 0.0f, textureHelmo.width, textureHelmo.height), new Vector2(0.0f, 0.0f), 100.0f);
        SpriteItem.sprite = mySprite;

        SpriteItem.sortingOrder = 1;

        BoxCollider2D boxColliderSprite = spriteGameObject.GetComponent<BoxCollider2D>();
        boxColliderSprite.offset = new Vector2(0.0800086334f, 0.0811435282f);
        boxColliderSprite.size = new Vector2(0.163946018f, 0.1608904f);
        spriteGameObject.tag = "inutil";

        OvelhaInutil component = spriteGameObject.AddComponent<OvelhaInutil>();
        component.Nome = Nome;
        component.Tipo = Tipo;
        component.SpriteItem = SpriteItem;

    }
    public string Nome { get; set; } = "Ovelha";

    public string Tipo { get; set; } = "inutil";

    public SpriteRenderer SpriteItem { get; set; }

    void Inutil.FazerNada()
    {
        return;
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
        return null;
    }
}
