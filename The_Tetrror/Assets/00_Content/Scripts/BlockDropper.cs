using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BlockDropper : MonoBehaviour {

	public static event Action<Vector2> OnSpawnBlock;

	[SerializeField] private float maxSpawnSpan;
	private float spanSinceSpawn;
	[SerializeField] private float reloadSpan;

	[SerializeField] private float targetMargin;

	Rigidbody2D rigidBody;
	[SerializeField] private Vector2 targetOffset;
	private Vector2 destination;
	private GameObject target;

	[SerializeField] private float speed;

	void Start() {
		destination = transform.position;

		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {

		spanSinceSpawn += Time.deltaTime;

		if (reloadSpan >= spanSinceSpawn) {
			return;
		}
		else if (AboveTarget()) {
			Spawn();
		}
		else if (spanSinceSpawn >= maxSpawnSpan) {
			Spawn();
		}
	}

	private void FixedUpdate() {
		if (reloadSpan >= spanSinceSpawn) {
			return;
		}
		else {
			rigidBody.MovePosition(Vector2.MoveTowards(transform.position, GetDestination(), speed * Time.deltaTime));
		}
	}

	public void SetTarget(GameObject target) {
		this.target = target;
	}

	private Vector2 GetDestination() {

		if (target == null) {
			Debug.Log($"{name} found that target was null and so won't be able to move towards it.");
			return destination;
		}
		else if (target.TryGetComponent(out PlayerController playerController)) {
			if (!playerController.IsGrounded) {
				return destination;
			}
			else {
				return (Vector2)playerController.transform.position + targetOffset;
			}
		}

		return (Vector2)target.transform.position + targetOffset;
	}

	private void Spawn() {
		//Sends on the event that it should spawn a block, then resets spawnSpan.
		Debug.Log($"{name} should send on an event about spawning a block now.");
		OnSpawnBlock?.Invoke(transform.position);
		spanSinceSpawn = 0;
	}

	private bool AboveTarget() {
		if (target == null) {
			Debug.Log("Couldn't find a target!");
			return false;
		}
		else if (target.TryGetComponent(out PlayerController _)) {
			float difference = transform.position.x - target.transform.position.x;
			difference = Math.Abs(difference);
			

			if (difference <= targetMargin) {
				return true;
			}
		}

		return false;

	}
}