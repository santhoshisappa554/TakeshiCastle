using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Enemy collided");
            
            Destroy(collision.gameObject);
            //DontDestroyOnLoad(Health);
        }

    }
}
