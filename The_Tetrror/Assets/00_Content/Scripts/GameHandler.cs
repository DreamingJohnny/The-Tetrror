using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour {

	//For now, we'll let this have a reference to the BlockDropper then, and we'll let it send things to target there.
	[SerializeField] private BlockDropper blockDropper;
	[SerializeField] private BlockSpawner blockSpawner;
	[SerializeField] private GameObject testTargetObject;
	[SerializeField] private Acid acid;
	[SerializeField] private PlayerController playerController;

	void Start() {
		//blockDropper.SetTarget(testTargetObject);

		//BlockDropper.OnSpawnBlock += blockSpawner.HandleOnBlockSpawn;

		PlayerController.OnCrushed += HandleOnCrushed;

		Acid.OnDrowned += HandleOnDrowned;

		if(acid != null) {
			acid.SetIsMoving(true);
		}

	}

	private void HandleOnDrowned() {
		Debug.Log("Event triggered for player having drowned.");

	}

	private void HandleOnCrushed() {
		Debug.Log("Event triggered for player having been crushed.");
	}

	void Update() {

	}

	private void StartGame() { 
	
	}

	private void GameOver() { 
	//Will need to do quite a lot of cleanup in here, probably, if it needs to recreate things and resubscribe.
	//On the other hand, we might want to separate between the ideas of retrying and starting a game from scratch, yes?
	}
}
