using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject explosionPrefab;
    float cameraOffset;

    void Start()
    {
        //cameraOffset = Camera.main.transform.position.z - GameManager.
    }

    void Update()
    {
        checkForClick();
    }

    void checkForClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            explode();
        }
    }

    void explode()
    {
        GameObject explosion = Instantiate(explosionPrefab);

        Vector3 position = Input.mousePosition;
        position.z = 10f;

        position = Camera.main.ScreenToWorldPoint(position);
        explosion.transform.position = position;

        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }
}
