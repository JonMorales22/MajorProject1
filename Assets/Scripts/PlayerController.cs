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
	public float slipFactor;
	public float asdfasdf = 3;


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
	private bool onIce = false;
	private bool flag = false;
	private bool isButtonDown = false;

	private BoxCollider2D collider;
	private Vector3 pos;
	private Rigidbody2D player;
	// Use this for initialization
	void Awake(){
		collider=GetComponent<BoxCollider2D>();
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
			Debug.Log ("Velocity: " + player.velocity.x);
			Vector2 temp = player.GetPointVelocity(transform.position);
			//Debug.Log ("temp Vec:"+temp.x);
			player.velocity=new Vector2(player.velocity.x,jumpForce);
			//player.A
			//player.AddForce(new Vector2(player.velocity.x,jumpForce),ForceMode2D.Force);
			anim.SetTrigger ("Jump"); 
		}
		isJumping = false;

	}
	void FixedUpdate () {
		if (!isDead) {

			isGrounded = Physics2D.OverlapCircle (groundCheck.position + new Vector3 (0, -.5f, 0), groundCheckRadius, groundLayers);
			if (isGrounded)
				collider.sharedMaterial.friction = 1;
			else
				collider.sharedMaterial.friction = 0;
			
			if (player.velocity.y < 0)
			{
				anim.SetBool ("isFalling", true);
			}
			else
			{
				anim.SetBool ("isFalling", false);
			}

			anim.SetBool ("isGrounded", isGrounded);
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
				isButtonDown = true;
			} else
				isButtonDown = false;
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
			{
				float move = Input.GetAxis ("Horizontal");
				if ((move > 0.0f && !isFacingRight) || (move < 0.0 && isFacingRight)) {
					Flip ();
				}
				if (!onIce) {
					player.velocity = new Vector2 (move * maxSpeed, player.velocity.y);
				}
				else 
				{	
					player.AddForce (new Vector2 (slipFactor * move, 0));
				}
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)||Input.GetKeyUp (KeyCode.RightArrow))
			{
				if(onIce)
				{
					int direction = 1;
					if (!isFacingRight)
						direction = -1;
					player.AddForce (new Vector2 (slipFactor*direction, 0),ForceMode2D.Force);
				}
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
					SceneManager.LoadScene (1);
			}

			float vel = player.velocity.x;
			anim.SetBool ("isButtonDown", isButtonDown);
			anim.SetFloat ("Velocity", player.velocity.x);
		} 
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x*-1;
		transform.localScale = playerScale;

	}
		


	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Ice")) {
			onIce = true;
			player.drag = .5f;
			gameObject.GetComponent<BoxCollider2D> ().sharedMaterial.friction = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Ice")==false) {
			onIce = false;
			player.drag = 2.0f;
			gameObject.GetComponent<BoxCollider2D> ().sharedMaterial.friction = 1;
		}

	}

	void OnCollisionExit2D(Collision2D c)
	{

	}

	void SetAnimationController(int num)
	{
		anim.SetInteger ("AnimationState", num);
	}
}
