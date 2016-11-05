using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public bool isFacingRight = true;
	[HideInInspector]
	public bool isJumping = false;
	[HideInInspector]
	public bool isGrounded = false;

	public float walkSpeed=7.0f;
	public float maxSpeed=14.0f;
	public float jumpForce = 750.0f; 
	public int health;
	public int score = 0;

	public  Image[] heartArray = new Image[3];

	public Transform groundCheck;
	public LayerMask groundLayers;

	public Animator anim;
	public AudioClip[] audioArray = new AudioClip[4];
	public AudioClip footstep;
	public AudioClip deathsound;
	public AudioClip damage;

	private float groundCheckRadius = .1f;
	private AudioSource audiosource;
	private bool isDead = false;
	private bool isFalling = false;
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
		
			audiosource.clip = audioArray[0];
			audiosource.Play ();
	
	}
	public void playDamageSound()
	{
		audiosource.clip = audioArray[1];
		audiosource.Play ();
	}
	void playDeathSound()
	{
		AudioSource.PlayClipAtPoint (audioArray[2],this.transform.position);
	}
	void playJumpSound()
	{
			audiosource.clip = audioArray [3];
			audiosource.Play ();	
	
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!isJumping&isGrounded&&!isDead) {
				isJumping = true;
				ApplyJump ();
			}
		}
	
	}
	void ApplyJump()
	{
		if (isJumping) {
			player.velocity = new Vector2 (player.velocity.x, jumpForce);
			anim.SetTrigger ("Jump"); 
		}
		isJumping = false;

	}
	void FixedUpdate () {
		if (!isDead) {
			if (player.velocity.y < 0)
				anim.SetBool ("isFalling", true);
			else
				anim.SetBool("isFalling",false);
			
			isGrounded = Physics2D.OverlapCircle (groundCheck.position + new Vector3 (0, -0.5f, 0), groundCheckRadius, groundLayers);
			anim.SetBool ("isGrounded", isGrounded);

			float move = Input.GetAxis ("Horizontal");
			player.velocity = new Vector2 (move * walkSpeed, player.velocity.y);
			
			if ((move > 0.0f && !isFacingRight) || (move < 0.0 && isFacingRight)) {
				Flip ();
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene (2);
			}

			float vel = player.velocity.x;
			walkAnimation (Mathf.Abs (vel));
		} 
			//player.velocity =new Vector2 (0,0);
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x*-1;
		transform.localScale = playerScale;

	}
		

	void walkAnimation(float vel){
		anim.SetFloat ("Velocity", vel);

	}


	void SetAnimationController(int num)
	{
		anim.SetInteger ("AnimationState", num);
	}
}
