using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rbbullet;
    float bulletspeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rbbullet = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        rbbullet.velocity = Vector3.left * bulletspeed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        StartCoroutine("BulletAddToPool");
    }


    IEnumerator BulletAddToPool()
    {
        yield return new WaitForSeconds(1);

        if (rbbullet.gameObject.name == "Bullet")
        {
            BulletOP.Instance.AddBulletToPool(rbbullet.gameObject);
        }
    }
    
}
