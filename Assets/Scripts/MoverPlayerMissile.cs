using UnityEngine;
using System.Collections;

public class MoverPlayerMissile : MonoBehaviour {
	
	public int speed;
	public float detonationTime; 
	public GameObject dogeNuke;

	void Start (){
		StartCoroutine (Detonate());
		rigidbody.velocity = new Vector3(speed, speed, 0);
	}

	IEnumerator Detonate(){
		yield return new WaitForSeconds (detonationTime);
		Instantiate(dogeNuke,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
	}
}
