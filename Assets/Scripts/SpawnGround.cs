using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
	public GameObject prefab;
	private GameObject[] prefabArray = new GameObject[20];
	// Use this for initialization
	void Start () {
		float xValue=20;
		for (int i = 0; i < prefabArray.Length; i++) {
			Vector3 pos = new Vector3 (xValue, Random.Range(-1.5f,4.0f), 0f);
			Instantiate (prefab,pos, Quaternion.identity);
			xValue += 20;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
