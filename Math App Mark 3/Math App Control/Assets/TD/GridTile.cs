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

	float fadeSpeed = 1f;
	float fadeTime = 10f;
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





    }

    // Update is called once per frame
    void Update()
    {


        /*
		if(canBuild)
		{

			if (!fadeIn) {
				fade = Mathf.SmoothDamp(0f,1f,ref fadeSpeed,fadeTime);
				Render.color = new Color(1f,1f,1f,fade);
			}
			
			if (fadeIn) {
				fade = Mathf.SmoothDamp(1f,0f,ref fadeSpeed,fadeTime);
				Render.color = new Color(1f,1f,1f,fade);
			}

			if(Render.color.a == 1f) {
				fadeIn = true;
			}

			if(Render.color.a == 0f) {
				fadeIn = false;
			}



		}

		if(!canBuild)
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		}

		*/
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


            }

        }


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

            if (towerTurnLeft == 0)
            {
				towerD = false;
				towerVandH = false;
				towerSnipe = false;
				gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            }
        }
    }


	public void BuildTowerVandH() {

		gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
		towerVandH = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 3;

		towerBuild = true;

	

	}


	public void BuildTowerD() {

		gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
		towerD = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 3;

		towerBuild = true;
		
	}

	public void BuildTowerSnipe() {

		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		towerSnipe = true;
		Control.GetComponent<TowerDefGrid>().buildTower = false;
		towerTurnLeft = 1;

		towerBuild = true;
	}
}
