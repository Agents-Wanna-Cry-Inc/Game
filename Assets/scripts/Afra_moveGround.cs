using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afra_moveGround : MonoBehaviour
{

    private Vector3 PosA;
    private Vector3 PosB;
    private Vector3 nextPos;
    public float speed = 1f;

    public Transform childTransform;
    public Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        PosA = childTransform.localPosition;
        PosB = transformB.localPosition;
        nextPos = PosB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed*Time.deltaTime);
    
        if(Vector3.Distance(childTransform.localPosition, nextPos)<=0.1)
        {
            if(nextPos != PosA)
            { nextPos = PosA; }
            else { nextPos = PosB; }
        }
    }
}
