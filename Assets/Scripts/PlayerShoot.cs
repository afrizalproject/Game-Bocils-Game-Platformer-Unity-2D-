using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject peluru;
    public Transform shotPoint;

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(peluru, shotPoint.position, transform.rotation);
        }
    }
}
