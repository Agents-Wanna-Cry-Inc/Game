using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afra_move_on : MonoBehaviour
{
    bool moving = false;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            collision.collider.transform.SetParent(null);
            //moving = false;
        }

    }
}
