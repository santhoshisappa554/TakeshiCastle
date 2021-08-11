using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Background");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            AudioManager.instance.StopPlayAudio("Background");
            FindObjectOfType<AudioManager>().PlayAudio("PlayerDeath");
        }
    }

}
