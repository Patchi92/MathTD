using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

	public string LevelName;

    public GameObject Grid;
	public GameObject UI;
	public GameObject winGame;
	public GameObject lostGame;

	public Texture2D normalMouse;
	public Texture2D towerVandHMouse;
	public Texture2D towerDMouse;
	public Texture2D towerSnipeMouse;
	CursorMode cursorMode = CursorMode.Auto;
	Vector2 clickSpot = Vector2.zero;


    public GameObject endMaze;
    public GameObject endTimer;
	public GameObject endMessage;
    public GameObject life;


	public bool selectedTowerVandH; //Tower Vercical and Horizontal
	public bool selectedTowerD; //Tower Diagonal
	public bool selectedTowerSnipe; //Tower Instant Removes a flower

	public bool buildFade;

	// Use this for initialization
	void Start () {

		UI.SetActive(true);
		winGame.SetActive(false);
		lostGame.SetActive(false);
		endMessage.SetActive(true);
        endMaze.SetActive(false);
        endTimer.SetActive(true);
        life.SetActive(true);


		selectedTowerVandH = false;
		selectedTowerD = false;
		selectedTowerSnipe = false;

		buildFade = false;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}
	}


	public void Menu() {
		Application.LoadLevel("Menu");
	}

	public void Reload() {
		Application.LoadLevel(LevelName);
	}


	public void Win() {
		UI.SetActive(false);
		winGame.SetActive(true);
	}

	public void Lost() {
		UI.SetActive(false);
		lostGame.SetActive(true);
	}


    public void EndMaze()
    {
        if(endMaze.activeSelf)
        {
           endMaze.SetActive(false);
        }
        else
        {
           endMaze.SetActive(true);
        }
    }

    public void EndTimer()
    {
        if (endTimer.activeSelf)
        {
            endTimer.SetActive(false);
        }
        else
        {
            endTimer.SetActive(true);
        }
    }



    public void BeginGame()
    {
        life.SetActive(true);
    }



	public void SelectTowerVandH() {
		selectedTowerVandH = true;
		selectedTowerD = false;
		selectedTowerSnipe = false;
		Cursor.SetCursor(towerVandHMouse, clickSpot, cursorMode);

		buildFade = true;
	}
	
	
	public void SelectTowerD() {
		selectedTowerD = true;
		selectedTowerVandH = false;
		selectedTowerSnipe = false;
		Cursor.SetCursor(towerDMouse, clickSpot, cursorMode);

		buildFade = true;
	}

	
	public void SelectTowerSnipe() {
		selectedTowerSnipe = true;
		selectedTowerVandH = false;
		selectedTowerD = false;
		Cursor.SetCursor(towerSnipeMouse, clickSpot, cursorMode);

		buildFade = true;
	}


	public void SelectNone() {
		selectedTowerSnipe = false;
		selectedTowerVandH = false;
		selectedTowerD = false;
		Cursor.SetCursor(normalMouse, clickSpot, cursorMode);

		buildFade = false;
	}





}
