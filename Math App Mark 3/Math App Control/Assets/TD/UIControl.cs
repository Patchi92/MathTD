using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

    public GameObject Grid;

    public GameObject endMaze;
    public GameObject endTimer;
	public GameObject endMessage;
    public GameObject life;


	public bool selectedTowerVandH; //Tower Vercical and Horizontal
	public bool selectedTowerD; //Tower Diagonal
	public bool selectedTowerSnipe; //Tower Instant Removes a flower

	// Use this for initialization
	void Start () {

		endMessage.SetActive(true);
        endMaze.SetActive(false);
        endTimer.SetActive(true);
        life.SetActive(true);


		selectedTowerVandH = false;
		selectedTowerD = false;
		selectedTowerSnipe = false;


	}
	
	// Update is called once per frame
	void Update () {

        life.GetComponent<Text>().text = "Liv Tilbage: " + Grid.GetComponent<TowerDefGrid>().life.ToString();

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
	}
	
	
	public void SelectTowerD() {
		selectedTowerD = true;
		selectedTowerVandH = false;
		selectedTowerSnipe = false;

		
	}
	
	public void SelectTowerSnipe() {
		selectedTowerSnipe = true;
		selectedTowerVandH = false;
		selectedTowerD = false;

	}





}
