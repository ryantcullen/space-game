using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : Ship {
	public float rotationSpeed;
	public float rotationDamp;
	[Header("Detection")]
	public float detectionRange;
	public float detAngleMin;
	public string targetTag;
	[HideInInspector]
	public Vector3 angles;
	[HideInInspector]
	public GameObject aimVec;
	[HideInInspector]
	public float distBetween;
	[HideInInspector]
	public GameObject target;
	[HideInInspector]
	public List<GameObject> enemiesInRange;
	private Transform parentT;
	private float timer;
	private int healthPlaceholder;
	private Vector3 lookVector;


	void Start()
	{
		timer = 0f;
		healthPlaceholder = health;
		angles = aimVec.transform.eulerAngles;
		parentT = transform.parent;
	}

	void Update()
	{
		Thrust();
		timer += Time.deltaTime;

		if(health <= 0)
		{
			Die();
		}

		if (health != healthPlaceholder && timer > 0.1f)
		{
			timer = 0f;
			healthPlaceholder = health;
		}
		if(timer > 0.5f)
		{
			timer = 0f;
		}

		if (target != null) {
			distBetween = Vector3.Distance (transform.position, target.transform.position);
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, aimVec.transform.rotation, Time.deltaTime * rotationDamp);
	}

	public IEnumerator FindEnemiesInRange() 
	{
    	for(;;) 
    	{
        	EnemiesInRange(detectionRange);
        	yield return new WaitForSeconds(1f);
    	}
	}

	public IEnumerator AcquireTarget() 
	{
    	for(;;) 
    	{
        	FindTargetInSight(detAngleMin);
        	yield return new WaitForSeconds(0.2f);
    	}
	}


	public void Thrust()
	{
        parentT.Translate(transform.forward * Time.deltaTime * thrust);
	}

	public void Roll(int n)
	{
		angles.z += n * zThrust * Time.deltaTime;
		Quaternion wantedRotation = Quaternion.Euler(angles);
		aimVec.transform.rotation = wantedRotation;
	}

	public void Yaw(int n)
	{
		angles.y += n * yThrust * Time.deltaTime;
		Quaternion wantedRotation = Quaternion.Euler(angles);
		aimVec.transform.rotation = wantedRotation;
	}

	public void Pitch(int n)
	{
		angles.x += n * xThrust * Time.deltaTime;
		Quaternion wantedRotation = Quaternion.Euler(angles);
		aimVec.transform.rotation = wantedRotation;
	}

	public void FindTargetInSight(float detAngle)
    {
        float dotAngle = -1f;
		Vector3 targetVector = Vector3.zero;
		float currDot = 0f;

        if(enemiesInRange.Count==0)
        {
            target = null;
        }

        foreach(GameObject go in enemiesInRange)
        {
			if(go == null)
			{
				continue;
			}

            targetVector = Vector3.Normalize(go.transform.position - transform.position);
            currDot = Vector3.Dot(transform.forward, targetVector);

            if(currDot > detAngle)
            {
                if(currDot > dotAngle)
                {
                    dotAngle = currDot;
                    target = go;
                }
            }
        }
    }

    public void EnemiesInRange(float detRange)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(targetTag);

		Vector3 position = transform.position;

		foreach(GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.magnitude;

			if (curDistance < detRange) {
                enemiesInRange.Add(go);
			} 
		}
	}

	public GameObject FindClosestTarget()
	{
		GameObject closest = null;
		float distance = Mathf.Infinity;

		Vector3 position = transform.position;

		foreach(GameObject go in enemiesInRange)
		{
			if(go == null)
			{
				continue;
			}

			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;

			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			} 
		}
		return closest;
	}

	public void TurnToTarget()
	{
		lookVector = Vector3.Normalize(target.transform.position - transform.position);
		Quaternion wantedRotation = Quaternion.LookRotation (lookVector);
		aimVec.transform.rotation = Quaternion.RotateTowards (aimVec.transform.rotation, wantedRotation, rotationSpeed);
	}

	public int PosNeg()
    {
        return Random.Range(0,2)*2-1;
    }
}
