using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVIndicatorFollowPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform playertransform;

    private void LateUpdate()
    {
        transform.position = playertransform.position;
    }
}
