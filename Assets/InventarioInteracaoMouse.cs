using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventarioInteracaoMouse : MonoBehaviour
{
    private void OnMouseDrag()
    {
        print($"Mouse Position: {Input.mousePosition}");
        print($"Invent�rio Position: {gameObject.transform.position}");
        Vector3 novaPos = Input.mousePosition - gameObject.transform.position;
        print($"Difen�a: {novaPos}");
        gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }


}
