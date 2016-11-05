using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {
	public int value;
	public AudioClip sound;
	public void PlaySound()
	{
		AudioSource.PlayClipAtPoint (sound,transform.position);
	}
}
