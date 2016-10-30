using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {
	private PlayerStats stats;
	private Image[] HeartArray;
	private int index;

	// Use this for initialization
	void Start () {
		HeartArray = GetComponentsInChildren<Image>();
		index = HeartArray.Length-1;
	}
	
	public void DecreaseHealth(int value)
	{
		HeartArray [index].color = new Color (0, 0, 0, 1);
		index--;
	}
}
