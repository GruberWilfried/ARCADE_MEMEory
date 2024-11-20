using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public Sprite[] images;

    private void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.SetParent(parent);
            clone.GetComponent<Image>().sprite = images[i];

            GameObject clone2 = Instantiate(prefab);
            clone2.transform.SetParent(parent);
            clone2.GetComponent<Image>().sprite = images[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            var x = parent.GetComponentsInChildren<Transform>(); 
            foreach (var item in x)
            {
                item.transform.SetSiblingIndex(Random.Range(0,item.transform.parent.childCount));
            }
        }
    }
}
