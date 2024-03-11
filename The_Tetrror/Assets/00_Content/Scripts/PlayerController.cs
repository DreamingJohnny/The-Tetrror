using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	
	#region Events
	public static event Action OnCrushed;
	#endregion

	#region Ground- and Crushchecking
	private GroundChecker groundChecker;
	private CrushChecker crushChecker;
	public bool IsGrounded {
		get {
			return groundChecker.IsGrounded;
		}
	}
	public bool IsCrushed {
		get {
			if (crushChecker.IsCrushed && IsGrounded) return true;
			else return false;
		}
	}
	#endregion

	#region Movement
	private Vector2 movement;
	private Rigidbody2D rigidBody;
	[SerializeField] private float speed;

	private bool isJumping;
	private Vector2 jumpDirection;
	[SerializeField] private float jumpForce;
	#endregion

	void Start() {
		groundChecker = GetComponentInChildren<GroundChecker>();
		Debug.Assert(groundChecker != null);

		crushChecker = GetComponentInChildren<CrushChecker>();
		Debug.Assert(crushChecker != null);

		rigidBody = GetComponent<Rigidbody2D>();
		Debug.Assert(rigidBody != null);

		movement = Vector2.zero;
		jumpDirection = Vector2.up;
	}

	/// <summary>
	/// Sets the bool "isJumping" to true when called.
	/// </summary>
	/// <param name="value"></param>
	private void OnJump(InputValue value) {
		if (value.isPressed) {
			isJumping = true;
			Debug.Log("Is the jump being registered (now with value)?");
		}
	}

	/// <summary>
	/// Sets the movement vector to the given input value.
	/// </summary>
	/// <param name="value"></param>
	private void OnMove(InputValue value) {

		movement = value.Get<Vector2>();
	}

	private void Update() {
		if (IsCrushed) {
			OnCrushed?.Invoke();
		}
	}

	private void FixedUpdate() {
		rigidBody.velocity += (speed * Time.deltaTime * movement);

		if (IsGrounded && isJumping) {
			isJumping = false;
			//Wonder if this should be a force like impulse instead?
			rigidBody.velocity += (jumpForce * Time.deltaTime * jumpDirection);
		}
	}
}
