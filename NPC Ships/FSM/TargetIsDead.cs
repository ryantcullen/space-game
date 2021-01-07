using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIsDead : FsmCondition {

	private ShipAI Ship;

	void Start()
	{
		Ship = GetComponent<ShipAI> ();
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {

		ShipAI Ship = GetComponent<ShipAI> ();
	
		if (Ship.target == null) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
