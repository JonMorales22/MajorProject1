using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public Transform[] background;
	private float[] parallaxScales;
	public int smoothing;

	private Vector3 previousCamPos;

	// Use this for initialization
	void Start () {
		previousCamPos = transform.position;

		parallaxScales = new float [background.Length];
		for (int i = 0; i < parallaxScales.Length; i++) {
			parallaxScales [i] = background [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		for (int i = 0; i < parallaxScales.Length; i++) {
			Vector3 parallax = (previousCamPos - transform.position) * (parallaxScales [i] / smoothing);
			background [i].position = new Vector3 (background[i].position.x+parallax.x,background[i].position.y+parallax.y,background[i].position.z+parallax.z);
		}
		previousCamPos = transform.position;
	}
}
