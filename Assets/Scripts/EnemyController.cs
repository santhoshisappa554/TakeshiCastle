using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyMoveSpeed;
    public Rigidbody rb;
    public Transform target;
    public bool chasing;
    public NavMeshAgent agent;
    Vector3 startPoint;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = PlayerController.instance.transform.position;

        transform.LookAt(PlayerController.instance.transform.position + new Vector3(0, 1.5f, 0));
        Vector3 targetDirection = PlayerController.instance.transform.position - transform.position;
    } 
}            