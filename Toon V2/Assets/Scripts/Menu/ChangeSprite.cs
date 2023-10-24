using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ChangeSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite icon;
    public Sprite icon2;
    
    public void OnPointerEnter(PointerEventData eventData)
    {

        gameObject.GetComponent<Image>().sprite = icon2;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = icon;
    }
}
