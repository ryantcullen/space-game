using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component representing the Finite State Machine itself. This is the main component of the package.
/// 
/// Add it to a game object, along with a group of states and conditions.
/// Enlist all of these states and connect them to desired transition rules.
/// You can also define the global state for transitions which are possible at any state.
/// 
/// The first state listed will be the initial state of the FSM.
/// 
/// State and condition components may belong to other game objects.
/// </summary>
public class FsmCore : MonoBehaviour {

	/// <summary>
	/// Inner class representing a transition that can be performed.
	/// It has a state into which to transition
	/// and a condition on which the transition happens.
	/// </summary>
	[System.Serializable]
	public class TransitionRule {
		[Tooltip("State to go to.")]
		public FsmState Next;

		[Tooltip("Condition on which the transition will happen.")]
		public FsmCondition Cond;

		[Tooltip("When multiple conditions are satisfied, transition with the largest priority will take place.")]
		public int Priority;

		[Tooltip("If the transition should happen when the condition is not satisfied.")]
		public bool Not;

		[System.NonSerialized]
		public StateEntity StateEntityOfNext;
	}

	/// <summary>
	/// Inner class representing a state with all transition rules associated with it.
	/// The conditions of these rules will be evaluated at every LateUpdate().
	/// 
	/// Transition with a satisfied condition and the largest priority will take place.
	/// If no condition is satisfied, the FSM stays in the same state.
	/// </summary>
	[System.Serializable]
	public class StateEntity {
		[Tooltip("State component itself.")]
		public FsmState State;

		[Tooltip("List of transition rules leading away from this state.")]
		public TransitionRule[] Transitions;
	}

	/// <summary>
	/// The global state is a set of transition rules
	/// which are considered in addition to transition rules of any state the FSM is currently in.
	/// </summary>
	[Tooltip("Transition rules which are checked regardless of the current state.")]
	public TransitionRule[] GlobalState;

	[Tooltip("List of all states and transition rules found within this FSM.\nFirst state is the initial state.\nNeither states nor conditions have to belong to this game object.")]
	public StateEntity[] States;

	private StateEntity current;

	/// <summary>
	/// Get the current state along with its transition rules.
	/// </summary>
	/// <returns>The current state and its transition rules.</returns>
	public StateEntity GetCurrentState() {
		return current;
	}

	/// <summary>
	/// Changes the FSM state programmatically.
	/// </summary>
	/// <param name="Next">State to change into.</param>
	public void ChangeState(FsmState Next) {
		leaveCurrentState ();

		current = null;

		foreach (StateEntity se in States) {
			if (Next == se.State) {
				current = se;
				break;
			}
		}

		if (current == null) {
			// We have reached a state not listed in FsmCore.
			current = new StateEntity ();
			current.State = Next;
			current.Transitions = null;
		}

		enterCurrentState ();
	}

	// Use this for initialization
	void Start () {
		if (States.Length > 0) {
			current = States [0];

			for (int i = 1; i < States.Length; ++i)
				if (States [i].State != null)
					States [i].State.enabled = false;

			enterCurrentState ();
		}
	}

	void LateUpdate () {
		TransitionRule chosenTransition = null;

		for (int i = 0; i < GlobalState.Length; ++i) {
			TransitionRule tr = GlobalState [i];

			if (tr != null &&
				(chosenTransition == null || tr.Priority > chosenTransition.Priority) &&
				(tr.Cond != null && (tr.Not ^ tr.Cond.IsSatisfied (current != null ? current.State : null, tr.Next))))
				chosenTransition = tr;
		}

		if (current != null && current.Transitions != null) {
			for (int i = 0; i < current.Transitions.Length; ++i) {
				TransitionRule tr = current.Transitions [i];

				if (tr != null &&
					(chosenTransition == null || tr.Priority > chosenTransition.Priority) &&
					(tr.Cond != null && (tr.Not ^ tr.Cond.IsSatisfied (current != null ? current.State : null, tr.Next))))
					chosenTransition = tr;
			}
		}

		if (chosenTransition != null) {
			leaveCurrentState ();

			// lazy getting
			current = chosenTransition.StateEntityOfNext;
			if (current == null) {
				foreach (StateEntity se in States) {
					if (se != null && chosenTransition.Next == se.State) {
						chosenTransition.StateEntityOfNext = se;
						current = se;
						break;
					}
				}

				if (current == null) {
					// We have reached a state not enlisted in FsmCore.
					current = new StateEntity ();
					current.State = chosenTransition.Next;
					current.Transitions = null;
				}
			}

			enterCurrentState ();
		}
	}

	private void leaveCurrentState() {
		if (current != null && current.State != null) {
			current.State.OnStateLeave ();
			current.State.enabled = false;
		}
	}

	private void enterCurrentState() {
		if (current != null && current.State != null) {
			current.State.enabled = true;
			current.State.OnStateEnter ();
		}
	}
}
