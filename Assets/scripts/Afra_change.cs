using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afra_change : MonoBehaviour
{
    public GameObject Weapon;

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("CHANGE");
        Debug.Log("DESTROY WEAPON");
        Destroy(Weapon);
       
    }
}
