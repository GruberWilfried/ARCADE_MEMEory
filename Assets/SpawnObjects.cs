using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objToSpawn;
    public int count;
    public GameObject[] clones;

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            clones = new GameObject[count];
            //// Etwas N-Mal erstellen
            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(objToSpawn);
                clone.name = " " + i;
                clones[i] = clone;
            }
        }

        if (Input.GetKeyDown("w"))
        {
            GameObject[] x = GameObject.FindGameObjectsWithTag("Respawn");

            ////                     45
            //for (int i = 0; i < x.Length; i++)
            //{
            //    Destroy(x[i]);
            //}

            for (int i = 0; i < clones.Length; i++)
            {
                Destroy(clones[i]);
            }
        }
    }
}
