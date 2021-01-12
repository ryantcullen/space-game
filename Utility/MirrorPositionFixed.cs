using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPositionFixed : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = target.transform.localPosition;
        transform.localRotation = target.transform.localRotation;
    }
}
