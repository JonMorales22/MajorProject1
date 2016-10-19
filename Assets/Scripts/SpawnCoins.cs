using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour {
	public GameObject prefab;
	private GameObject child;
	// Use this for initialization
	void Awake() {
		Vector3 pos = new Vector3 (0, 1, 0)+gameObject.transform.position;
		child=(GameObject)Instantiate (prefab, pos, Quaternion.identity);
		child.transform.SetParent (gameObject.transform);
	}
}
