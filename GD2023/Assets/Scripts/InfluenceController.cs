using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InfluenceType
{
    none,
    blood,
    holy
}
public class InfluenceController : MonoBehaviour
{
    [SerializeField]
    private InfluenceType _influenceType;
    private float _influence;

    private SphereCollider _influenceArea;
    
    void Start()
    {
        //TODO: Load influence from save

        _influence = 0;

        _influenceArea = GetComponent<SphereCollider>();
    }

    public void IncreaseInfluence(float amount)
    {
        _influence += amount;
    }

    public void DecreaseInfluence()
    {
        
    }
    
}
