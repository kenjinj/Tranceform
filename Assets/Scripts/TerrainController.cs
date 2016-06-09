using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {

	public GameObject mountain;

	public float spawnWait;
	private GameController gameController;
	private Vector3 spawnPosition = new Vector3(10f,0f);

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController>();
		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
		StartCoroutine (SpawnMountains());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnMountains(){
		while (!gameController.gameOver){
			float rotation = Random.Range (-5f,5f);
			var instantiatedPrefab = Instantiate(mountain,spawnPosition,Quaternion.Euler(0.0f,0.0f,rotation)) as GameObject;
			float scale = Random.Range (0.4f,1.2f);
			instantiatedPrefab.transform.localScale = new Vector3(scale,scale,1);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
