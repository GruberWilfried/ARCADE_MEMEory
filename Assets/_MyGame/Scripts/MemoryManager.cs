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

    private Sprite backGround;

    void Start()
    {
        backGround = memoryPiece.GetComponent<Image>().sprite;

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

        content.GetChild(0).GetComponent<Button>().Select();
        
    }

    private void Update()
    {
        if (cardsOpen == 2)
        {
            Sprite bild1 = card1.GetComponent<Image>().sprite;
            Sprite bild2 = card2.GetComponent<Image>().sprite;

            TurnOffMemoryPieces();
            Invoke("TurnOnMemoryPieces", 1.5f);
            if (bild1 == bild2)
            {
                Debug.Log("Richtig");
                score++;
                // Aufruf der HideRightCards Funktion
                // 1. Name der Funktion (identifier)
                // 2. Die leere Parameterliste (wenn kein Paremeter festgelegt)
                // 3. Semikolon zum Ende
                //HideRightCards();
                //TurnOffMemoryPieces();
                Invoke("HideRightCards",1.5f);
                
                if (score == images.Length)
                {
                    Debug.Log("Wir haben gewonnen!");
                }
            }
            else
            {
                //TurnOffMemoryPieces();
                Invoke("TurnWrongCards",1.5f);

                Debug.Log("Falsch");
            }

            cardsOpen = 0;
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    Transform[] children = content.GetComponentsInChildren<Transform>();

        //    for (int i = 0; i < children.Length; i++)
        //    {
        //        int random = Random.Range(0,children.Length);
        //        children[i].SetSiblingIndex(random);
        //    }
        //}

        if (Input.GetKeyDown("a"))
        {
            Transform[] children = content.GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                MemoryPiece piece = children[i].GetComponent<MemoryPiece>();
                if (piece != null)
                {
                    children[i].GetComponent<Image>().sprite = children[i].GetComponent<MemoryPiece>().memoryImage;
                }
            }
        }

        if (Input.GetKeyDown("s"))
        {
            Transform[] children = content.GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                MemoryPiece piece = children[i].GetComponent<MemoryPiece>();
                if (piece != null)
                {
                    children[i].GetComponent<Image>().sprite = backGround;
                }
            }
        }
    }

    // Deklaration einer Funktion (ohne Parameter und ohne Return Value)
    // 1. Deklarieren auf Klassenebene (Empfehlung)
    // 2. Deklaration -> Was soll die Funktion machen?
    // 3. Aufruf -> Der Zeitpunkt zu dem die Funktion ausgeführt werden soll
    // 4. Wofür brauchen wir Funktionen?
    //    - Wiederverwendbarkeit von Code

    // public -> access modifier (Zugrifssrechte)
    // void   -> return type (Gibt uns die Funktion einen Wert zurück)
    // HideWrongCards -> identifier (Name der Funktion -> brauchen wir beim Aufruf)
    // ()     -> Parameterliste
    // {}     -> scope (Was soll alles von der Funktion ausgeführt werden)
    public void HideRightCards()
    {
        card1.GetComponent<Image>().enabled = false;
        card2.GetComponent<Image>().enabled = false;
        card1.enabled = false;
        card2.enabled = false;
    }

    public void TurnWrongCards()
    {
        card1.GetComponent<Image>().sprite = backGround;
        card2.GetComponent<Image>().sprite = backGround;

    }

    public void TurnOffMemoryPieces()
    {
        Transform[] children = content.GetComponentsInChildren<Transform>();

        for (int i = 0; i < children.Length; i++)
        {
            MemoryPiece piece = children[i].GetComponent<MemoryPiece>();
            if (piece != null)
            {
                piece.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void TurnOnMemoryPieces()
    {
        Transform[] children = content.GetComponentsInChildren<Transform>();

        for (int i = 0; i < children.Length; i++)
        {
            MemoryPiece piece = children[i].GetComponent<MemoryPiece>();
            if (piece != null)
            {
                piece.GetComponent<Button>().interactable = true;
            }
        }

    }

}
