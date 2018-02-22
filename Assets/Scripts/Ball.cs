using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBarVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBarVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!hasStarted)
		{
			this.transform.position = paddleToBarVector + paddle.transform.position;

			if(Input.GetMouseButtonDown(0))
			{
				this.rigidbody2D.velocity = new Vector2(2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Vector2 tweak = new Vector2 (Random.Range (0.0f, 0.2f), Random.Range (0.0f, 0.2f));
		if (hasStarted) {
			audio.Play ();

			rigidbody2D.velocity += tweak;
		}

	}
}
