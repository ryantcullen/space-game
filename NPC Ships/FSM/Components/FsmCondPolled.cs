using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Condition which is evaluated periodically.
/// This is useful when the evaluation is too expensive to perform on every LateUpdate().
/// 
/// This is an abstract class. You use it by deriving from it, 
/// then implementing EvaluateCondition(). 
/// 
/// IMPORTANT: Make sure to call StartEvals() somewhere when using this class!
/// Otherwise, the condition will always return false.
/// 
/// You can stop evaluations by calling StopEvals().
/// </summary>
public abstract class FsmCondPolled : FsmCondition {

	[Tooltip("The period in seconds on which to reevaluate the condition.")]
	public float Period = 0.1f;

	private bool cachedCond;

	/// <summary>
	/// Start periodically reevaluating the condition.
	/// Make sure to call this or the condition will always be false!
	/// </summary>
	public void StartEvals() {
		cachedCond = false;
		StartCoroutine ("PollCondition");
	}

	/// <summary>
	/// Stop evaluating the condition for now.
	/// </summary>
	public void StopEvals() {
		StopCoroutine ("PollCondition");
	}

	/// <summary>
	/// Evaluate your condition by overriding this.
	/// Make sure to call StartEvals() somewhere if using this class!
	/// </summary>
	/// <returns><c>true</c>, if condition was evaluated as true, <c>false</c> otherwise.</returns>
	protected abstract bool EvaluateCondition ();

	private IEnumerator PollCondition() {
		while (true) {
			yield return new WaitForSeconds (Period);
			cachedCond = EvaluateCondition ();
		}
	}

	public override bool IsSatisfied (FsmState curr, FsmState next) {
		return cachedCond;
	}
}
