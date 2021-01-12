using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
