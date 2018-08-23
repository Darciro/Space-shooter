using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : MonoBehaviour {

	private LineRenderer lr;
	
	void Start () {
		lr = GetComponent<LineRenderer>();
	}
	
	void Update () {
		lr.SetPosition(0, transform.position);
		/* RaycastHit hit;
		if( Physics.Raycast(transform.position, transform.up, out hit) ){
			if( hit.collider ){
				lr.SetPosition(1, hit.point);
			}
		} else {
			lr.SetPosition(1, transform.up * 500);
		}*/

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null) {
			lr.SetPosition(1, hit.point);
            // float force = liftForce * heightError - rb2D.velocity.y * damping;
            // rb2D.AddForce(Vector3.up * force);
        } else {
			lr.SetPosition(1, transform.up * 500);
		}
	}
}
