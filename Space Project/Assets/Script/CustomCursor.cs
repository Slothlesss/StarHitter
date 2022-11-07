using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    private void Awake()
    {

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
    }
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }
}
