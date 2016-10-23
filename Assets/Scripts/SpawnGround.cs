using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
	public GameObject[] prefabChoices = new GameObject[2];
	private GameObject[] prefabArray = new GameObject[20];
	// Use this for initialization
	void Start () {
		float xValue=20;

		for (int i = 0; i < prefabArray.Length; i++) {
			GameObject child;
			int randNum = chooseRandNum ();
			Vector3 pos = new Vector3 (xValue, Random.Range(-1.5f,1.5f), 0f);
			child = (GameObject)Instantiate (prefabChoices[randNum],pos, Quaternion.identity);
			child.transform.parent = gameObject.transform;
			xValue += 20;
		}

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
