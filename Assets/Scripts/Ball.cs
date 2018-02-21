using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Paddle paddle;
	public bool hasStarted = false;
	
	public Vector3 paddleToBarVector;
	// Use this for initialization
	void Start () {
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
}
