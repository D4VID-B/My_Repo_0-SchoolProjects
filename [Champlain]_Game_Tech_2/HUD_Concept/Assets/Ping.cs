using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Found Enemy" + collision.gameObject.ToString());
            //collision.gameObject.GetComponent<Animation>().Play("EnemyPing");
            collision.gameObject.GetComponent<Animation>().enabled = true;
        }
    }
}
