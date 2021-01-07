using System.Collections;
using System.Collections.Generic;
using EZ_Pooling;
using UnityEngine;


public class Hunt : FsmState {
	
	public float fireRange;
	public float fireRate = .1F;
	public float bulletSpeed;
	private float nextFire = 0.0F;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	private ShipAI ship;
	public float fireAngleMin;
	bool outOfRange;
	public float timer;
	

	[HideInInspector]
	public GameObject targetPlaceholder;

	void Awake() {
		ship = GetComponent<ShipAI> ();
		targetPlaceholder = ship.target;
	}

	void OnEnable()
	{
		targetPlaceholder = ship.target;
		timer = 0f;
		
	}
	void OnDisable()
	{
		targetPlaceholder = null;
		StopAllCoroutines();
	}

	void Update()
	{	
		
		if (ship.target != null) 
		{	
			// Fire if target is in range
			if (ship.distBetween < fireRange) 
			{
				Vector3 targetVector = Vector3.Normalize(ship.target.transform.position - transform.position);
				if (Vector3.Dot(transform.forward, targetVector) > fireAngleMin && Time.time > nextFire)
				{
					Shoot ();
					nextFire = Time.time + fireRate;
				}
				else
				{
					timer += Time.deltaTime;
				}

				if(outOfRange == true)
				{
					StopAllCoroutines();
				}
				outOfRange = false;
			}
			else
			{
				if(outOfRange == false)
				{
					StartCoroutine(ship.FindEnemiesInRange());
					StartCoroutine(ship.AcquireTarget());
				}
				outOfRange = true;
			}

			ship.TurnToTarget();
		}
	}


	void FindNewTarget()
	{

	}



	void Shoot()
	{
		Transform currentBullet = EZ_PoolManager.Spawn(bulletPrefab.transform, bulletSpawn.position, bulletSpawn.rotation);
	}
}
