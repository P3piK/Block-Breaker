using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableCount = 0;
	private int timesHit;	
	public Sprite[] hitSprites;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if(this.tag == "Breakable")
			breakableCount++;
	}
	
	// Update is called once per frame
	void Update () {

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
			levelManager.BrickDestroyed();
		}
		else
		{
			LoadSprites();
		}
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
