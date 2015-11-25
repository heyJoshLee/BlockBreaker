using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount += 1;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		timesHit += 1;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount -= 1;
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}	
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO remove this method once we can win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
