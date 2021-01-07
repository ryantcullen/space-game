using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooClose : FsmCondition {

    public float range;

	private ShipAI Ship;

	void Start()
	{
		Ship = GetComponent<ShipAI> ();
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {
	
		if (Ship.distBetween < range) {
			return true;
		}
		else
		{
			return false;
		}
	}
}
