using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPowerUp : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
