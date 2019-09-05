using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public ParticleSystem ps;

    public enum OnPickup
    {
        Emit_Particles,
        Rrmove_Object
    }

    public OnPickup PickupAction;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScore();


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
