using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Zmija : MonoBehaviour {
	// provjera da li je zmija u doticaju sa hranom
	bool hrana = false;
	public GameObject repPrefab;
	// za listu na kojoj je broj elementa repa
	List<Transform> rep = new List<Transform>();
	// zmija se po defaultu na pocetku krece desno
	Vector2 dir = Vector2.right;

	void Start () {
		//brzina kretanja zmije
		InvokeRepeating("Kretanje", 0.1f, 0.1f);    
	}
		
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow))
			dir = -Vector2.up;    
		else if (Input.GetKey(KeyCode.LeftArrow))
			dir = -Vector2.right; 
		else if (Input.GetKey(KeyCode.UpArrow))
			dir = Vector2.up;
	}

	void Kretanje() {
		Vector2 v = transform.position;
		transform.Translate(dir);
		if (hrana) {
			// ucita se prefab
			GameObject g =(GameObject)Instantiate(repPrefab, v, Quaternion.identity);
			// vodi se broj repova
			rep.Insert(0, g.transform);

			hrana = false;
		}

		// provjera da li zmija ima rep
		if (rep.Count > 0) {
			// zadnji element repa se pomice na mjesto gdje je glava bila
			rep.Last().position = v;

			// dodaje se ispred liste repova i uklanja s kraja
			rep.Insert(0, rep.Last());
			rep.RemoveAt(rep.Count-1);
		}
}

	void OnTriggerEnter2D(Collider2D coll) {
		// ako zmija naidje na hranu
		if (coll.name.StartsWith("hranaPrefab")) {
			// zmija se produzi u iducem pokretu
			hrana = true;

			// ukloni se hrana kad zmija ima koliziju sa objektom
			Destroy(coll.gameObject);
		}
		// igra se ponovo pokrece kod sudara sa zidom
		else {
			Application.LoadLevel ("Game");
		}
	}
}
