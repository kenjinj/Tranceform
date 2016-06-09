using UnityEngine;
using System.Collections;

public class DestroyByContactProjectile : MonoBehaviour {
	
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
		if (other.tag == "Boundary" || other.tag == "Background" || other.tag == "EnemyFire" || other.tag == "Laser1" || other.tag == "Laser2" || other.tag == "Laser3")
			return;
		if (other.tag == "Player") {
			Destroy (gameObject);
			gameController.takeDamage(1);
		}
		if (other.tag == "DogeNuke")
			Destroy (gameObject);
	}
}
