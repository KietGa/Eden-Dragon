using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject character;
    public void OnPointerEnter(PointerEventData eventData)
    {
        character.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        character.SetActive(false);
    }
}
