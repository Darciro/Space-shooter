using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed = 10f;
	public GameObject explosionObject;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		rb.velocity = Vector2.up * speed;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Main Camera"){
			GameObject.Destroy(this.gameObject);
		}

		if( other.CompareTag ("Meteor") ){
			other.transform.GetComponent<Meteor>().Hit();
			GameObject.Destroy(this.gameObject);
			GameObject.Instantiate(explosionObject, this.transform.position, Quaternion.identity);
		}
	}
}
