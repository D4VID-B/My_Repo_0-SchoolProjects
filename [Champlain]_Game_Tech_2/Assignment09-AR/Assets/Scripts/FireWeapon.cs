using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    bool canFire = true;


    void OnMouseDown()
    {
        if(canFire)
        {
            canFire = false;
            GetComponent<Renderer>().material.color = Color.red;
            Instantiate(bullet, new Vector3(-0.05f, 1.25f, -4.5f), Quaternion.Euler(90f, 0f, 0f));
            StartCoroutine(rechargeWeapon());
        }

        
    }

    IEnumerator rechargeWeapon()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(2);
        Debug.Log("Ready to Fire!");
        GetComponent<Renderer>().material.color = Color.green;
        canFire = true;
    }
}
