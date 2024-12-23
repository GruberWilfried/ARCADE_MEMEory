using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryPiece : MonoBehaviour
{
    public MemoryManager manager;
    public Sprite memoryImage;

    public void OnButtonClick()
    {
        if (manager.cardsOpen == 0)
        {
            // card1
            manager.card1 = GetComponent<MemoryPiece>();
        }
        if (manager.cardsOpen == 1)
        {
            // card2
            manager.card2 = this;
        }
        manager.cardsOpen = manager.cardsOpen + 1;

        GetComponent<Image>().sprite = memoryImage;
    }


}
