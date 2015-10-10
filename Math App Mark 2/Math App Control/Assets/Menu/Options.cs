using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("Menu");
        
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
