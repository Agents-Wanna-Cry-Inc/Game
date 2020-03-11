using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_notGr_voor : MonoBehaviour
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
        if (collision.collider.tag == "Ground")
        {
            dog.GetComponent<dog_behaviour>().notGrounded_voor = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            dog.GetComponent<dog_behaviour>().notGrounded_voor = true;
        }

    }
}
