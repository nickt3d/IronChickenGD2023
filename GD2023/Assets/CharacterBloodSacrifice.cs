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

    public Action OnSacrifice;

[SerializeField]
    private ParticleSystem BloodExplode;

    private void Start()
    {
        cost = 10; //pull the cost from the influence controller
        canSacrifice = false;
        Instantiate(BloodExplode, transform);
    }

    void Update()
    {
        if (canSacrifice)
        {
            //Show the prompt for sacrificing blood on HUD
            Sacrificed();
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
                
                OnSacrifice += () => playerBlood.OnSacrifice.Invoke(cost);
                canSacrifice = true;
                BloodExplode.Play();
            }
            else
            {
                //not enough blood display
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            OnSacrifice = null;
            canSacrifice = false;
        }
    }

    public void Sacrificed()
    {
        OnSacrifice.Invoke();
        _influenceController.UpdateInfluence(5);
        
        canSacrifice = false;
        
        
    }

}
