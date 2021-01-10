using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObj : MonoBehaviour
{
    public Transform Spot;
    public float positionDamp;
    public float rotationDamp;
    
    private Quaternion wantedRotation;
    private Quaternion currentRotation;
    private Vector3 wantedPosition;
    private Vector3 currentPosition;

    // Update is called once per frame
    void Update()
    {
       moveTo();
    }

    void FixedUpdate()
    {
        
    }

    void moveTo()
    {
        wantedRotation = Spot.rotation;
        currentRotation = Quaternion.Lerp(transform.rotation, wantedRotation, rotationDamp * Time.deltaTime);
        transform.rotation = wantedRotation;
        wantedPosition = Spot.position;
        currentPosition = Vector3.Lerp (transform.position, wantedPosition, positionDamp * Time.deltaTime);
		transform.position = wantedPosition;
    }


}
