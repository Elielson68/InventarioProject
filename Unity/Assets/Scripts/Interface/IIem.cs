using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventarioSystem{
    public interface Item{
        string Nome {get; set;}

        string Tipo {get;}

        SpriteRenderer SpriteItem { get; set; }

        void OnTriggerEnter2D(Collider2D collision);

        public Item DeepCopy();
    }
}