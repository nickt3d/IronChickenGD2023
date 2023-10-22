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

    // Start is called before the first frame update
    void Start()
    {
        _bloodAmount = 15;
        decayTimer = 3;
        OnSacrifice += RemoveBlood;
    }

    // Update is called once per frame
    void Update()
    {
        //Decay Blood
        if (decayTimer <= 0)
        {
            RemoveBlood(1);
            decayTimer = 3;
        }
        else
        {
            decayTimer -= Time.deltaTime;
        }
    }

    public void AddBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount+amount, 0, _bloodMax);
    }

    public void RemoveBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount-amount, 0, _bloodMax);
    }

    public int GetAmount()
    {
        return _bloodAmount;
    }
}
