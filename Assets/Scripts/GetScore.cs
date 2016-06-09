using UnityEngine;
using System.Collections;

public class GetScore : MonoBehaviour {

	public GUIText scoreText;

	private GameController gameController;

	void Start (){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController>();
		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void Update() {
		scoreText.text = "Score: " + gameController.getScore ();
	}
}
