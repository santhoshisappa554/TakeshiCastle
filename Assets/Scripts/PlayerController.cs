using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController character;
    Vector3 moveinput;
    public Transform cameraTransform;
    public float mouseSenstivity;
    public bool invertX, invertY;
    Vector2 mouseInput;
    public float gravity;
    public float jumpForce;
    public bool canJump;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool canDoubleJump;
    public float runSpeed;
    public int score = 0;
    public Text scoreText;
    public float Health = 2;
    public Text healthText;
    /*public Animator anim;
    public Transform firePoint;
    public GameObject prefab;*/
    public static PlayerController instance;
    public float time;
    public Text timeText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timeText.text = "Time: " + Mathf.RoundToInt(time);

        if (Health == 0 || time<=0)
        {
            SceneManager.LoadScene(7);
        }
        
       
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 verMove = transform.forward * Input.GetAxis("Vertical");
        moveinput = horiMove + verMove;

        if (Input.GetKey(KeyCode.E))
        {
            moveinput = moveinput * runSpeed;
        }
        else
        {
            moveinput *= moveSpeed;
        }
        moveinput.y += Physics.gravity.y * gravity * Time.deltaTime;
        //jump Code
        canJump = Physics.OverlapSphere(groundCheck.position, 0.25f, groundMask).Length > 0;
        Debug.Log(canJump);
        if (canJump)
        {
            canDoubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Q) && canJump)
        {
            moveinput.y = jumpForce;
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && canDoubleJump)
        {
            moveinput.y = jumpForce;
            canDoubleJump = false;
        }

        character.Move(moveinput * Time.deltaTime);
        //camera rotation using mouseinput
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSenstivity;
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);


        //camera rotation
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(mouseInput.y, 0, 0));


       

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            score = score + 5;
            print("Score: " + score);
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("power"))
        {
            if (Health <= 1)
            {
                Health = Health + 1;
                healthText.text = "Health: " + Health;
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Key"))
        {
            SceneManager.LoadScene(8);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy collided");
            Health = Health - 1;
            healthText.text = "Health: " + Health;
        }
       
    }
}
