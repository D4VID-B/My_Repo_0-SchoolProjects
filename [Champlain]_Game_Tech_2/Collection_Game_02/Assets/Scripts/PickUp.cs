using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public ParticleSystem ps;
    //public GameManager gm;

    public enum OnPickup
    {
        Emit_Particles,
        Rrmove_Object
    }

    public OnPickup PickupAction;

    private void OnTriggerEnter(Collider other)
    {

        if(gameObject.tag == "Core01")
        {
            GameManager.instance.ChangeScore(1);

        }
        else if(gameObject.tag == "Core02")
        {
            GameManager.instance.ChangeScore(5);

        }
        else if(gameObject.tag == "Core03")
        {
            GameManager.instance.ChangeScore(10);

        }



        if (PickupAction == OnPickup.Emit_Particles)
        {
            ps.Play();
        }
        else if(PickupAction == OnPickup.Rrmove_Object)
        {
            gameObject.SetActive(false);
        }
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
