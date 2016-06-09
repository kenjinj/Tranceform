using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	public GameObject ship;
	public AudioSource carRevUp;
	public AudioSource carRevDown;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	private int soundTimer1, soundTimer2;
	private int soundTimerLim;

	private GameController gameController;

	void Start() {
		soundTimerLim = 30;
		soundTimer1 = soundTimerLim;
		soundTimer2 = soundTimerLim;
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController>();
		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}
	
	void Update (){
		soundTimer1++;
		soundTimer2++;
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			if (gameController.tryUseNuke() == true){
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, Quaternion.Euler(0.0f,0.0f,45));
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && rigidbody.position.y > -1.2f){
			Destroy(gameObject);
			Instantiate(ship,rigidbody.position,transform.rotation);
		}
		if (Input.GetKeyDown (KeyCode.D) && soundTimer1 > soundTimerLim){
			soundTimer1 = 0;
			carRevUp.Play ();
		}
		if (Input.GetKeyDown (KeyCode.A) && soundTimer2 > soundTimerLim){
			soundTimer2 = 0;
			carRevDown.Play ();
		}
	}
	
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical/2, 0.0f);
		rigidbody.velocity = movement * speed;


		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * tilt);
	}
}
