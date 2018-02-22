using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private Ball ball;
	public bool autoPlay = false;

	void Start()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay)
			MoveWithMouse ();
		else
			MoveAutomatically ();
	}

	void MoveWithMouse()
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	void MoveAutomatically()
	{
		Vector3 paddlePos = new Vector3 (ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
