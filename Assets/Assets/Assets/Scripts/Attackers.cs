using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour
{
    [Range(-1f, 2f)]
    public float lizardWalkSpeed;
    Animator lizardAnim;
    SpriteRenderer lizardSprite;
    public GameObject currentObject;
    public float currentdamage = 10.0f;
    Health health;
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        lizardAnim = GetComponent<Animator>();
        lizardSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health = GameObject.FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
       if (lizardWalkSpeed > 0)
         {
             lizardSprite.flipX = false;
             //lizardAnim.SetFloat("IsWalking", lizardWalkSpeed);
             transform.Translate(Vector3.left * lizardWalkSpeed * Time.deltaTime);

         }


       /*  if (lizardWalkSpeed < 0)
         {
             lizardSprite.flipX = true;
             lizardAnim.SetFloat("IsWalking", lizardWalkSpeed);
             transform.Translate(Vector3.left * lizardWalkSpeed * Time.deltaTime);

         }*/

        if (!currentObject)
        {
            anim.SetBool("IsAttacking", false);
        }


    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collied");
        anim.SetBool("IsAttacking", true);
        //Debug.Log("triggered with" + name);
        StrikeCurrentTarget(currentdamage);
    }
    public void SetSpeed(float speed)
    {
        lizardWalkSpeed = speed;
    }
    public void StrikeCurrentTarget(float currentdamages)
    {

        // Debug.Log(damage + " the damage" + name);
        Debug.Log("Strike");
        health.HealthDamage(currentdamages);
        
    }
    public void Attack(GameObject obj)
    {
        currentObject = obj;
    }
}
