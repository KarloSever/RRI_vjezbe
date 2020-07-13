using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StvarajHranu : MonoBehaviour {
	// hrana
	public GameObject hranaPrefab;

	// zidovi unutar kojih se zmija krece
	public Transform BorderTop;
	public Transform BorderBottom;
	public Transform BorderLeft;
	public Transform BorderRight;


	void Start () {
		// stvara hranu svake 4 sekunde
		InvokeRepeating("Stvaranje", 3, 4);
	}

	// stvaranje jednog elementa hrane
	void Stvaranje() {
		// x pozicija od lijevog i desnog zida
		int x = (int)Random.Range(BorderLeft.position.x,
			BorderRight.position.x);

		// y pozicija od gornjeg i donjeg zida
		int y = (int)Random.Range(BorderBottom.position.y,
			BorderTop.position.y);

		Instantiate(hranaPrefab,
			new Vector2(x, y),
			Quaternion.identity); 
	}
}
