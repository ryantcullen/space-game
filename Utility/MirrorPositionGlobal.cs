using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPositionGlobal : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position;
        transform.rotation = target.transform.rotation;
    }
}
