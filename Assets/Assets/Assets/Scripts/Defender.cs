using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        GameObject.FindObjectOfType<Attackers>().Attack(gameObject);
    }

    
}
