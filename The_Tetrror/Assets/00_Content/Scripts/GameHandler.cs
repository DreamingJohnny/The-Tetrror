using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour {

	//For now, we'll let this have a reference to the BlockDropper then, and we'll let it send things to target there.

	[SerializeField] private BlockDropper blockDropper;
	[SerializeField] private BlockSpawner blockSpawner;
	[SerializeField] private GameObject testTargetObject;

	void Start() {
		//blockDropper.SetTarget(testTargetObject);

		//BlockDropper.OnSpawnBlock += blockSpawner.HandleOnBlockSpawn;

	}


	void Update() {

	}
}
