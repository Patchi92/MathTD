using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

    public GameObject Grid;

    public GameObject endMaze;
    public GameObject endTimer;
    public GameObject life;

	// Use this for initialization
	void Start () {

        endMaze.SetActive(false);
        endTimer.SetActive(false);
        life.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        life.GetComponent<Text>().text = Grid.GetComponent<TowerDefGrid>().life.ToString();

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
}
