using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InitVolumeTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetUniversalAdditionalCameraData().volumeTrigger = transform;     
    }
}
