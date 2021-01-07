using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implementation of FsmCondition whose condition is never satisfied.
/// </summary>
public class FsmCondFalse : FsmCondition {

	public override bool IsSatisfied (FsmState curr, FsmState next) {
		return false;
	}
}
