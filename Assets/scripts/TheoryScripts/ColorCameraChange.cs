using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCameraChange : MonoBehaviour
{
    [SerializeField] private Color[] colorArray;
    [SerializeField] Camera MainCamera;
    
    private IEnumerator ChangeColorCorroutine()
    {
        foreach (Color color in colorArray )
        {
            Debug.Log(color);
            MainCamera.backgroundColor = color;
            yield return new WaitForSeconds(2);
        }
    }

    private void Start()
    {
        StartCoroutine(ChangeColorCorroutine());
    }
}
