using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loops_theory : MonoBehaviour
{
    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            Debug.Log(i);
        }

        // esto lo que hace es que para una variable i que indica el numero de inicio, posteriormente pones el numero i donde quieres que acabe, finalmente cuanto suma la i cada vez que se repite
        //entre los parentesis pondremos lo que queremos que se ejecute
        // la variable i empieza en 1
        // se ejecuta un mensaje por consola que dice hola y suma 1 a i
        // se repite hasta que i vale 10 y entonces deja de ejecutarse el bucle




    }
}
