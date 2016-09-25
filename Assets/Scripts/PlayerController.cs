using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public SpriteRenderer c;
	public float walkSpeed = 1.0f;
	public float runSpeed=3.0f;
	public Animator anim;
	public AudioClip footstep;
	public AudioClip deathsound;

	private AudioSource audiosource;
	private bool isWalking = false;
	private bool isDead = false;
	private int direction=(int)facing.RIGHT;
	private enum facing {RIGHT,LEFT};
	private float speed;
	private Vector3 movement = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Awake(){
		audiosource = this.GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		SetAnimationController (0);
		speed = walkSpeed;
		//

	}

	public void playFootStep()
	{
		audiosource.clip = footstep;
		audiosource.Play ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!isDead) {
			if (Input.GetKeyUp ("right")) {
				if (isWalking && direction == (int)facing.RIGHT) {
					speed = runSpeed;
					anim.SetInteger ("AnimationState", 2);
				} else if (!isWalking) {
					speed = walkSpeed;
					isWalking = true;
					anim.SetInteger ("AnimationState", 1);
				}

				c.flipX = false;
				direction = (int)facing.RIGHT;
				movement = new Vector3 (1, 0, 0);

			}
			if (Input.GetKeyUp ("left")) {
				if (isWalking && direction == (int)facing.LEFT) {
					speed = runSpeed;
					anim.SetInteger ("AnimationState", 2);
				} else if (!isWalking) {
					speed = walkSpeed;
					isWalking = true;
					anim.SetInteger ("AnimationState", 1);
				}
				c.flipX = true;
				direction = (int)facing.LEFT;
				movement = new Vector3 (-1, 0, 0);
			}

			if (Input.GetKeyUp ("space")) {
				if (speed == runSpeed) {
					speed = walkSpeed;
					//isWalking = true;
					anim.SetInteger ("AnimationState", 1);
				} else if (speed == walkSpeed) {
					Debug.Log("Ass");
					movement = new Vector3 (0, 0, 0);
					isWalking = false;
					anim.SetInteger ("AnimationState", 0);
				}
			}
			if (Input.GetKeyUp (KeyCode.Backspace)) {
				movement = new Vector3 (0, 0, 0);
				isWalking = false;
				anim.SetBool ("isDead", true);
				isDead = true;
				playDeathSound ();
			}
			//Debug.Log (speed);
			transform.position += movement * Time.deltaTime * speed;
		}
	}

	void playDeathSound()
	{
		AudioSource.PlayClipAtPoint (this.deathsound,this.transform.position);
	}
	void OnCollisionEnter2D(){
		//Debug.Log ("poop");
	}

	void SetAnimationController(int num)
	{
		anim.SetInteger ("AnimationState", num);
	}
}
