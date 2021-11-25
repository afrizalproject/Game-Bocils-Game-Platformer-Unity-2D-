using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition; //ambil posisi player
    public Vector3 offset; //atur posisi kamera
    public float cameraSpeed; //speed camera

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPosition.position+offset, cameraSpeed*Time.deltaTime);
    }
}
