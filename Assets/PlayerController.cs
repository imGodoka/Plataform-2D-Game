using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Variáveis de Movimento
	public float speed;
	public float jumpHeight;


	//Variáveis de animação e Movimento
	public Transform groundCheck;
	public Transform groundCheck2;

	bool isGrounded;
	Rigidbody2D rb;
	public GameObject playerSpr;
	Animator anim;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = playerSpr.GetComponent<Animator> ();
		isGrounded = true;

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Jump ();
	}

	void Movement(){

		//Mover
		float getX = Input.GetAxisRaw("Horizontal");
		float mover_x = getX * speed * Time.deltaTime;
		transform.Translate (mover_x, 0f, 0f);

		if (getX != 0f) {
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}

		//Orientação de Sprite
		if (getX > 0) {
			playerSpr.transform.eulerAngles = new Vector2 (0f, 0f);
		} else if (getX < 0) {
			playerSpr.transform.eulerAngles = new Vector2 (0f, 180f);
		}
	}

	void Jump() {
		
		//Verifica Colisão
		isGrounded = 
			Physics2D.Linecast (transform.position, groundCheck.transform.position, 
			1 << LayerMask.NameToLayer ("Chão")) || 
			Physics2D.Linecast (transform.position, groundCheck2.transform.position, 
			1 << LayerMask.NameToLayer ("Chão")) ;

		anim.SetBool ("isGrounded", isGrounded);

		//Pula
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			rb.AddForce (Vector2.up * jumpHeight);
		}

	}

}
