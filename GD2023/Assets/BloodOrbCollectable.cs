using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOrbCollectable : MonoBehaviour
{
    public int value;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Add blood to the player resource counter
            collider.GetComponent<BloodController>().AddBlood(value);
            Destroy(gameObject);
        }
    }
}
