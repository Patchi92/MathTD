using UnityEngine;
using System.Collections;

public class GridTile : MonoBehaviour
{

    GameObject Control;

    public bool setup = false;
    public int posX;
    public int posY;
    public int tileNumber;
  

	GameObject UI;
    public bool towerVandH; //Tower Vercical and Horizontal
	public bool towerD; //Tower Diagonal
	public bool towerSnipe; //Tower Instant Removes a flower
	bool towerBuild;


	public GameObject InfoVandH;
	public GameObject InfoD;
	public GameObject InfoSnipe;

	GameObject TowerOne;
	GameObject TowerTwo;
	GameObject TowerThree;

	GameObject CurrentTower;


	public bool tower;
	public bool road;
	public bool grass;
	public bool canBuild;

    int towerTurnLeft;

	public Sprite GrassTile;
	public Sprite GrassTileGrid;
	public Sprite TowerTile;
	public Sprite TowerTileGrid;
	public Sprite RoadTile;
	public Sprite RoadTileGrid;

	float fadeSpeed = 1f;
	float fadeColor;
	bool fadeIn;
	float fade;
	SpriteRenderer Render;


    // Use this for initialization
    void Start()
    {
		UI = GameObject.FindGameObjectWithTag("UI");
        Control = GameObject.FindGameObjectWithTag("Grid");
		Render = gameObject.GetComponent<SpriteRenderer>();


		grass = true;
		canBuild = false;
		road = false;
		tower = false;
		towerBuild = false;

		towerD = false;
		towerVandH = false;
		towerSnipe = false;

		TowerOne = (GameObject) Resources.Load("NewTower", typeof(GameObject));
		TowerTwo = (GameObject) Resources.Load("NewTowerTwo", typeof(GameObject));
		TowerThree = (GameObject) Resources.Load("TowerThree", typeof(GameObject));
			



    }

    // Update is called once per frame
    void Update()
    {




		if(UI.GetComponent<UIControl>().buildFade && gameObject.GetComponent<SpriteRenderer>().sprite == TowerTile)
		{
			
			if (!fadeIn) {
				Render.color = Color.Lerp(Render.color, Color.white, fadeSpeed * Time.deltaTime);
			}
			
			if (fadeIn) {
				Render.color = Color.Lerp(Render.color, Color.clear, fadeSpeed * Time.deltaTime);
			}
			
			if(Render.color.a >= 0.90f) {
				fadeIn = true;
			}
			
			if(Render.color.a <= 0.60f) {
				fadeIn = false;
			}
			
			Debug.Log("Fade");
			
		}
		





        
		if(canBuild)
		{

			if (!fadeIn) {
				Render.color = Color.Lerp(Render.color, Color.white, fadeSpeed * Time.deltaTime);
			}
			
			if (fadeIn) {
				Render.color = Color.Lerp(Render.color, Color.clear, fadeSpeed * Time.deltaTime);
			}

			if(Render.color.a >= 0.90f) {
				fadeIn = true;
			}

			if(Render.color.a <= 0.60f) {
				fadeIn = false;
			}



		}

		if(!canBuild && !UI.GetComponent<UIControl>().buildFade)
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		}


    }

	void OnMouseOver() 
	{
		if(UI.GetComponent<UIControl>().selectedTowerVandH && gameObject.GetComponent<SpriteRenderer>().sprite == TowerTile)
		{
			InfoVandH.SetActive(true);
		}

		if(UI.GetComponent<UIControl>().selectedTowerD && gameObject.GetComponent<SpriteRenderer>().sprite == TowerTile)
		{
			InfoD.SetActive(true);
		}

		if(UI.GetComponent<UIControl>().selectedTowerSnipe && gameObject.GetComponent<SpriteRenderer>().sprite == TowerTile)
		{
			InfoSnipe.SetActive(true);
		}
	}
	
	void OnMouseExit()
	{
		InfoVandH.SetActive(false);
		InfoD.SetActive(false);
		InfoSnipe.SetActive(false);
	}


    void OnMouseDown()
    {
        if (setup == true)
        {
            
			canBuild = false;


            Control.GetComponent<TowerDefGrid>().tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
            gameObject.GetComponentInChildren<TextMesh>().text = Control.GetComponent<TowerDefGrid>().tileNumber.ToString();
            tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
            BuildRoad();
			gameObject.layer = 9;
			Destroy(gameObject.GetComponent<BoxCollider2D>());
            setup = false;
        }


        if(Control.GetComponent<TowerDefGrid>().buildTower)
        {
            if(gameObject.GetComponent<SpriteRenderer>().sprite == TowerTile)
            {

				if(UI.GetComponent<UIControl>().selectedTowerVandH)
				{
					BuildTowerVandH();
				}

				if(UI.GetComponent<UIControl>().selectedTowerD)
				{
					BuildTowerD();
				}

				if(UI.GetComponent<UIControl>().selectedTowerSnipe)
				{
					BuildTowerSnipe();
				}

				UI.GetComponent<UIControl>().SelectNone();
				Control.GetComponent<TowerDefGrid>().TowerPlaced();
            }



        }


    }

  
	public void LevelGen() 
	{
		Control.GetComponent<TowerDefGrid>().tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
		gameObject.GetComponentInChildren<TextMesh>().text = Control.GetComponent<TowerDefGrid>().tileNumber.ToString();
		tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
		BuildRoad();
		gameObject.layer = 9;
		Destroy(gameObject.GetComponent<BoxCollider2D>());
		gameObject.tag = "Road";

	}

	public void ChangeToRoad()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
	}
	
	
	public void BuildRoad() 
	{
		Control.GetComponent<TowerDefGrid>().Road(posX, posY);
		road = true;
		grass = false;
	}



    public void RoundOver()
    {
        if (towerBuild)
        {
            --towerTurnLeft;
			--CurrentTower.GetComponent<TowerInfo>().turnsLeft;

            if (towerTurnLeft == 0)
            {
				towerD = false;
				towerVandH = false;
				towerSnipe = false;
				gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				Destroy(CurrentTower);

            }
        }
    }


	public void BuildTowerVandH() {

		CurrentTower = Instantiate(TowerOne,gameObject.transform.position,TowerOne.transform.rotation) as GameObject;
		towerVandH = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 3;
		CurrentTower.GetComponent<TowerInfo>().turnsLeft = 3;

		towerBuild = true;

	

	}


	public void BuildTowerD() {

		CurrentTower = Instantiate(TowerTwo,gameObject.transform.position,TowerTwo.transform.rotation) as GameObject;
		towerD = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 3;
		CurrentTower.GetComponent<TowerInfo>().turnsLeft = 3;

		towerBuild = true;
		
	}

	public void BuildTowerSnipe() {

		CurrentTower = Instantiate(TowerThree,gameObject.transform.position,TowerThree.transform.rotation) as GameObject;
		towerSnipe = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 1;
		CurrentTower.GetComponent<TowerInfo>().turnsLeft = 1;

		towerBuild = true;
	}
}
