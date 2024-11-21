using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    public int score;

    // 1. Ein Prefab angeben das dupliziert werden soll
    public GameObject memoryPiece;
    // 2. Das Transform unter das meine memorypieces geparented werden sollen
    public Transform content;
    // 3. Wir möchten mehrere Sprites angeben können die erstellt werden
    public Sprite[] images;

    public MemoryManager mm;

    public MemoryPiece card1;
    public MemoryPiece card2;

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
            piece.GetComponent<MemoryPiece>().memoryImage = images[i];

            GameObject piece2 = Instantiate(memoryPiece);
            piece2.name = "Memory" + i + "_2";
            piece2.GetComponent<MemoryPiece>().manager = mm;
            piece2.GetComponent<MemoryPiece>().memoryImage = images[i];

            // 7. Das neu erstellte GameObject muss unter das
            // parent transform gesetzt werden (SetParent  von einem Transform Object)
            piece.transform.SetParent(content);
            piece2.transform.SetParent(content);
        }
    }

    private void Update()
    {
        if (cardsOpen == 2)
        {
            Sprite bild1 = card1.GetComponent<Image>().sprite;
            Sprite bild2 = card2.GetComponent<Image>().sprite;

            if (bild1 == bild2)
            {
                Debug.Log("Richtig");
                score++;
                Destroy(card1.gameObject);
                Destroy(card2.gameObject);

                if (score == images.Length)
                {
                    Debug.Log("Wir haben gewonnen!");
                }
            }
            else
            {
                Debug.Log("Falsch");
            }

            // card1.gameObject

            cardsOpen = 0;
        }

        if (Input.GetKeyDown("space"))
        {
            Transform[] children = content.GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                int random = Random.Range(0,children.Length);
                children[i].SetSiblingIndex(random);
            }
        }

        if (Input.GetKeyDown("a"))
        {
            Transform[] children = content.GetComponentsInChildren<Transform>();
            Debug.Log(children.Length);
            for (int i = 0; i < children.Length; i++)
            {
                Debug.Log(children[0].name);
                Image img = children[i].GetComponent<Image>();
                print(img);
                MemoryPiece mp = children[i].GetComponent<MemoryPiece>();
                print(mp);
                //children[i].GetComponent<Image>().sprite = children[i].GetComponent<MemoryPiece>().memoryImage;
            }
        }
    }
}
