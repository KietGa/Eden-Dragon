using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject panel;
    public void OnPointerClick(PointerEventData eventData)
    {
        panel.SetActive(true);
    }
} 
