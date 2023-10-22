using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBloodSacrifice : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {  
            //Allow player to sacrifice blood at the alter
        }
    }
}
