using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosAdjust : MonoBehaviour
{
    [HideInInspector]
    public GameObject playerShip;
    private FloatCorrection floatCorr;
    [HideInInspector]
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.Find("Float Manager");
        floatCorr = playerShip.GetComponent<FloatCorrection>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null || !player.activeSelf)
        {
            if(floatCorr.didSnap == true)
            {
                transform.position -= floatCorr.positionAdjust;
            }
        }
    }
}
