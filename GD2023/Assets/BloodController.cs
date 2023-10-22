using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{

    private float _bloodAmount; 

    private float MaximumBlood = 50; //This can be increased by sacrificing blood at special alters

    private float decayTimer;

    public Action<int> OnSacrifice;

    public bool safeZone;
    public bool dangerZone;

    [SerializeField]
    private Slider bloodBar;

    // Start is called before the first frame update
    void Start()
    {
        _bloodAmount = 15;
        decayTimer = 3;
        OnSacrifice += RemoveBlood;
        safeZone = false;
        dangerZone = false;
        
        bloodBar = GameObject.Find("BloodBarUI").GetComponent<Slider>(); 
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
        _bloodAmount = Mathf.Clamp(_bloodAmount+amount, 0, MaximumBlood);
        UpdateBloodBar();
    }

    public void RemoveBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount-amount, 0, MaximumBlood);
        Debug.Log("Blood Remaining: " + _bloodAmount);
        UpdateBloodBar();
    }

    public float GetAmount()
    {
        return _bloodAmount;
    }
    
    public void UpdateBloodBar()
    {
        if (bloodBar == null)
        {
            bloodBar = GameObject.Find("BloodBarUI").GetComponent<Slider>();
        }
        bloodBar.minValue = 0;
        bloodBar.maxValue = MaximumBlood;
        bloodBar.value = _bloodAmount;
    }
}
