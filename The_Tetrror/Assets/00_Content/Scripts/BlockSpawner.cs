using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	[SerializeField] private GameObject[] blocks;

	private GameObject waitingBlock;

	[SerializeField] private PredictionScreen predictionScreen;

	void Start() {
		SetWaitingBlock();
	}

	public void HandleOnBlockSpawn(Vector2 position) {
		SpawnBlock(position);
	}

	private void SpawnBlock(Vector2 position) {

		if(waitingBlock == null) return;
		Instantiate(waitingBlock, position,	predictionScreen.Rotation);
		waitingBlock = null;
		SetWaitingBlock();
	}

	private void SetWaitingBlock() {

		waitingBlock = blocks[Random.Range(0, blocks.Length)];
		
		predictionScreen.SetOnScreen(waitingBlock.GetComponent<SpriteRenderer>().sprite, GetRandomRotation());
	}

	/// <summary>
	/// Returns a rotation on the z-axis of 0, 90,180 or 270 degrees.
	/// </summary>
	/// <returns></returns>
	private Quaternion GetRandomRotation() {
		int result = Random.Range(0, 4);

		switch (result) {
			case 0:
				return Quaternion.Euler(0, 0, 0);
			case 1:
				return Quaternion.Euler(0, 0, 90);
			case 2:
				return Quaternion.Euler(0, 0, 180);
			case 3:
				return Quaternion.Euler(0, 0, 270);
			default:
				Debug.Log($"{name} was returning a random rotation," +
					$"but seems to have generated a value outside the expected bounds." +
					$"It will return zero rotation for now.");
				return Quaternion.Euler(0, 0, 0);
		}
	}
}