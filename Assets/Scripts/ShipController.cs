using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	
	public float xMin, xMax, yMin, yMax;
}

public class ShipController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	public GameObject car;

	public GameObject shot1;
	public GameObject shot2;
	public GameObject shot3;
	public Transform shotSpawn;
	public float fireRate;

	public AudioSource laser1;
	public AudioSource laser2;
	public AudioSource laser3;

	private float nextFire;
	private int shotSelect;
	private GameController gameController;

	void Start() {
		shotSelect = 1;
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController>();
		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void Update (){
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if (shotSelect == 1){
				Instantiate (shot1, shotSpawn.position, Quaternion.identity);
				laser1.Play ();
			}
			if (shotSelect == 2){
				Instantiate (shot2, shotSpawn.position, Quaternion.identity);
				laser2.Play ();
			}
			if (shotSelect == 3){
				Instantiate (shot3, shotSpawn.position, Quaternion.identity);
				laser3.Play ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha1))
			shotSelect = 1;
		if (Input.GetKeyDown (KeyCode.Alpha2))
			shotSelect = 2;
		if (Input.GetKeyDown (KeyCode.Alpha3))
			shotSelect = 3;
		if (Input.GetKeyDown (KeyCode.LeftShift) && rigidbody.position.y < -0.1f){
			Destroy(gameObject);
			Instantiate(car,rigidbody.position,transform.rotation);
		}
	}
	
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;


		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	public void playerDead(){
		Destroy(gameObject);
	}
}
