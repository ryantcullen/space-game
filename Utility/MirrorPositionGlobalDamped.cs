using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPositionGlobalDamped : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    Vector3 wantedPosition;
    Vector3 currentPosition;
    Quaternion wantedRotation;
    Quaternion currentRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        wantedPosition = target.transform.position;
        currentPosition = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 10f);
        transform.position = currentPosition;

        wantedRotation = target.transform.rotation;
        currentRotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * 10f);
        transform.rotation = currentRotation;
    }
}
