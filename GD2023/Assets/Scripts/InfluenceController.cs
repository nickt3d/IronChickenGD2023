using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceController : MonoBehaviour
{
    private float _influence;

    private SphereCollider _influenceArea;
    
    void Start()
    {
        //TODO: Load influence from save

        _influence = 0;

        _influenceArea = GetComponent<SphereCollider>();
    }
    
    void Update()
    {
        
    }

    public void IncreaseInfluence(float amount)
    {
        _influence += amount;
    }
}
