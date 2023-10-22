using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterBloodSacrifice : MonoBehaviour
{

    private InfluenceController _influenceController;
    
    public int cost;
    
    public Action<int> sacrificeBlood;

    private void Start()
    {
        cost = 10;
        sacrificeBlood += _influenceController.OnUpgrade;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {  
            //Allow player to sacrifice blood at the alter
            var playerBlood = collider.GetComponent<BloodController>();
            sacrificeBlood += playerBlood.OnSacrifice;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Allow player to sacrifice blood at the alter
            var playerBlood = collider.GetComponent<BloodController>();
            sacrificeBlood -= playerBlood.OnSacrifice;
            
        }
    }
}
