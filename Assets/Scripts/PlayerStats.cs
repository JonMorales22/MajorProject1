using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	public int health = 3;
	public int score = 0;
	public int lives;
	public bool isDead;

	private DisplayHealth healthScript;


	void Start()
	{
		healthScript = GameObject.FindWithTag ("HealthUI").GetComponent<DisplayHealth>();
		if (PlayerPrefs.HasKey ("247127CurrentPlayerHealth"))
		{
			Debug.Log (PlayerPrefs.GetInt ("247127CurrentPlayerHealth"));
			TakeDamage (health - PlayerPrefs.GetInt ("247127CurrentPlayerHealth"), false);
		}
		/*
		if (PlayerPrefs.HasKey ("247127CurrentPlayerLives"))
			lives = PlayerPrefs.GetInt ("247127CurrentPlayerLives");
		else
			lives = 3;
		*/	


	}
	void changeScore(int value)
	{
		if (!isDead)
		{
			if (value > 0)
				score += value;
			else if (value < 0 && score - value > 0)
				score += value;
			else if (value < 0 && score - value < 0)
				score = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag ("Coin"))
		{
			if (!isDead)
			{
				CoinScript CoinScript = c.GetComponent<CoinScript> ();
				int value = CoinScript.value;
				CoinScript.PlaySound ();
				changeScore (value);
				Destroy (c.gameObject);
			}
		}
	}
	public void TakeDamage(int damage,bool playHitAnim){
		if (!isDead)
		{
			healthScript.DecreaseHealth (damage);
			health = health - damage;
			PlayerPrefs.SetInt ("247127CurrentPlayerHealth", health);
		}

		if (health <= 0)
		{
			PlayerDie ();
		}
		else if (playHitAnim) 
		{
			PlayHitReaction ();

		}
	}

	void PlayHitReaction()
	{
		//other thigs soon enough
		gameObject.GetComponent<Animator>().SetTrigger ("Damage");
	}

	void PlayerDie()
	{
		isDead = true;
		StartCoroutine("DeathWait");
		PlayerController controller = gameObject.GetComponent<PlayerController> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		gameObject.GetComponent<Animator>().SetBool ("isDead",true);
		controller.enabled = false;

		rb.velocity = new Vector2 (0, 0);

		if (controller.isFacingRight)
			rb.AddForce (new Vector2 (-400, 400));
		else
			rb.AddForce (new Vector2 (400, 400));
		
		gameObject.GetComponent<PlayerStats> ().enabled = false;
	}

	IEnumerator DeathWait()
	{
		yield return new WaitForSeconds (5.0f);
		PlayerPrefs.SetInt ("247127CurrentPlayerScore", score);
		SceneManager.LoadScene (2);
	}
}
