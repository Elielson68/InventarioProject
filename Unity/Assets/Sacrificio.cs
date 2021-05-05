using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventarioSystem;
public class Sacrificio : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Item ovelha = Inventario.Instance.inventarioGeral.Find(ovelha => ovelha.Tipo == "inutil");
            if (ovelha != null)
            {
                print("Está com a ovelha");
            }
        }
    }
}
