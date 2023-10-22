using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOrbCollectable : MonoBehaviour
{
    private int value;

    void Awake()
    {
        value = Random.Range(5, 10);
    }

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
