using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer renderer;
	public float speed = 1f;
	public int hitPoints = 3;
	public GameObject explosionObject;
	
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {	
		rb.velocity = Vector2.down * speed;	
	}

	public void Hit() {
		hitPoints -= 1;

		switch( hitPoints ){
			case 2:
				renderer.color = Color.yellow;
				break;
			case 1:
				renderer.color = Color.red;
				break;
			default:
				renderer.color = new Color(122, 66, 6);
				break;
		}

		if( hitPoints <= 0 ){
			GameObject.Instantiate(explosionObject, transform.position, Quaternion.identity);
			GameObject.Destroy(this.gameObject);
			GameObject.Find("Main Camera").GetComponent<GameController>().AddPointToScore();
		}
	}
}
