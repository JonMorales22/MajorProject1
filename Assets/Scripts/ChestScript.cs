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
			Spawn (randNum);
		}
	}
	void Spawn(int index)
	{
		Vector3 pos = new Vector3 (0, 1, 0)+gameObject.transform.position;
		child=(GameObject)Instantiate (prefab[index], pos, Quaternion.identity);
		child.transform.SetParent (gameObject.transform);
		Rigidbody2D rb = child.GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(0, force));
	}

	int chooseRandNum()
	{
		//Note: 0=coin,1=1up,2=heart
		float randNum = Random.Range (0, 100);
		if (randNum <= 50)
			return 0;
		else if (randNum > 50 && randNum < 75)
			return 1;
		else
			return 2;

	}
}
