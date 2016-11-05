using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {
	private PlayerStats stats;
	private int health;
	private Image[] HeartArray;

	// Use this for initialization
	void Start() {
		stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		if (PlayerPrefs.HasKey ("247127CurrentPlayerHealth"))
			health = PlayerPrefs.GetInt ("247127CurrentPlayerHealth");
		else
			health = 3;
		
		HeartArray = GetComponentsInChildren<Image>();
		for (int i = 0; i < health; i++)
			HeartArray [i].color = new Color (1, 1, 1, 1);	
	}

	public void DecreaseHealth(int value)
	{
		int currHealth = stats.health;
		int newHealth = currHealth - value;
		for(int i = currHealth;i>newHealth;i--)
			HeartArray [i-1].color = new Color (0, 0, 0, 1);	
	}

	public void IncreaseHealth(int value)
	{
		int currHealth = stats.health;
		int newHealth = currHealth + value;
		for(int i = currHealth;i<newHealth;i++)
			HeartArray [i].color = new Color (1, 1, 1, 1);	
	}
}
