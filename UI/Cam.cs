using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject ghostCamera;
    public GameObject shipTarget;

    public PlayerShip ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(ship.inShip)
        {
            transform.parent = shipTarget.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            transform.parent = ship.transform.parent;
            transform.localPosition = ghostCamera.transform.localPosition;
            transform.localRotation = ghostCamera.transform.localRotation;
        }
        
    }
}
