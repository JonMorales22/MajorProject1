using UnityEngine;
using System.Collections;

public class ApplyDamage : MonoBehaviour {
	public int damage=1;
	public bool playHitReaction = true;
	// Use this for initialization


	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			PlayerStats stats = c.gameObject.GetComponent<PlayerStats>();
			stats.TakeDamage(damage,playHitReaction);
		}

	}
}
