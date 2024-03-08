using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded { get { return isGrounded; } }

    private bool isGrounded;

	private void OnTriggerEnter2D(Collider2D collision) {
		isGrounded = true;
		Debug.Log("Collision triggered!");
	}

	private void OnTriggerExit2D(Collider2D collision) {
		isGrounded = false;
		Debug.Log("Collision stopped!");
	}
}
