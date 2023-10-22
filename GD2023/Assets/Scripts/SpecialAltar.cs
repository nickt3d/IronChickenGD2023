using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAltar : MonoBehaviour
{
    [SerializeField] SpecialAltarType altarType;
    [SerializeField] int bloodCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

public enum SpecialAltarType
{
    Blood,
    Health,
    Speed
}
