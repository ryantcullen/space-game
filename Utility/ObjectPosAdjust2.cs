using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosAdjust2 : MonoBehaviour
{
    public GameObject playerShip;
    private FloatCorrection floatCorr;
    // Start is called before the first frame update
    void Start()
    {
        floatCorr = playerShip.GetComponent<FloatCorrection>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
