using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    public GameObject highscore;
    public GameObject rank;
    public GameObject combo;
    public GameObject currentCombo;

    

	// Use this for initialization
	void Start () {
        highscore.GetComponent<Text>().text = "Din High Score: " + PlayerPrefs.GetInt("High Score");
        rank.GetComponent<Text>().text = "Din Rank: " + PlayerPrefs.GetInt("Rank");
        combo.GetComponent<Text>().text = "Din Bedste Combo: " + PlayerPrefs.GetInt("Best Combo");
        currentCombo.GetComponent<Text>().text = "Din Nuværende Combo: " + PlayerPrefs.GetInt("Current Combo");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
