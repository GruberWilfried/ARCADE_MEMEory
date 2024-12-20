using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Wofür brauchen wir Funktionen?
    // - Wiederverwendbarkeit von Code
    // - ÜBersichtlichkeit
    // - Leichter wartbar (Instandhaltung)

    // Wie deklarieren wir eine Funktion?
    // ( Was soll unsere Funktion machen)

    // private / public -> access modifier (Zugrriffsrechte)
    // void             -> return type (void -> Kein Wert zurückgegeben)
    // TestFunktion     -> Name (identifier)
    // ()               -> Parameterliste (Input wenn notwendig)
    // {}               -> scope (Was wird in der Funktion ausgeführt)

    // Deklaration einer Funktion ohne Input und ohne Output (return value)
    private void TestFunktion()
    {
        
    }

    // Deklaration einer Funktion mit Input
    // Wir deklarieren das entsprechende Input in der Parameterliste
    private void MultiplyTwoNumbers(float a, float b)
    {
        float product = a * b;
        Debug.Log(product);
    }

    // Deklaration einer Funktion mit Input und Output
    // 1. Wir brauchen den entsprechenden return type (z.b. float)
    // 2. Mit dem return statement explizit angegeben
    // welcher Wert zurückgegeben werden soll
    private float DivideTwoNumbers(float a, float b)
    {
        float c = a / b;
        float u = 32;
        float i= 8;
        float p = 5;
        return c;
    }

    private string FullName(string vornamen, string nachnamen)
    {
        string fullName = nachnamen + vornamen;
        return fullName;
    }


    private void Start()
    {
        // Aufruf der Funktion (Wann soll die Funktionalität verwendet werden)
        // 1. Name der Funktion
        // 2. Parameterliste (selbst wenn sie leer ist)
        // 3. Semikolon
        TestFunktion();

        MultiplyTwoNumbers(4,5);
        MultiplyTwoNumbers(67, 8987);
        MultiplyTwoNumbers(3, Random.Range(2,10) );

        float x = DivideTwoNumbers(20,5) * 4; // 16
        string y = FullName("max","mustermann");

        //float a = Formel1(7,4);
        //float b = Formel1(12,5);
        //float c = Formel1(2,8);
    }

    public void Formel1(float a, float b)
    {

    }
}
