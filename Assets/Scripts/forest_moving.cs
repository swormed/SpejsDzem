using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forest_moving : MonoBehaviour {

    public Vector3 pos = new Vector3(0f, 0f, 0);
    void OnTriggerEnter(Collider collider)
    {
        collider.transform.position = pos;

    }
}
