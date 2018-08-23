using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeahaviour : MonoBehaviour {

	private Rigidbody2D rb;
	private float shootTimer = 0f;

	public float speed = 4f;
	public GameObject laserObject;
	public float minTimeToShoot = 0.25f;
	public GameObject explosionObject;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if( shootTimer < minTimeToShoot ){
			shootTimer += Time.deltaTime;
		}

		if( Input.GetMouseButtonDown(0) ){
			ShootLaser();
		}
	}
	
	void FixedUpdate () {
		Vector2 dir = Vector2.zero;

		if( Input.GetKey (KeyCode.W) ){
			dir.y = 1;
		}else if( Input.GetKey (KeyCode.S) ){
			dir.y = -1;
		}

		if( Input.GetKey (KeyCode.A) ){
			dir.x = -1;
		}else if( Input.GetKey (KeyCode.D) ){
			dir.x = 1;
		}

		rb.velocity = dir * speed;
	}

	void ShootLaser() {
		if( minTimeToShoot > shootTimer )
			return;

		shootTimer = 0;
		if( laserObject != null ){
			Vector3 laserPos = this.transform.position;
			GameObject.Instantiate(laserObject, laserPos, Quaternion.identity);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if( other.gameObject.CompareTag ("Meteor") ){
			GameObject.Instantiate(explosionObject, this.transform.position, Quaternion.identity);
			GameObject.Destroy(this.gameObject);
			GameObject.Find("Main Camera").GetComponent<GameController>().ShowRestartGameButton();
		}
	}
}
