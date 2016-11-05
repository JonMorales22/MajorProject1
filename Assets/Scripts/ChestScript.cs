using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {

	public AudioClip sound;
	public GameObject[] prefab;

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
			Spawn (randNum);
		}
	}
	void Spawn(int index)
	{
		Vector3 pos = new Vector3 (1, 0, 0)+gameObject.transform.position;
		child=(GameObject)Instantiate (prefab[index], pos, Quaternion.identity);
		child.transform.SetParent (gameObject.transform);
	}

	int chooseRandNum()
	{
		
		float randNum = Random.Range (0, 100);
		if (randNum <= 50)
			return 0;
		else if (randNum > 50 && randNum < 75)
			return 1;
		else
			return 2;
	}
}
