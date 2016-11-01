using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	public int health;
	public int score = 0;
	public int lives;
	public bool isDead;

	private DisplayHealth healthScript;
	private DisplayLives livesScript;

	void Start()
	{
		healthScript = GameObject.FindWithTag ("HealthUI").GetComponent<DisplayHealth>();
		livesScript = GameObject.FindWithTag ("LivesUI").GetComponentInChildren<DisplayLives> ();

		if (PlayerPrefs.HasKey ("247127CurrentPlayerHealth")) {
			health = PlayerPrefs.GetInt ("247127CurrentPlayerHealth");
			//TakeDamage (health - PlayerPrefs.GetInt ("247127CurrentPlayerHealth"), false);
		}
		else
		{
			health = 3;
			PlayerPrefs.SetInt ("247127CurrentPlayerHealth",health);
		}

		if (PlayerPrefs.HasKey ("247127CurrentPlayerLives")) {
			lives = PlayerPrefs.GetInt ("247127CurrentPlayerLives");
			//if (lives <= 0)
				//SceneManager.LoadScene (2);
		}
		else
		{
			lives = 2;
			PlayerPrefs.SetInt ("247127CurrentPlayerLives", lives);
		}

		if (lives <= 0)
			SceneManager.LoadScene (2);
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
		if (c.gameObject.CompareTag ("1up")) 
		{
			if (!isDead)
			{
				lives++;

				PlayerPrefs.SetInt ("247127CurrentPlayerLives", lives);
				livesScript.playSound (transform.position);
				livesScript.UpdateLives (1);
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
		//StartCoroutine("DeathWait");
		PlayerController controller = gameObject.GetComponent<PlayerController> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		gameObject.GetComponent<Animator>().SetBool ("isDead",true);
		controller.enabled = false;

		rb.velocity = new Vector2 (0, 0);

		if (controller.isFacingRight)
			rb.AddForce (new Vector2 (-400, 400));
		else
			rb.AddForce (new Vector2 (400, 400));

		Debug.Log ("Lives: " + lives);
		lives--;
		Debug.Log ("Lives: " + lives);
		PlayerPrefs.SetInt ("247127CurrentPlayerLives", lives);
		PlayerPrefs.DeleteKey ("247127CurrentPlayerHealth");
		gameObject.GetComponent<PlayerStats> ().enabled = false;

	}

	IEnumerator DeathWait()
	{
		yield return new WaitForSeconds (.5f);
		PlayerPrefs.SetInt ("247127CurrentPlayerScore", score);
		if (lives > 0)
			SceneManager.LoadScene (1);
		else
			SceneManager.LoadScene (2);
	}
}
