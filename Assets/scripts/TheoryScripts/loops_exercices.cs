using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loops_exercices : MonoBehaviour
{



    private void Start()
    {
        // exercice 1

        for (int i = 0; i <= 100; i++)
        {
            Debug.Log($"exercice 1 number {i}");

        }

        // exercice 2

        for (int i =0; i <=100; i++)
        {
           if (i % 2 ==0)
            {
                Debug.Log($"exercice 2 number {i}");
            }
           
        }

        // exercice 3


    }


}
