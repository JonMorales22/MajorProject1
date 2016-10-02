using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public bool isFacingRight = true;
	[HideInInspector]
	public bool isJumping = false;
	[HideInInspector]
	public bool isGrounded = false;

	public float maxSpeed=7.0f;
	public float jumpForce = 750.0f; 


	public Transform groundCheck;
	public LayerMask groundLayers;

	public Animator anim;
	public AudioClip footstep;
	public AudioClip deathsound;


	private float groundCheckRadius = .2f;
	private AudioSource audiosource;
	private bool isDead = false;
	private Rigidbody2D player;
	// Use this for initialization
	void Awake(){
		audiosource = this.GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		SetAnimationController (0);
		player = GetComponent<Rigidbody2D> ();

	}

	public void playFootStep()
	{
		audiosource.clip = footstep;
		audiosource.Play ();
	}
	void Update(){
		if (Input.GetKey("up")) {
			Debug.Log (groundCheck.position + new Vector3 (0, -2, 0));
			if (isGrounded) {
				Debug.Log ("Jump");
				player.velocity = new Vector2 (player.velocity.x, 0);
				player.AddForce (new Vector2 (0, jumpForce));
			}
		}
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDead) {
			
			isGrounded=Physics2D.OverlapCircle(groundCheck.position+new Vector3(0,-2,0),groundCheckRadius,groundLayers);


			float move = Input.GetAxis ("Horizontal");
			player.velocity = new Vector2 (move * maxSpeed, player.velocity.y);

			if((move>0.0f&&!isFacingRight) || (move<0.0&& isFacingRight)) {
				Flip();
			}

			if (Input.GetKeyUp (KeyCode.Backspace)) {
				anim.SetBool ("isDead", true);
				isDead = true;
				playDeathSound ();
			}
		}
	}
	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x*-1;
		transform.localScale = playerScale;

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
