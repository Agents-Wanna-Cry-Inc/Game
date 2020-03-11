using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_grounded : MonoBehaviour
{
    GameObject dog;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindWithTag("Player");
        dog = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "moving_ground")
        {
            dog.GetComponent<dog_behaviour>().isGrounded3 = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "moving_ground")
        {
            dog.GetComponent<dog_behaviour>().isGrounded3 = false;
        }

    }
}

