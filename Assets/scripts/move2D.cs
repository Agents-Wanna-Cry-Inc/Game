using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2D : MonoBehaviour
{
    // what we use for movement
    private float inputVertical;
    private float inputHorizontal;
    private Rigidbody2D rb;

    // the different kinds of speed 
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float climbSpeed = 5f;

    // bools that indicate what the player is doing
    public bool isGrounded = false;
    public bool isClimbing = false;

    // variables needed for climbing ladders
    public float distance = 5; // distane of the rays
    public LayerMask whatIsLadder; // indicates what we can climb using layers

    GameObject dog;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dog = GameObject.FindWithTag("dog");
    }

    // Update is called once per frame
    void Update()
    {
        // basic left-right movement using rigidbody
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, rb.velocity.y);

        //another possible way to get basig left-right movement using the transform instead of rigidbody
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;

        Jump(); // calling the jumping method
        Climb(); // used for climbing ladders   

        if (Input.GetKeyDown(KeyCode.C))
        {
            dog.GetComponent<dog_behaviour>().Command = true;
        }
        
    }


    void Climb()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitinfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                isClimbing = false;        
        }

        if (isClimbing == true && hitinfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "moving_ground")
        {
            this.transform.parent = collision.transform;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "moving_ground")
        {
            this.transform.parent = null;
        }

    }


}
