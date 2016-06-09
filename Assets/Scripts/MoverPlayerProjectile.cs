using UnityEngine;
using System.Collections;

public class MoverPlayerProjectile : MonoBehaviour {
	
	public float speed;
	
	void Start (){
		rigidbody.velocity = new Vector3(1 * speed, 0, 0);
	}
}
