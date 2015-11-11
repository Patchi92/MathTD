using UnityEngine;
using System.Collections;

public class TowerInfo : MonoBehaviour {

	public GameObject Info;
	public GameObject HammerOne;
	public GameObject HammerTwo;
	public GameObject HammerThree;

	public int turnsLeft;

	// Use this for initialization
	void Start () {
	
		Info.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(turnsLeft == 3)
		{
			HammerOne.SetActive(true);
			HammerTwo.SetActive(true);
			HammerThree.SetActive(true);

		}

		if(turnsLeft == 2)
		{
			HammerOne.SetActive(false);
			HammerTwo.SetActive(true);
			HammerThree.SetActive(true);

		}


		if(turnsLeft == 1)
		{
			HammerOne.SetActive(false);
			HammerTwo.SetActive(false);
			HammerThree.SetActive(true);

		}


	}

	void OnMouseOver() 
	{
		Info.SetActive(true);
	}

	void OnMouseExit()
	{
		Info.SetActive(false);
	}
}
