using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component representing a condition on which state transitions occur.
/// This is an abstract class. You use it by deriving your own component from it 
/// and implementing IsSatisfied().
/// </summary>
public abstract class FsmCondition : MonoBehaviour {

	/// <summary>
	/// Determines whether the condition is satisfied.
	/// You will be given pointers to current and possible next state in order to gather additional information.
	/// </summary>
	/// <returns><c>true</c> if the condition is satisfied; otherwise, <c>false</c>.</returns>
	/// <param name="curr">State in which the FSM currently is.</param>
	/// <param name="next">State into which the FSM will transition if the condition is satisfied.</param>
	public abstract bool IsSatisfied (FsmState curr, FsmState next);
}
