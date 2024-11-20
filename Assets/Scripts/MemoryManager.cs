using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    // 1. Ein Prefab angeben das dupliziert werden soll
    public GameObject memoryPiece;
    // 2. Das Transform unter das meine memorypieces geparented werden sollen
    public Transform content;
    // 3. Wir möchten mehrere Sprites angeben können die erstellt werden
    public Sprite[] images;

    public MemoryManager mm;

    public MemoryPiece selected;
    public int cardsOpen = 0;
    public int playerNumber = 1;

    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            // 4. Für jedes Sprite soll einmal ein neues Prefab erstellt werden (Instantiate)
            // Array durcharbeiten -> ???
            GameObject piece = Instantiate(memoryPiece);
            piece.name = "Memory" + i + "_1";
            piece.GetComponent<MemoryPiece>().manager = mm;
            GameObject piece2 = Instantiate(memoryPiece);
            piece2.name = "Memory" + i + "_2";
            piece2.GetComponent<MemoryPiece>().manager = mm;

            // 5. Von dem neu erstellten GameObject möchten
            // wir den Image Component in einer Variable abspeichern
            Image img = piece.GetComponent<Image>();
            Image img2 = piece2.GetComponent<Image>();

            // 6. Wir möchten in den Image Component das sprite aus dem array laden.
            img.sprite = images[i];
            img2.sprite = images[i];

            // 7. Das neu erstellte GameObject muss unter das
            // parent transform gesetzt werden (SetParent  von einem Transform Object)
            piece.transform.SetParent(content);
            piece2.transform.SetParent(content);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Transform[] children = content.GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                int random = Random.Range(0,children.Length);
                children[i].SetSiblingIndex(random);
            }
        }
    }
}
