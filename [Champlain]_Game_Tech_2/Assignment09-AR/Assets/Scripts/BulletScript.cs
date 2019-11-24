using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(transform.forward*speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            collision.gameObject.GetComponent<Core>().looseHP();
        }
        else Destroy(gameObject);
    }
}
