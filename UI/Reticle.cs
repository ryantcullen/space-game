using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public GameObject target;
    RaycastHit hit;
    public float range;
    public float radius;    
    public float reticleDamping;
    public float dotAngleMin;
    private Camera cam; 
    public GameObject reticle;
    Vector3 zeroZ;

    void Start()
    {
        FindTarget();
        cam = Camera.main;
        zeroZ = new Vector3(1,1,0);
    }
    void Update()
    {
        if(target == null)
        {
            FindTarget();
        }
        ReticlePosition();
    }

    void FindTarget()
    {
        target = null;
        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, range))
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                target = hit.collider.gameObject;
            }
            else
            {
                target = null;
            }
        }
    }

    void ReticlePosition()
    {
        if(target != null)
        {
            Vector3 targetVector = Vector3.Normalize(target.transform.position - transform.position);

            if(Vector3.Dot(transform.forward, targetVector) > dotAngleMin && Vector3.Distance(transform.position, target.transform.position) < range)
            {
                Debug.Log(Time.deltaTime);
                Vector3 screenPos = cam.WorldToScreenPoint(target.transform.position);
		        Vector3 currentPosition = Vector3.Lerp (reticle.GetComponent<RectTransform>().position, screenPos, reticleDamping * Time.deltaTime);
		        reticle.GetComponent<RectTransform>().position = Vector3.Scale(currentPosition, zeroZ);
            }
            else
            {
                target = null;
            }
        }
        else
        {
            Vector3 currentPosition = Vector3.Lerp (reticle.GetComponent<RectTransform>().localPosition,  Vector3.zero, reticleDamping * Time.deltaTime);
            reticle.GetComponent<RectTransform>().localPosition = Vector3.Scale(currentPosition, zeroZ);
        }
        
    }

}
