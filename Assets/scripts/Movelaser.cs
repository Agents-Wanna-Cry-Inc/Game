using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movelaser : MonoBehaviour
{
    public float Speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Speed, 0f, 0f);
        transform.position += movement * Time.deltaTime;
    }
}
