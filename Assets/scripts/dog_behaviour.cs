using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_behaviour : MonoBehaviour
{
    public GameObject dog;
    //public Rigidbody2D rb_dog;
    public bool Command =false;
    Transform target;
    Transform enemy;
    public float speed = 5f;
    public bool isGrounded3 = false;
    public bool notGrounded = true;
    public bool notGrounded_voor = true;
    Transform jumppoint;

    // Start is called before the first frame update
    void Start()
    {
        //rb_dog = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Command == true)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
            if (Vector2.Distance(transform.position, enemy.position) < 12f && isGrounded3 == true)
            {
                //Debug.Log(" ATTACK ENEMY");
                transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
                
                if(Vector2.Distance(transform.position, enemy.position) < 1f)
                {
                    //Debug.Log("ATTACKED");
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                    Command = false;
                }
            }
            //Debug.Log("DONE");
        }
        else if (Vector2.Distance(transform.position, target.position) > 0.5f && isGrounded3 == true && Command== false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        else
        {
            //Debug.Log("DOG DOES NOTHING");
        }

        if (notGrounded == true && isGrounded3 == true)
        {
            Jump(1f);
        }

        if (notGrounded_voor == true && isGrounded3 == true)
        {
            Jump(-1f);
        }

        
    }

    void Jump(float richting)
    {
        jumppoint = GameObject.FindGameObjectWithTag("jumpPoint").GetComponent<Transform>();

        if (Vector2.Distance(transform.position, jumppoint.position) < 1f)
        {

        }
    }
}
