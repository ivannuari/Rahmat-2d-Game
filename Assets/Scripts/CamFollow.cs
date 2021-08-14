using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float speedCam;

    public Vector3 offset;

    void Update()
    {
        Vector3 target = player.position + offset;
        transform.position = Vector3.Lerp(transform.position , target , speedCam);
    }
}
