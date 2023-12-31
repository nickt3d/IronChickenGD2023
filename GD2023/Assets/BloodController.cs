using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using TMPro;
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

    [SerializeField]
    private Health health;

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
                    decayTimer = 0.15f;
                    health.Damage(1f, null, 0.1f, 0, Vector3.zero, null);
                }
                else
                {
                    RemoveBlood(1);
                    decayTimer = 1;
                    if (_bloodAmount <= 0.1)
                    {
                        health.Damage(1f, null, 0.1f, 0, Vector3.zero, null);
                    }
                }

                
            }
        }
        else
        {
            if (decayTimer <= 0)
            {
                
                decayTimer = 1;
            }
        }
        decayTimer -= Time.deltaTime;
    }

    public void AddBlood(int amount)
    {
        _bloodAmount = Mathf.Clamp(_bloodAmount+amount, 0, MaximumBlood);
        UpdateBloodBar();
    }

    public void RemoveBlood(int amount)
    {
        if (_bloodAmount > 0)
        {
            _bloodAmount = Mathf.Clamp(_bloodAmount - amount, 0, MaximumBlood);
            health.ReceiveHealth(amount, null);
            UpdateBloodBar();
        }
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
        bloodBar.GetComponentInChildren<TextMeshProUGUI>().SetText(_bloodAmount + "/" + 50);
    }

    public void IncreaseMaxBlood(int addedAmount)
    {
        MaximumBlood += addedAmount;
    }
}
