using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private GroundChecker groundChecker;
	private CrushChecker crushChecker;

	public bool IsGrounded { get { return groundChecker.IsGrounded; } }

	void Start() {
		groundChecker = GetComponentInChildren<GroundChecker>();
		Debug.Assert(groundChecker != null);

		crushChecker = GetComponentInChildren<CrushChecker>();
		Debug.Assert(crushChecker != null);
	}

	void Update() {

	}
}
