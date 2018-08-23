using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour {

	private float lifeTime = 0;
	private ParticleSystem particles;
	
	void Update () {
		lifeTime += Time.deltaTime;
		if( lifeTime > particles.main.duration )	{
			Destroy(this.gameObject);
		}
	}
}
