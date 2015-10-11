using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

    public GameObject endMaze;
    public GameObject endTimer;

	// Use this for initialization
	void Start () {

        endMaze.SetActive(false);
        endTimer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
