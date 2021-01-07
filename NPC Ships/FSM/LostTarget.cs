using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostTarget : FsmCondition {

	private ShipAI Ship;
	private Hunt huntScript;

	void Start()
	{
		Ship = GetComponent<ShipAI> ();
        huntScript = GetComponent<Hunt>();
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {
	
		if (Ship.target != huntScript.targetPlaceholder) 
		{
			if(Ship.target == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		else
		{
			return false;
		}
	}
}
