using UnityEngine;
using System.Collections;

public class TurnOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(gameObject.activeSelf == true)
		{
			Invoke("TurnOffInfo",1);
		}


	}

	void TurnOffInfo() {

		gameObject.SetActive(false);

	}

}
