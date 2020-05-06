using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool ideDesno=true;
	[HideInInspector] public bool skok= true;

	public float silaPokreta=365f;
	public float najvecaBrzina=5f;
	public float silaSkoka=1000f;
	public Transform provjeraPoda;

	private bool naPodu=false;
	private Animator anim;
	private Rigidbody2D rb2d;

	void Awake(){
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}


void Update(){
	naPodu=Physics2D.Linecast (transform.position, provjeraPoda.position, 
		1<<LayerMask.NameToLayer("Ground")); 

	//nema skakanja u zraku
	if(Input.GetButton("Jump")&& naPodu){
		skok=true;
	}
}

void Okreni(){
	ideDesno=!ideDesno;

	Vector3 theScale=transform.localScale;
	theScale.x*=-1;
	transform.localScale=theScale;
}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (h));

		if (h * rb2d.velocity.x < najvecaBrzina)
			rb2d.AddForce (Vector2.right * h * silaPokreta);

		if (Mathf.Abs (rb2d.velocity.x) > najvecaBrzina)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * najvecaBrzina, rb2d.velocity.y);
	
		if (h > 0 && !ideDesno)
			Okreni ();
		else if (h < 0 && ideDesno)
			Okreni();

		if (skok) {
			anim.SetTrigger ("Jump");
			rb2d.AddForce (new Vector2 (0f, silaSkoka));
			skok = false;
		}
	}
}