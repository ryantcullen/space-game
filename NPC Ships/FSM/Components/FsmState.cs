using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component representing an FSM state.
/// This is an abstract class. You use it by deriving your own component
/// from it. You may implement methods OnStateEnter() and OnStateLeave().
/// By default, these methods have an empty body.
/// </summary>
public abstract class FsmState : MonoBehaviour {

	/// <summary>
	/// Called just after the state is entered.
	/// </summary>
	public virtual void OnStateEnter () {
	}

	/// <summary>
	/// Called just before the state is left.
	/// </summary>
	public virtual void OnStateLeave () {
	}
}
