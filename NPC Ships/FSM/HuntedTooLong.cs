using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntedTooLong : FsmCondition {

	private Hunt hunt;
    public float huntTime;

	void Start()
	{
		hunt = GetComponent<Hunt> ();
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {
	
		if (hunt.timer > huntTime) {
			return true;
		}
		else
		{
			return false;
		}
	}
}
