using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currenthealth=100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthDamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth < 0)
        {
            DestroyObject();
        }
    }

    private  void DestroyObject()
    {
        Destroy(gameObject);
    }
}
