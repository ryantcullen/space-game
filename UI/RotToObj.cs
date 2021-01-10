using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotToObj : MonoBehaviour
{
    public Transform Spot;
    

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Spot.rotation;
    }
}
