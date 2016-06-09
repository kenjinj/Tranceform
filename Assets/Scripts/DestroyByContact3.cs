using UnityEngine;
using System.Collections;

public class DestroyByContact3 : MonoBehaviour {
	
	public int scoreValue;
	private GameController gameController;

	void Start (){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController>();
		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag == "Background" || other.tag == "EnemyFire" || other.tag == "Laser1" || other.tag == "Laser2")
			return;
		if (other.tag == "Player") {		
			gameController.GameOver();
		}
		if (other.tag != "DogeNuke")
			Destroy (other.gameObject);
		Destroy (gameObject);
		gameController.AddScore(scoreValue);
	}
}
