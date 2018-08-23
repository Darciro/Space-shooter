using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
    private float shootTimer = 0f;

    public float speed;
    public float tilt;

    // public float speed = 4f;
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

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0);
        rb.velocity = movement * speed;
        rb.rotation = rb.velocity.x * -tilt;
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