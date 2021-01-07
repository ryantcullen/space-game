using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implementation of FsmCondPolled which randomly sets condition value to true or false on every period.
/// </summary>
public class FsmCondRandom : FsmCondPolled {

	[Tooltip("Probability of condition being set to true on evaluation.")]
	[Range(0.0f, 1.0f)]
	public float Probability = 0.5f;

	// Use this for initialization
	void Start() {
		StartEvals ();
	}

	protected override bool EvaluateCondition () {
		return Probability >= 1 || Random.Range (0, 1) < Probability;
	}
}
