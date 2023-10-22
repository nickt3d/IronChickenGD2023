using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterBloodSacrifice : MonoBehaviour
{
    [SerializeField]
    private InfluenceController _influenceController;
    
    private int cost;

    private bool canSacrifice = false;

    //public Action<int> OnSacrifice;

[SerializeField]
    private ParticleSystem BloodExplode;

    private void Start()
    {
        cost = 1; //pull the cost from the influence controller
        canSacrifice = false;
        Instantiate(BloodExplode, transform);
        //OnSacrifice += Sacrificed;
        
    }

    void Update()
    {
        if (canSacrifice)
        {
            //Show the prompt for sacrificing blood on HUD
            
        }
    }
    
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {  
            //Allow player to sacrifice blood at the alter
            var playerBlood = collider.GetComponent<BloodController>();
            if (playerBlood.GetAmount() >= cost)
            {
                int amount = (int)playerBlood.GetAmount();
                playerBlood.OnSacrifice.Invoke(amount);
                Sacrificed(amount);
                canSacrifice = true;
                BloodExplode.Play();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //OnSacrifice = null;
            canSacrifice = false;
        }
    }

    public void Sacrificed(int amount)
    {
        //if (OnSacrifice != null)
        //{
        //    OnSacrifice.Invoke(amount);
        //}
        _influenceController.UpdateInfluence(amount/5);

        canSacrifice = false;


    }
}
