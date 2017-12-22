using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerRotation : MonoBehaviour
{

    public float rotateSpeed = 3.0f; //set it in the  inspector

    void Update()
    {
        rotate();
    }


    void rotate()
    {

        transform.Rotate(Vector3.forward*rotateSpeed);
    }
}