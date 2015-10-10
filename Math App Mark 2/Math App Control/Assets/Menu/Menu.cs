using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject highScore;
    public GameObject options;

	// Use this for initialization
	void Start () {
        highScore.SetActive(false);
        options.SetActive(false);

        if(PlayerPrefs.GetString("New") != "No")
        {
            Debug.Log("New Player");
            PlayerPrefs.SetString("New", "No");
            PlayerPrefs.SetInt("High Score", 0);
            PlayerPrefs.SetInt("Rank", 0);
            PlayerPrefs.SetInt("Best Combo", 0);
            PlayerPrefs.SetInt("Current Combo", 0);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play ()
    {
        Application.LoadLevel("MathProblem");
    }

    public void HighScore ()
    {
        highScore.SetActive(true);
    }

    public void Options ()
    {
        options.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
