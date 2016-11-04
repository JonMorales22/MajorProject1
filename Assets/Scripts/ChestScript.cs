using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {

	public AudioClip sound;
	public GameObject[] prefab;
	public float force;


	private bool isOpen;
	private GameObject child;
	private Animator anim;
	private AudioSource AudioSource;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void PlaySound()
	{
		AudioSource.PlayClipAtPoint (sound,transform.position);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag ("Player")&&!isOpen)
		{
			isOpen = true;
			anim.SetTrigger ("Open");
			int randNum = chooseRandNum ();
			if (randNum == 1)
				SpawnCoin ();
			else
				Spawn1Up ();
		}
	}

	void SpawnCoin()
	{
		Vector3 pos = new Vector3 (1, 1, 0)+gameObject.transform.position;
		child=(GameObject)Instantiate (prefab[0], pos, Quaternion.identity);
		child.transform.SetParent (gameObject.transform);
	}

	void Spawn1Up()
	{
		Vector3 pos = new Vector3 (0, 0, 0)+gameObject.transform.position;
		child=(GameObject)Instantiate (prefab[1], pos, Quaternion.identity);
		child.transform.SetParent (gameObject.transform);
		Rigidbody2D rb = child.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (1*force, 1*force);
	}

	int chooseRandNum()
	{
		float randNum = Random.Range (0.0f, 50.0f);
		if (randNum > 20)
			return 1;
		else
			return 0;	
	}
}
