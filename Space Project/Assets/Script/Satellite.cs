using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public GameObject hole;
    public float speed;
    public bool isRelease;

    void Update()
    {
        if (!isRelease)
        {
            transform.RotateAround(hole.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * 5 * Time.deltaTime);
        }
    }

    public void SetHole(GameObject hole, Vector3 pos)
    {
        this.hole = hole;
        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FinalHole"))
        {
            GameManager.Instance.count++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
}
