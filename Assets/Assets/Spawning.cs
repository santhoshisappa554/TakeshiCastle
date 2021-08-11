using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    Rigidbody material;
    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {

            ObjectPooling.Instance.Createmat();
            

            //Debug.Log("Triggered");


        }
    }
    
}
