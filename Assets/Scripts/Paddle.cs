using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float mousePosInBlocks;
	public bool autoPlay = false;
	
	private Ball ball;
	

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16 - 7);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -8f, 7f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, -8f, 7f);
		this.transform.position = paddlePos;
	}
}
