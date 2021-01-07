using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundTarget : FsmCondition {

	private ShipAI ship;
	private FindTarget findScript;

	void Start()
	{
		ship = GetComponent<ShipAI> ();
        findScript = GetComponent<FindTarget>();
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {
	
		if (ship.target != null && findScript.searchTime > 0.7f) 
		{
            return true;
		}
		else
		{
			return false;
		}
	}
}
