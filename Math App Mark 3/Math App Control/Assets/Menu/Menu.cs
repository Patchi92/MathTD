using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject highScore;
    public GameObject options;

	public GameObject LevelSelect;
	public GameObject MainMenu;

	// Use this for initialization
	void Start () {
        
		MainMenu.SetActive(true);

		highScore.SetActive(false);
        options.SetActive(false);
		LevelSelect.SetActive(false);

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
	
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}


	}

    public void Play ()
    {
		MainMenu.SetActive(false);
		LevelSelect.SetActive(true);
    }

    public void HighScore ()
    {
        highScore.SetActive(true);
    }

    public void Options ()
    {
        options.SetActive(true);
    }


	public void Back ()
	{
		LevelSelect.SetActive(false);
		MainMenu.SetActive(true);
	}

    public void Exit()
    {
        Application.Quit();
    }



	public void LevelOne()
	{
		Application.LoadLevel("LevelOne");
	}

	public void LevelTwo()
	{
		Application.LoadLevel("LevelTwo");
	}

	public void LevelThree()
	{
		Application.LoadLevel("LevelThree");
	}

	public void LevelSandbox()
	{
		Application.LoadLevel("LevelSandbox");
	}
}
