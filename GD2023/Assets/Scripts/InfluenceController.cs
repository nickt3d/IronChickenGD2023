using System.Collections;
using System.Collections.Generic;
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
    
    //Clamp influence in this range
    private float _minInfluence = 25f;
    private float _maxInfluence = 100f;

    private float influenceDecayTimer;

    private float decay = 1f;
    
    void Start()
    {
        //TODO: Load influence from save

        _influenceAmount = 25f;
        _influenceVolume = GetComponent<Volume>();
        _influenceArea = GetComponent<CapsuleCollider>();

        if (_influenceType == InfluenceType.holy)
        {
            _influenceVolume.profile = holyInfluenceVolume;
        }
        else
        {
            _influenceVolume.profile = bloodInfluenceVolume;
        }

        influenceDecayTimer = 0;
    }

    public void UpdateInfluence(float amount)
    {
        _influenceAmount = Mathf.Clamp(_influenceAmount+amount, _minInfluence, _maxInfluence);
        _influenceArea.radius = _influenceAmount;
        areadisplay.localScale = Vector3.one * (_influenceAmount * 2);
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

    void DecayInfluence()
    {
        UpdateInfluence(-decay);

    }

}
