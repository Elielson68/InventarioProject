using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventarioSystem;
using UnityEngine.EventSystems;
public class InfoItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject papelInfo;
    [SerializeField] Text textoInfo;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button.ToString() == "Right")
        {
            papelInfo.SetActive(!papelInfo.activeInHierarchy);
            textoInfo.text = Inventario.Instance.GetInfoItem(this.name);
            print($"Clicked: {textoInfo.text}");
        }
    }

    
}
