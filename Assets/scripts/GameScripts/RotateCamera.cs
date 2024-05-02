using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //variables

    [SerializeField] private float rotationSpeed;
    private float horizontalInput;

    //upadate - start - etc..

    private void Update()
    {
        //rotation of the camera

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
