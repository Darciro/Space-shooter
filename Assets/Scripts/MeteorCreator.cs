using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

	public GameObject meteorObject;
	public float minTimeToCreate;
	public float maxTimeToCreate;

	private float timeToNextCreation;
	private float countTimer;
	private float xMin;
	private float xMax;

	void Start () {
		float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
		xMin = - horizontalExtension * 0.8f;
		xMax = horizontalExtension * 0.8f;

		GenerateNextWave();
	}
	
	void Update () {
		countTimer += Time.deltaTime;
		if( countTimer >= timeToNextCreation ){
			countTimer = 0;
			GenerateNextWave();

			Vector3 pos = transform.position;
			pos.x = Random.Range(xMin, xMax);

			GameObject.Instantiate( meteorObject, pos, Quaternion.Euler( 0, 0, Random.Range(0,359) ) );
		}
	}

	void GenerateNextWave(){
		timeToNextCreation = Random.Range(minTimeToCreate, maxTimeToCreate);
	}
}
