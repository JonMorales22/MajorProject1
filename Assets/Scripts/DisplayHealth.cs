using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {
	private PlayerStats stats;
	private Image[] HeartArray;
	private int index;

	// Use this for initialization
	void Start () {
		stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		HeartArray = GetComponentsInChildren<Image>();
		index = HeartArray.Length-1;	
	}
	
	public void DecreaseHealth(int value)
	{
		int currHealth = stats.health;
		int newHealth = stats.health - value;
		for(int i = currHealth;i>newHealth;i--)
			HeartArray [i-1].color = new Color (0, 0, 0, 1);	
	}
}
