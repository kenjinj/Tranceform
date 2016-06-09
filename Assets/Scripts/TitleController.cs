using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			Application.LoadLevel ("Main");
		}
	}
}
