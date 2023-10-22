using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] int cameraHeight;
    [SerializeField] int cameraZOffset;

    Transform playerTrans;


    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        print(playerTrans.position);
    }

    private void Update()
    {
        transform.position = playerTrans.position + new Vector3(0, cameraHeight - playerTrans.position.y, -cameraZOffset);
    }
}
