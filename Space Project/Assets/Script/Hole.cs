using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int numberBullet;
    public GameObject satelliteBullet;
    public bool canMove;
    public float radius;
    // Start is called before the first frame update
    public Satellite[] bullets;
    void Start()
    {
        bullets = new Satellite[numberBullet];
        for (int i = 0; i < numberBullet; i++)
        {
            bullets[i] = Instantiate(satelliteBullet, transform.position, Quaternion.identity).GetComponent<Satellite>();
            float a = (float)i / (numberBullet );
            float b = a * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(b);
            float yScaled = Mathf.Sin(b);

            float x = xScaled * radius;
            float y = yScaled * radius;
            bullets[i].SetHole(gameObject, transform.position + new Vector3(x, y, 0));
            bullets[i].transform.Rotate(new Vector3(0, 0, -90 + 360 / (numberBullet) * i));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            for (int i = 0; i < numberBullet; i++)
            {
                bullets[i].isRelease = true;
            }
            Destroy(collision.gameObject);
        }
    }

}
