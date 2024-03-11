using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

	//Needs an event that it can send on to GH if it has catched the player.
	#region Events
	public static event Action OnDrowned;
	#endregion

	#region Movement
	private Rigidbody2D rigidBody;
	private Vector3 direction = Vector3.up;
	[SerializeField] private float speed;
	private bool isMoving = false;
	#endregion

	public void SetIsMoving(bool isMoving) {
		this.isMoving = isMoving;
	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		Debug.Assert(rigidBody != null);		
	}


	void Update() {
		if (isMoving) {
			rigidBody.MovePosition(transform.position + speed * Time.deltaTime * direction);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		OnDrowned?.Invoke();
	}
}
