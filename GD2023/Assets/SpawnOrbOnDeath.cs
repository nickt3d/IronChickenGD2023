using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class SpawnOrbOnDeath : MonoBehaviour
{
    public BloodOrbCollectable BloodOrb;

    void Awake()
    {
        var healthScript = GetComponent<Health>();
        healthScript.OnDeath += OnDeath;
    }

    public void OnDeath()
    {
        var orb = Instantiate(BloodOrb);
        orb.transform.position = transform.position;
    }
}
