using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject mat;
    public GameObject currentmat;
    Stack<GameObject> matPool = new Stack<GameObject>();
    private static ObjectPooling instance;


    public static ObjectPooling Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ObjectPooling>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Createmat();  
            
        }





    
    public void CreatePool(int value)
    {
        for (int i = 0; i < value; i++)
        {
            matPool.Push(Instantiate(mat));
            matPool.Peek().SetActive(false);
            matPool.Peek().name = "mat";

        }


    }
    public void AddmatToPool(GameObject mattemp)
    {
        matPool.Push(mattemp);
        matPool.Peek().SetActive(false);
    }
    public void Createmat()
    {
        if (matPool.Count == 0)
        {
            CreatePool(5);
        }
        GameObject temp = matPool.Pop();
        temp.SetActive(true);
        temp.transform.position = transform.position;
        currentmat = temp;
    }
}
