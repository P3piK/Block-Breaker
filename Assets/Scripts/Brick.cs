using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableCount = 0;
	private int timesHit;	
	public Sprite[] hitSprites;
	public GameObject smoke;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if(this.tag == "Breakable")
			breakableCount++;
	}
	
	void OnCollisionEnter2D(Collision2D	collision)
	{
		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position);
			HandleHits ();
		}
	}

	void HandleHits()
	{
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit >= maxHits)
		{
			breakableCount--;
			Destroy (gameObject);
			PuffSmoke();
			levelManager.BrickDestroyed();
		}
		else
		{
			LoadSprites();
		}
	}

	void PuffSmoke()
	{
		GameObject smokePuff = (GameObject)Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		else
			Debug.LogError("Brick sprite missing");
	}
}
