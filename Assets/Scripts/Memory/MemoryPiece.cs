using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryPiece : MonoBehaviour, IPointerClickHandler
{
    public MemoryManager manager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Piece clicked: " + eventData.pointerClick.gameObject.name);
        manager.selected = this;
        //manager.cardsOpen++;
        //manager.cardsOpen += 1;
        manager.cardsOpen = manager.cardsOpen + 1;
    }
}
