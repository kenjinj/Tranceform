using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard1;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject gameOverMessage;

	private int health;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public bool gameOver;
	private bool restart;
	private int score;
	private int enemySelect;
	private int numberNukes;

	private ShipController shipController;

	void Start () {
		health = 5;
		numberNukes = 3;
		gameOver = false;
		restart = false;
		enemySelect = 1;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());

		GameObject shipControllerObject = GameObject.FindWithTag("Player");
		if (shipControllerObject != null)
			shipController = shipControllerObject.GetComponent <ShipController>();
		if (shipController == null)
			Debug.Log ("Cannot find 'ShipController' script");
	}

	void Update (){
		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}
		if (restart){
			if (Input.GetKeyDown (KeyCode.R)){
				Destroy(gameObject);
				Application.LoadLevel ("Main");
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (!gameOver) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y + 3, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				enemySelect = Random.Range (1,4);
				if (enemySelect == 1)
					Instantiate (hazard1, spawnPosition, spawnRotation);
				if (enemySelect == 2)
					Instantiate (hazard2, spawnPosition, spawnRotation);
				if (enemySelect == 3)
					Instantiate (hazard3, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			hazardCount++;
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver (){
		//gameOverText.text = "Game Over!";
		gameOver = true;
		restart = true;
		if (Application.loadedLevelName == "Main") 
			DontDestroyOnLoad(gameObject);
		Application.LoadLevel ("GameOver");
	}

	void UpdateScore(){
		//scoreText.text = "Score: " + score;
	}
	
	public void takeDamage (int damage){
		health -= damage;
		if (health <= 0){
			GameOver();
			shipController.playerDead();
		}
	}

	public bool tryUseNuke(){
		if(numberNukes > 0){
			numberNukes--;
			return true;
		}
		else
			return false;
	}

	public int getScore(){
		return score;
	}
}
