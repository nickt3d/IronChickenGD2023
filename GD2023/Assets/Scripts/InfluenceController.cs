using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

enum InfluenceType
{
    none,
    blood,
    holy
}
public class InfluenceController : MonoBehaviour
{
    [SerializeField] private InfluenceType _influenceType;
    [SerializeField] private Transform areadisplay; // This is either the light beams of the blood clouds depending on influence type
    
    [SerializeField] private VolumeProfile bloodInfluenceVolume;
    [SerializeField] private VolumeProfile holyInfluenceVolume;
    
    private float _influenceAmount;
    private CapsuleCollider _influenceArea;
    private Volume _influenceVolume;
    private ParticleSystem _influenceParticles;

    [SerializeField] private TextMeshProUGUI influenceDisplay;


    //Clamp influence in this range
    private float _minInfluence = 25f;
    private float _maxInfluence = 100f;

    private float influenceDecayTimer;

    private int decay = 1;

    //[SerializeField] private SphereCollider SacrificeZone;

    public Action<int> OnUpgrade;
    
    private bool active = false;
    
    void Start()
    {
        //TODO: Load influence from save

        _influenceAmount = 25f;
        _influenceVolume = GetComponent<Volume>();
        _influenceArea = GetComponent<CapsuleCollider>();
        _influenceParticles = GetComponentInChildren<ParticleSystem>();

        if (_influenceType == InfluenceType.holy)
        {
            _influenceVolume.profile = holyInfluenceVolume;
        }
        else
        {
            _influenceVolume.profile = bloodInfluenceVolume;
        }

        influenceDecayTimer = 0;

        OnUpgrade += UpdateInfluence;
    }

    public void UpdateInfluence(int amount)
    {
        _influenceAmount = Mathf.Clamp(_influenceAmount+amount, _minInfluence, _maxInfluence);
        _influenceArea.radius = _influenceAmount;
        var shape = _influenceParticles.shape;
        shape.radius = _influenceAmount;

        if (active)
        {
            influenceDisplay.SetText("Influence: " + _influenceAmount);
        }


        if (amount > 0)
        {
            Debug.Log("Influence Increased to: " + _influenceAmount);
        }
    }

    void Update()
    {
        if (influenceDecayTimer >= _influenceAmount)
        {
            DecayInfluence();
            //reset timer
            influenceDecayTimer = 0f;
        }
        else
        {
            influenceDecayTimer += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            var bloodController = collider.GetComponent<BloodController>();
            
            //Make the player stop losing blood, and has power boost
            if (_influenceType == InfluenceType.blood)
            {
                bloodController.safeZone = true;
                influenceDisplay.gameObject.SetActive(true);
                influenceDisplay.SetText("Influence: " + _influenceAmount);
                active = true;
            }
            else if (_influenceType == InfluenceType.holy)
            {
                bloodController.dangerZone = true;
                
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            var bloodController = collider.GetComponent<BloodController>();
            
            if (_influenceType == InfluenceType.blood)
            {
                bloodController.safeZone = false;
                influenceDisplay.gameObject.SetActive(false);
                active = false;
            }
            else if (_influenceType == InfluenceType.holy)
            {
                bloodController.dangerZone = false;
            }
        }
    }

    void DecayInfluence()
    {
        UpdateInfluence(-decay);
    }

}
