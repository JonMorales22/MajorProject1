using UnityEngine;
using System.Collections;

public class SpawnSnowball : MonoBehaviour {
	public GameObject prefab;
	public GameObject snowball;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

	}

	void Spawn()
	{
		GameObject child = (GameObject)Instantiate(prefab,transform.position,Quaternion.identity);
		child.transform.SetParent (transform);
	}
}
