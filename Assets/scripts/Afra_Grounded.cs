using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afra_Grounded : MonoBehaviour
{
    GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindWithTag("Player");
        Enemy = gameObject.transform.parent.gameObject;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Enemy.GetComponent<Afra_enemy>().isGrounded2 = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Enemy.GetComponent<Afra_enemy>().isGrounded2 = false;
        }

    }
}

