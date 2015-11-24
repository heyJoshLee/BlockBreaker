using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


	Rigidbody2D rb2d;
	private bool hasStarted = false;
	public Paddle paddle;
	
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for a mouse click to launch the ball
			if (Input.GetMouseButton(0)){
				print ("Mouse clicked");
				hasStarted = true;
				rb2d.velocity = new Vector2(2f, 10f);
			}
		}
	}
}
