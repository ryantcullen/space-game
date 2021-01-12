using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitRotator : MonoBehaviour
{

    private float x;
    private float y;
    private float z;
    Quaternion wantedRotation;
    Vector3 wantedEulerAngles;
    Quaternion currentRotation;
    public float rotDamp;
    public float rotScale;
    public PilotSeat PilotSeat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PilotSeat.inSeat)
        {
            x = Input.GetAxis ("Vertical") * rotScale;
            y = Input.GetAxis ("Horizontal") * rotScale;
            z = -Input.GetAxis ("Horizontal2") * rotScale;

            wantedEulerAngles = new Vector3(x, y, z);
            wantedRotation = Quaternion.Euler(wantedEulerAngles);
            currentRotation = Quaternion.Slerp(transform.localRotation, wantedRotation, rotDamp*Time.deltaTime);

            transform.localRotation = currentRotation;
        }
        else
        {
            transform.localRotation = Quaternion.identity;
        }

    }
}
