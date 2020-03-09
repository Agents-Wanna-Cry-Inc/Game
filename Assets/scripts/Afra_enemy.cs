using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afra_enemy : MonoBehaviour
{
    Transform target;
    public float speed = 5f;
    float stoppingDistance = 13.6236f;
    float returnDistance = 9.6236f;

    public GameObject enemy;
    public bool notGrounded = true;
    public bool notGrounded_achter = true;
    public bool isGrounded2 = false;
    public Transform shotPoint;
    public float tellerAvoid = 2;
    public float jumpteller = 3f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && notGrounded==false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

        else if(Vector2.Distance(transform.position, target.position) < stoppingDistance  && Vector2.Distance(transform.position, target.position) > returnDistance)
        {
            transform.position = this.transform.position;
            //shoot
        }


        else if (Vector2.Distance(transform.position, target.position) < returnDistance)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 2, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (notGrounded_achter == true && notGrounded == true && isGrounded2 == true)
        {
                // do nothing, you're in the air 
        }

        if(notGrounded == true && isGrounded2 == true)
        {
            Debug.Log("JUMP FORWARD");
            Jump();
        }
                
            
        if ( notGrounded_achter == true && isGrounded2 == true)
        {
            if(jumpteller > 0)
            {
                Jump();
                Debug.Log("JUMP BACK");
                jumpteller -= 1;
            }
            else
            {
                Debug.Log("STAND");
                returnDistance = 0;
                transform.position = this.transform.position;
                
            }
                
        }
        

        if (Vector2.Distance(transform.position, shotPoint.transform.position) < 10.6f && tellerAvoid>0)
        {
            Debug.Log("TRY TO AVOID BULLET");
            Avoid();
            tellerAvoid -= 1;
        }
        
        if (enemy.transform.position.y < - 70)
        {
            Destroy(enemy);
        }
    }

    void Avoid()
    {
        //Jump();
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2), ForceMode2D.Impulse); //omhoog
        GetComponent<Rigidbody2D>().velocity = new Vector2( -1 * 2, GetComponent<Rigidbody2D>().velocity.y); //naar voren
    }
}
