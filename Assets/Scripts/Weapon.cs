using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet; 
    public Transform muzzle;
    public float force = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            Shoot(); 

        }
    }

    void Shoot()
    {
        
        GameObject go = Instantiate(bullet, muzzle);
        go.GetComponent<Rigidbody>().AddForce(muzzle.forward * force); 


    }
}
