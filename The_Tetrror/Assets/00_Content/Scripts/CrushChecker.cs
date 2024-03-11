using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushChecker : MonoBehaviour
{
	public bool IsCrushed { get { return isCrushed; } }

	private bool isCrushed;

	private void OnTriggerEnter2D(Collider2D collision) {
		isCrushed = true;
		Debug.Log("Collision triggered!");
	}

	private void OnTriggerExit2D(Collider2D collision) {
		isCrushed = false;
		Debug.Log("Collision stopped!");
	}
}
