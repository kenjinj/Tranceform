using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public int fireRate;

	private int fireCounter = 240;

	void Update (){
		fireCounter++;
		if (fireCounter > fireRate){
			Instantiate (shot, shotSpawn.position, Quaternion.identity);
			fireCounter = 0;
		}
	}
}
