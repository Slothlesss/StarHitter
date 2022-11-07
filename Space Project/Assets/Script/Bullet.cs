using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public CustomCursor customCursor;
    public bool isMoving;
    public float speed;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isMoving)
        {
            isMoving = true;
            
        }
        if(isMoving)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
