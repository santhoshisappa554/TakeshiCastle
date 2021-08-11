using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnLocation : MonoBehaviour
{
    public Transform KeySpawnPoints;
    Transform[] spawnPoints;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = KeySpawnPoints.GetComponentsInChildren<Transform>();
        print(spawnPoints.Length);
        spawn();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void spawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }
}
