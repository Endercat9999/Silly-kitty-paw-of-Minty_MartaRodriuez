using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gato_menta : MonoBehaviour
{
    public Rigidbody2D rBody; 

    public GraundSensor sensor;

    public SpriteRenderer render;

    public Animator anim;

    AudioSource source;
    
    public Vector3 newPosition = new Vector3(50, 5, 0);

    public float jumpforce = 5;

    public float movementSpeed = 5;

    private float inputHorizontal;

    public bool jump = false;

    public AudioClip jumpSound; 


    void Awake()
    {
    source = GetComponent <AudioSource>();
    render = GetComponent <SpriteRenderer>();
    rBody = GetComponent<Rigidbody2D>();
    anim = GetComponent <Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;


         if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {
            
           rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
           anim.SetBool("IsJumping", true); 
           source.PlayOneShot(jumpSound);
        }
        
         if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {
            
           rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
           anim.SetBool("IsJumping", true); 
        }

        if(inputHorizontal < 0)
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if (inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
          anim.SetBool("IsRunning", false);   
        }
    }

     void FixedUpdate() 
    {
      rBody.velocity = new Vector2(inputHorizontal * movementSpeed * Time.deltaTime, rBody.velocity.y);  
    }
}
