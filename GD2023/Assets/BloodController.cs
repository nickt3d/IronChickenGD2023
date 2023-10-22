using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{

    private int _bloodAmount; 

    private int _bloodMax = 50; //This can be increased by sacrificing blood at special alters

    private float decayTimer;

    public Action<int> OnSacrifice;

    public bool safeZone;
    public bool dangerZone;

    // Start is called before the first frame update
    void Start()
    {
        _bloodAmount = 15;
        decayTimer = 3;
        OnSacrifice += RemoveBlood;
        safeZone = false;
        dangerZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Decay Blood
        if (!safeZone)
        {
            if (decayTimer <= 0)
            {
                if (dangerZone)
                {
                    RemoveBlood(1);
                    decayTimer = 1;
                }
                else
                {
                    RemoveBlood(1);
                    decayTimer = 3;
                }

                
            }
            else
            {
                decayTimer -= Time.deltaTime;
            }
        }
        else
        {
            decayTimer = 3;
        }


    }

    public void AddBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount+amount, 0, _bloodMax);
    }

    public void RemoveBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount-amount, 0, _bloodMax);
        Debug.Log("Blood Remaining: " + _bloodAmount);
    }

    public int GetAmount()
    {
        return _bloodAmount;
    }
}
