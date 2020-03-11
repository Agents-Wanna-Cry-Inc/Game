using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindWithTag("Player");
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" || collision.collider.tag == "moving_ground")
        {
            Player.GetComponent<move2D>().isGrounded = true;
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "moving_ground")
        {
            Player.GetComponent<move2D>().isGrounded = false;
        }
        
    }
}
