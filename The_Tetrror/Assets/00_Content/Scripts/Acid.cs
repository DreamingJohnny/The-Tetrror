using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

	//So, needs colliders so that it can detect when the player enters,
	//Needs layers I think so that it only interacts with the player
	//Needs an event that it can send on to GH if it has catched the player.
	//Collider needs to be slightly smaller than field
	//Check if collider interacts with grounded collider? Should do right?
	//Needs to have a speed and move upward in a slow unchanging manner
	//Probably needs to be told to start as well?

	private Rigidbody2D rigidBody;
	private Vector3 direction = Vector3.up;
	[SerializeField] private float speed;
	private bool isMoving = false;

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
		Debug.Log($"{this.name} has triggered a collision with {collision.name}");
	}
}
