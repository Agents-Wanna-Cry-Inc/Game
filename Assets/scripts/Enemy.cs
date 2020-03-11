using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Take Damage");
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
     if(health <= 0)
        {
            Debug.Log("ENEMY SHOULD DIE");
            Destroy(gameObject);
        }   
    }
}
