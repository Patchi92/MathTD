using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerDefGrid : MonoBehaviour
{
    public GameObject UI;
	public string LevelToLoad;

    public GameObject timer;
	public GameObject message;

    GameObject gridTileStart;
    GameObject gridTileEnd;
	public GameObject[] Roads;

    public GameObject[] Enemies;

    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;
	public GameObject enemy7;
	public GameObject enemy8;
	public GameObject enemy9;

	bool enemy2Allowed;
	bool enemy3Allowed;
	bool enemy4Allowed;
	bool enemy5Allowed;
	bool enemy6Allowed;
	bool enemy7Allowed;
	bool enemy8Allowed;
	bool enemy9Allowed;


	// Towers

	public Sprite GrassTile;
	public Sprite GrassTileGrid;
	public Sprite TowerTile;
	public Sprite TowerTileGrid;
	public Sprite RoadTile;
	public Sprite RoadTileGrid;

	public GameObject Splash;



    // Grid

    public GameObject tile;
    int gridWidth;
    int gridHeight;

    GameObject[,] grid = new GameObject[15, 15];

	public Vector2[] Coord;


    public bool firstRun;

    public int tileNumber = 0;
    

    public bool buildTower;

    int towerPointXOne;
    int towerPointYOne;
    int towerPointXTwo;
    int towerPointYTwo;
    int towerPointXThree;
    int towerPointYThree;
    int towerPointXFour;
    int towerPointYFour;
	int towerPointXFive;
	int towerPointYFive;
	int towerPointXSix;
	int towerPointYSix;
	int towerPointXSeven;
	int towerPointYSeven;
	int towerPointXEight;
	int towerPointYEight;


    bool towerPointOne = false;
    bool towerPointTwo = false;
    bool towerPointThree = false;
    bool towerPointFour = false;

	bool towerPointFive = false;
	bool towerPointSix = false;
	bool towerPointSeven = false;
	bool towerPointEight = false;


    // Rounds

    bool roundBuild;
    int roundTime;
    bool reduceTime;

    bool waitingRound;
    int waitingTime;
    bool reduceWaitngTime;

    bool towerRound;
    int towerTime;
    bool reduceTowerTime;

	// Enemy
	public Vector2 startPos;


    // Life
    public int life;
	public GameObject lifeOne;
	public GameObject lifeTwo;
	public GameObject lifeThree;


	// Levels

	public bool levelOne;
	public bool levelTwo;
	public bool levelThree;
	public bool levelFour;
	public bool levelFive;

	public bool levelSandbox;


    // Use this for initialization
    void Start()
    {
        CreateGrid();
        firstRun = true;
        roundBuild = false;
        waitingRound = false;
        buildTower = false;
        life = 3;


		if(levelOne)
		{
			enemy2Allowed = true;
			enemy3Allowed = false;
			enemy4Allowed = true;
			enemy5Allowed = false;
			enemy6Allowed = true;
			enemy7Allowed = false;
			enemy8Allowed = false;
			enemy9Allowed = false;
		}

		if(levelTwo)
		{
			enemy2Allowed = false;
			enemy3Allowed = true;
			enemy4Allowed = false;
			enemy5Allowed = false;
			enemy6Allowed = true;
			enemy7Allowed = false;
			enemy8Allowed = false;
			enemy9Allowed = true;
		}

		if(levelThree)
		{
			enemy2Allowed = false;
			enemy3Allowed = false;
			enemy4Allowed = false;
			enemy5Allowed = true;
			enemy6Allowed = false;
			enemy7Allowed = false;
			enemy8Allowed = false;
			enemy9Allowed = false;
			
		}

		if(levelFour)
		{
			enemy2Allowed = false;
			enemy3Allowed = false;
			enemy4Allowed = true;
			enemy5Allowed = false;
			enemy6Allowed = false;
			enemy7Allowed = false;
			enemy8Allowed = true;
			enemy9Allowed = false;
		}

		if(levelFive)
		{
			enemy2Allowed = false;
			enemy3Allowed = false;
			enemy4Allowed = false;
			enemy5Allowed = true;
			enemy6Allowed = false;
			enemy7Allowed = true;
			enemy8Allowed = false;
			enemy9Allowed = false;
		}

		if(levelSandbox)
		{
			enemy2Allowed = true;
			enemy3Allowed = true;
			enemy4Allowed = true;
			enemy5Allowed = true;
			enemy6Allowed = true;
			enemy7Allowed = true;
			enemy8Allowed = true;
			enemy9Allowed = true;
		}



        gridTileStart = (GameObject)Instantiate(tile);
        gridTileStart.transform.position = new Vector2(gridTileStart.transform.position.x + 1, gridTileStart.transform.position.y + 4);
        gridTileStart.GetComponent<GridTile>().posX = 1;
        gridTileStart.GetComponent<GridTile>().posY = 3;
        gridTileStart.transform.tag = "Start";
		gridTileStart.layer = 9;
        gridTileStart.GetComponentInChildren<TextMesh>().text = tileNumber.ToString();
        grid[1, 4] = gridTileStart;

		gridTileStart.GetComponent<GridTile>().tileNumber = 0;
		startPos = gridTileStart.transform.position;

        gridTileEnd = (GameObject)Instantiate(tile);
        gridTileEnd.transform.position = new Vector2(gridTileEnd.transform.position.x + 14, gridTileEnd.transform.position.y + 11);
        gridTileEnd.GetComponent<GridTile>().posX = 12;
        gridTileEnd.GetComponent<GridTile>().posY = 10;
        gridTileEnd.transform.tag = "End";
		gridTileEnd.layer = 9;
        grid[14, 11] = gridTileEnd;

        grid[1, 4].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
        grid[14, 11].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;

		grid[1, 4].GetComponent<GridTile>().road = true;
		grid[14, 11].GetComponent<GridTile>().road = true;


		Invoke("Build", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (roundBuild)
        {
			message.GetComponent<Text>().text = "D e t  e r  d i n  t u r !";
            timer.GetComponent<Text>().text = "T i d :  " + roundTime;

            if (reduceTime)
            {
                Invoke("ReduceTime", 1);
                reduceTime = false;
            }

            if (roundTime == 0)
            {
                WaitRound();

            }



        }

        if (waitingRound)
        {
            message.GetComponent<Text>().text = "B l o m s t e r n e s  t u r !";

            if (reduceWaitngTime)
            {
                Invoke("ReduceWaitingTime", 1);
                reduceWaitngTime = false;
            }

            if (waitingTime == 0)
            {
                TowerRound();
            }
        }


        if (towerRound)
        {
            message.GetComponent<Text>().text = "V a n d k a m p !";

            if (reduceTowerTime)
            {
                Invoke("ReduceTowerTime", 1);
                reduceTowerTime = false;
            }

            if (towerTime == 0)
            {
                NewRound();
            }
        }


		if(life == 3)
		{
			lifeOne.SetActive(true);
			lifeTwo.SetActive(true);
			lifeThree.SetActive(true);
		}

		if(life == 2)
		{
			lifeOne.SetActive(false);
			lifeTwo.SetActive(true);
			lifeThree.SetActive(true);
		}

		if(life == 1)
		{
			lifeOne.SetActive(false);
			lifeTwo.SetActive(false);
			lifeThree.SetActive(true);
		}



        if(life == 0)
        {
            Application.LoadLevel(LevelToLoad);
        }


    }

    void Build()
    {

		if(levelOne) 
		{
			grid[2, 4].GetComponent<GridTile>().LevelGen();
			grid[3, 4].GetComponent<GridTile>().LevelGen();
			grid[4, 5].GetComponent<GridTile>().LevelGen();
			grid[3, 6].GetComponent<GridTile>().LevelGen();
			grid[3, 7].GetComponent<GridTile>().LevelGen();
			grid[3, 8].GetComponent<GridTile>().LevelGen();
			grid[4, 9].GetComponent<GridTile>().LevelGen();
			grid[5, 8].GetComponent<GridTile>().LevelGen();
			grid[6, 8].GetComponent<GridTile>().LevelGen();
			grid[7, 8].GetComponent<GridTile>().LevelGen();
			grid[7, 9].GetComponent<GridTile>().LevelGen();
			grid[7, 10].GetComponent<GridTile>().LevelGen();
			grid[7, 11].GetComponent<GridTile>().LevelGen();
			grid[8, 11].GetComponent<GridTile>().LevelGen();
			grid[9, 11].GetComponent<GridTile>().LevelGen();
			grid[9, 10].GetComponent<GridTile>().LevelGen();
			grid[9, 9].GetComponent<GridTile>().LevelGen();
			grid[9, 8].GetComponent<GridTile>().LevelGen();
			grid[9, 7].GetComponent<GridTile>().LevelGen();
			grid[10, 7].GetComponent<GridTile>().LevelGen();
			grid[11, 7].GetComponent<GridTile>().LevelGen();
			grid[12, 7].GetComponent<GridTile>().LevelGen();
			grid[13, 7].GetComponent<GridTile>().LevelGen();
			grid[13, 8].GetComponent<GridTile>().LevelGen();
			grid[13, 9].GetComponent<GridTile>().LevelGen();
			grid[12, 9].GetComponent<GridTile>().LevelGen();
			grid[11, 9].GetComponent<GridTile>().LevelGen();
			grid[11, 10].GetComponent<GridTile>().LevelGen();
			grid[11, 11].GetComponent<GridTile>().LevelGen();
			grid[12, 11].GetComponent<GridTile>().LevelGen();
			grid[13, 11].GetComponent<GridTile>().LevelGen();

			Roads = GameObject.FindGameObjectsWithTag("Road");
			
			foreach (GameObject Road in Roads)
			{
				Road.GetComponent<GridTile>().ChangeToRoad();
			}

		}
		
		if(levelTwo) 
		{
			Road(1, 4);
		}

		if(levelThree) 
		{
			Road(1, 4);
		}

		if(levelFour) 
		{
			Road(1, 4);
		}

		if(levelFive) 
		{
			Road(1, 4);
		}

		if(levelSandbox) 
		{
			Road(1, 4);
		}
	}
	
	void CreateGrid()
    {
        gridWidth = 14;
        gridHeight = 14;


        for (int x = 2; x < gridWidth; x++)
        {
            for (int y = 2; y < gridWidth; y++)
            {
                GameObject gridTile = (GameObject)Instantiate(tile);
                gridTile.transform.position = new Vector2(gridTile.transform.position.x + x, gridTile.transform.position.y + y);
                gridTile.GetComponent<GridTile>().posX = x;
                gridTile.GetComponent<GridTile>().posY = y;
                grid[x, y] = gridTile;

            }

        }


    }

    public void Road(int x, int y)
    {

        Towerblock();



		// Horizontal and Vertical

        if (grid[x + 1, y] != null)
        {

            if (grid[x + 1, y].tag != "End")
            {


				if (grid[x + 1, y].GetComponent<GridTile>().road == false && grid[x + 1, y].GetComponent<GridTile>().tower == false)
                {
                    grid[x + 1, y].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
					grid[x + 1, y].GetComponent<GridTile>().canBuild = true;
                    grid[x + 1, y].GetComponent<GridTile>().setup = true;
                    towerPointXOne = x + 1;
                    towerPointYOne = y;
                    towerPointOne = true;
                }
                else
                {
                    towerPointOne = false;
                }
            }
            else
            {
                UI.GetComponent<UIControl>().EndMaze();
            }
        }

        if (grid[x - 1, y] != null)
        {
            if (grid[x - 1, y].tag != "End")
            {

				if (grid[x - 1, y].GetComponent<GridTile>().road == false && grid[x - 1, y].GetComponent<GridTile>().tower == false)
                {
					grid[x - 1, y].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
					grid[x - 1, y].GetComponent<GridTile>().canBuild = true;
                    grid[x - 1, y].GetComponent<GridTile>().setup = true;
                    towerPointXTwo = x - 1;
                    towerPointYTwo = y;
                    towerPointTwo = true;
                }
                else
                {
                    towerPointTwo = false;
                }
            }
            else
            {
                UI.GetComponent<UIControl>().EndMaze();
            }

        }





        if (grid[x, y + 1] != null)
        {
            if (grid[x, y + 1].tag != "End")
            {


				if (grid[x, y + 1].GetComponent<GridTile>().road == false && grid[x, y + 1].GetComponent<GridTile>().tower == false)
                {
					grid[x, y + 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
					grid[x, y + 1].GetComponent<GridTile>().canBuild = true;
                    grid[x, y + 1].GetComponent<GridTile>().setup = true;
                    towerPointXThree = x;
                    towerPointYThree = y + 1;
                    towerPointThree = true;
                }
                else
                {
                    towerPointThree = false;
                }
            }
            else
            {
                UI.GetComponent<UIControl>().EndMaze();
            }
        }

        if (grid[x, y - 1] != null)
        {
            if (grid[x, y - 1].tag != "End")
            {


				if (grid[x, y - 1].GetComponent<GridTile>().road == false && grid[x, y - 1].GetComponent<GridTile>().tower == false)
                {
					grid[x, y - 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
					grid[x, y - 1].GetComponent<GridTile>().canBuild = true;
                    grid[x, y - 1].GetComponent<GridTile>().setup = true;
                    towerPointXFour = x;
                    towerPointYFour = y - 1;
                    towerPointFour = true;
                }
                else
                {
                    towerPointFour = false;
                }
            }
            else
            {
                UI.GetComponent<UIControl>().EndMaze();
            }
        }



		// Diagonal



		if (grid[x + 1, y + 1] != null)
		{

			if (grid[x + 1, y + 1].GetComponent<GridTile>().road == false && grid[x + 1, y + 1].GetComponent<GridTile>().tower == false)
			{
				grid[x + 1, y + 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
				grid[x + 1, y + 1].GetComponent<GridTile>().canBuild = true;
				grid[x + 1, y + 1].GetComponent<GridTile>().setup = true;
				towerPointXFive = x + 1;
				towerPointYFive = y + 1;
				towerPointFive = true;
			}
			else
			{
				towerPointFive = false;
			}


		}


		if (grid[x + 1, y - 1] != null)
		{
			if (grid[x + 1, y - 1].GetComponent<GridTile>().road == false && grid[x + 1, y - 1].GetComponent<GridTile>().tower == false)
			{
				grid[x + 1, y - 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
				grid[x + 1, y - 1].GetComponent<GridTile>().canBuild = true;
				grid[x + 1, y - 1].GetComponent<GridTile>().setup = true;
				towerPointXSix = x + 1;
				towerPointYSix = y - 1;
				towerPointSix = true;
			}
			else
			{
				towerPointSix = false;
			}
			
		}


		if (grid[x - 1, y + 1] != null)
		{
			if (grid[x - 1, y + 1].GetComponent<GridTile>().road == false && grid[x - 1, y + 1].GetComponent<GridTile>().tower == false)
			{
				grid[x - 1, y + 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
				grid[x - 1, y + 1].GetComponent<GridTile>().canBuild = true;
				grid[x - 1, y + 1].GetComponent<GridTile>().setup = true;
				towerPointXSeven = x - 1;
				towerPointYSeven = y + 1;
				towerPointSeven = true;
			}
			else
			{
				towerPointSeven = false;
			}
		}


		if (grid[x - 1, y - 1] != null)
		{
			if (grid[x - 1, y - 1].GetComponent<GridTile>().road == false && grid[x - 1, y - 1].GetComponent<GridTile>().tower == false)
			{
				grid[x - 1, y - 1].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;
				grid[x - 1, y - 1].GetComponent<GridTile>().canBuild = true;
				grid[x - 1, y - 1].GetComponent<GridTile>().setup = true;
				towerPointXEight = x - 1;
				towerPointYEight = y - 1;
				towerPointEight = true;
			}
			else
			{
				towerPointEight = false;
			}
		}



		grid[1, 4].GetComponent<SpriteRenderer>().sprite = RoadTileGrid;



    }

    public void Towerblock()
    {

        if (towerPointOne)
        {
            if (grid[towerPointXOne, towerPointYOne].GetComponent<GridTile>().canBuild)
            {
                grid[towerPointXOne, towerPointYOne].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
                grid[towerPointXOne, towerPointYOne].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointTwo)
        {
			if (grid[towerPointXTwo, towerPointYTwo].GetComponent<GridTile>().canBuild)
            {
				grid[towerPointXTwo, towerPointYTwo].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
                grid[towerPointXTwo, towerPointYTwo].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointThree)
        {
			if (grid[towerPointXThree, towerPointYThree].GetComponent<GridTile>().canBuild)
            {
				grid[towerPointXThree, towerPointYThree].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
                grid[towerPointXThree, towerPointYThree].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointFour)
        {
			if (grid[towerPointXFour, towerPointYFour].GetComponent<GridTile>().canBuild)
            {
				grid[towerPointXFour, towerPointYFour].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
                grid[towerPointXFour, towerPointYFour].GetComponent<GridTile>().setup = false;
            }
        }

		if (towerPointFive)
		{
			if (grid[towerPointXFive, towerPointYFive].GetComponent<GridTile>().canBuild)
			{
				grid[towerPointXFive, towerPointYFive].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
				grid[towerPointXFive, towerPointYFive].GetComponent<GridTile>().setup = false;
			}
		}

		if (towerPointSix)
		{
			if (grid[towerPointXSix, towerPointYSix].GetComponent<GridTile>().canBuild)
			{
				grid[towerPointXSix, towerPointYSix].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
				grid[towerPointXSix, towerPointYSix].GetComponent<GridTile>().setup = false;
			}
		}

		if (towerPointSeven)
		{
			if (grid[towerPointXSeven, towerPointYSeven].GetComponent<GridTile>().canBuild)
			{
				grid[towerPointXSeven, towerPointYSeven].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
				grid[towerPointXSeven, towerPointYSeven].GetComponent<GridTile>().setup = false;
			}
		}

		if (towerPointEight)
		{
			if (grid[towerPointXEight, towerPointYEight].GetComponent<GridTile>().canBuild)
			{
				grid[towerPointXEight, towerPointYEight].GetComponent<SpriteRenderer>().sprite = TowerTileGrid;
				grid[towerPointXEight, towerPointYEight].GetComponent<GridTile>().setup = false;
			}
		}

    }


    public void Begin()
    {
        UI.GetComponent<UIControl>().EndMaze();
        UI.GetComponent<UIControl>().BeginGame();
		
        gridTileEnd.GetComponent<GridTile>().tileNumber = tileNumber + 1;

		gridWidth = 14;
		gridHeight = 14;

        for (int x = 2; x < gridWidth; x++)
        {
            for (int y = 2; y < gridWidth; y++)
            {
                if (grid[x, y].GetComponent<SpriteRenderer>().sprite == GrassTileGrid)
                {
					grid[x, y].GetComponent<SpriteRenderer>().sprite = GrassTile;
                }

				if (grid[x, y].GetComponent<SpriteRenderer>().sprite == RoadTileGrid)
				{
					grid[x, y].GetComponent<SpriteRenderer>().sprite = RoadTile;
				}

				if (grid[x, y].GetComponent<SpriteRenderer>().sprite == TowerTileGrid)
                {
					grid[x, y].GetComponent<SpriteRenderer>().sprite = TowerTile;
                }

				if (grid[x, y].GetComponent<GridTile>().canBuild)
				{
					grid[x, y].GetComponent<SpriteRenderer>().sprite = TowerTile;
					grid[x, y].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
				}


				grid[1, 4].GetComponent<SpriteRenderer>().sprite = RoadTile;
				grid[14, 11].GetComponent<SpriteRenderer>().sprite = RoadTile;


				if (grid[x, y].tag == "Road")
				{
					grid[x, y].GetComponent<SpriteRenderer>().sprite = RoadTile;
				}

            }

        }


        NewRound();

    }

    public void Restart()
    {
        Application.LoadLevel("MathTowerDefTest");
    }


    void NewRound()
    {
        Debug.Log("New Round");
        roundTime = 5;
        roundBuild = true;
        towerRound = false;
        reduceTime = true;
        SpawnEnemy();

        buildTower = true;



        gridWidth = 14;
        gridHeight = 14;

        for (int x = 2; x < gridWidth; x++)
        {
            for (int y = 2; y < gridWidth; y++)
            {
                grid[x,y].GetComponent<GridTile>().RoundOver();
            }

        }

    }

    void WaitRound()
    {
        Debug.Log("Wait Round");
        waitingTime = 3;
        waitingRound = true;
        roundBuild = false;
        reduceWaitngTime = true;
        MoveEnemy();


        buildTower = false;
    }

    void TowerRound()
    {
        Debug.Log("Tower Round");
        towerTime = 1;
        towerRound = true;
        waitingRound = false;
        reduceTowerTime = true;
        ShootEnemy();


    }

    void ReduceTime()
    {
        --roundTime;
        reduceTime = true;

    }

    void ReduceWaitingTime()
    {
        --waitingTime;
        reduceWaitngTime = true;
    }

    void ReduceTowerTime()
    {
        --towerTime;
        reduceTowerTime = true;
    }

    void SpawnEnemy()
    {
        int random;
		bool SpawnUnite = true;

		while(SpawnUnite) {

			random = Random.Range(1, 9);

			if(enemy2Allowed)
			{
		        if (random == 1)
		        {
		            GameObject Enemy2 = (GameObject)Instantiate(enemy2);
		            Enemy2.transform.position = startPos;
					SpawnUnite = false;
		        }
			}

			if(enemy3Allowed)
			{
		        if (random == 2)
		        {
		            GameObject Enemy3 = (GameObject)Instantiate(enemy3);
					Enemy3.transform.position = startPos;
					SpawnUnite = false;
		        }
			}

			if(enemy4Allowed)
			{
		        if (random == 3)
		        {
		            GameObject Enemy4 = (GameObject)Instantiate(enemy4);
					Enemy4.transform.position = startPos;
					SpawnUnite = false;
		        }
			}

			if(enemy5Allowed)
			{
		        if (random == 4)
		        {
		            GameObject Enemy5 = (GameObject)Instantiate(enemy5);
					Enemy5.transform.position = startPos;
					SpawnUnite = false;
		        }
			}

			if(enemy6Allowed)
			{
				if (random == 5)
				{
					GameObject Enemy6 = (GameObject)Instantiate(enemy6);
					Enemy6.transform.position = startPos;
					SpawnUnite = false;
				}
			}

			if(enemy7Allowed)
			{
				if (random == 6)
				{
					GameObject Enemy7 = (GameObject)Instantiate(enemy7);
					Enemy7.transform.position = startPos;
					SpawnUnite = false;
				}
			}

			if(enemy8Allowed)
			{
				if (random == 7)
				{
					GameObject Enemy8 = (GameObject)Instantiate(enemy8);
					Enemy8.transform.position = startPos;
					SpawnUnite = false;
				}
			}

			if(enemy9Allowed)
			{
				if (random == 8)
				{
					GameObject Enemy9 = (GameObject)Instantiate(enemy9);
					Enemy9.transform.position = startPos;
					SpawnUnite = false;
				}
			}

		}


      
    }

    void MoveEnemy()
    {


		Coord = new Vector2[10];

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in Enemies)
        {



            if (Enemy.GetComponent<Enemy>().multi == 2)
            {

                gridWidth = 14;
                gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
                        
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
                        {
                            Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 2;
				Enemy.GetComponent<Enemy>().firstRun = false;

				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];

            }


            if (Enemy.GetComponent<Enemy>().multi == 3)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 3;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
            }


            if (Enemy.GetComponent<Enemy>().multi == 4)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 4;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
            }


            if (Enemy.GetComponent<Enemy>().multi == 5)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
						{
							Coord[5] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}


                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 5;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
				Enemy.GetComponent<Enemy>().path[5] = Coord[5];
            }


            if (Enemy.GetComponent<Enemy>().multi == 6)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
						{
							Coord[5] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 6)
						{
							Coord[6] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 6;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
				Enemy.GetComponent<Enemy>().path[5] = Coord[5];
				Enemy.GetComponent<Enemy>().path[6] = Coord[6];

            }


            if (Enemy.GetComponent<Enemy>().multi == 7)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
						{
							Coord[5] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 6)
						{
							Coord[6] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 7)
                        {
							Coord[7] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 7;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
				Enemy.GetComponent<Enemy>().path[5] = Coord[5];
				Enemy.GetComponent<Enemy>().path[6] = Coord[6];
				Enemy.GetComponent<Enemy>().path[7] = Coord[7];

            }


            if (Enemy.GetComponent<Enemy>().multi == 8)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
						{
							Coord[5] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 6)
						{
							Coord[6] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 7)
						{
							Coord[7] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 8)
                        {
							Coord[8] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 8;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
				Enemy.GetComponent<Enemy>().path[5] = Coord[5];
				Enemy.GetComponent<Enemy>().path[6] = Coord[6];
				Enemy.GetComponent<Enemy>().path[7] = Coord[7];
				Enemy.GetComponent<Enemy>().path[8] = Coord[8];

            }


            if (Enemy.GetComponent<Enemy>().multi == 9)
            {

				gridWidth = 14;
				gridHeight = 14;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep - 1 && Enemy.GetComponent<Enemy>().firstRun == true)
						{
							Coord[0] = startPos;
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep && Enemy.GetComponent<Enemy>().firstRun == false)
						{
							Coord[0] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
						{
							Coord[1] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
						{
							Coord[2] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
						{
							Coord[3] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
						{
							Coord[4] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
						{
							Coord[5] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 6)
						{
							Coord[6] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 7)
						{
							Coord[7] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}
						
						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 8)
						{
							Coord[8] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
						}

                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 9)
                        {
							Coord[9] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 9;
				Enemy.GetComponent<Enemy>().firstRun = false;
				
				Enemy.GetComponent<Enemy>().path[0] = Coord[0];
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
				Enemy.GetComponent<Enemy>().path[2] = Coord[2];
				Enemy.GetComponent<Enemy>().path[3] = Coord[3];
				Enemy.GetComponent<Enemy>().path[4] = Coord[4];
				Enemy.GetComponent<Enemy>().path[5] = Coord[5];
				Enemy.GetComponent<Enemy>().path[6] = Coord[6];
				Enemy.GetComponent<Enemy>().path[7] = Coord[7];
				Enemy.GetComponent<Enemy>().path[8] = Coord[8];
				Enemy.GetComponent<Enemy>().path[9] = Coord[9];

            }


           







            if (Enemy.GetComponent<Enemy>().currentStep >= gridTileEnd.GetComponent<GridTile>().tileNumber)
            {
                Coord[1] = new Vector2(gridTileEnd.transform.position.x, gridTileEnd.transform.position.y);
				Enemy.GetComponent<Enemy>().path[1] = Coord[1];
            }


			
		

        }


    }


    void ShootEnemy()
    {
        
		gridWidth = 14;
		gridHeight = 14;

        for (int x = 2; x < gridWidth; x++)
        {
            for (int y = 2; y < gridWidth; y++)
            {

				// H&V Tower

                if (grid[x, y].GetComponent<GridTile>().towerVandH)
                {

                    if (grid[x + 1, y] != null)
                    {

                        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject Enemy in Enemies)
                        {
                            if (Enemy.transform.position == grid[x + 1, y].transform.position)
                            {
                                Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash,Splash.transform.position,Splash.transform.rotation);

                            }
                        }
                    }


                    if (grid[x - 1, y] != null)
                    {
                        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject Enemy in Enemies)
                        {
                            if (Enemy.transform.position == grid[x - 1, y].transform.position)
                            {
                                Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);

                            }
                        }

                    }


                    if (grid[x, y + 1] != null)
                    {
                        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject Enemy in Enemies)
                        {
                            if (Enemy.transform.position == grid[x, y + 1].transform.position)
                            {
                                Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x, y + 1].transform.position, Splash.transform.rotation);

                            }
                        }
                    }


                    if (grid[x, y - 1] != null)
                    {
                        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject Enemy in Enemies)
                        {
                            if (Enemy.transform.position == grid[x, y - 1].transform.position)
                            {
                                Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x, y - 1].transform.position, Splash.transform.rotation);

                            }
                        }
                    }

                }

				// D Tower

				if (grid[x, y].GetComponent<GridTile>().towerD)
				{
					
					if (grid[x - 1, y - 1] != null)
					{
						
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x - 1, y - 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x - 1, y + 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x - 1, y + 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
						
					}
					
					
					if (grid[x + 1, y + 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x + 1, y + 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x + 1, y - 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x + 1, y - 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
				}


				// Snipe Tower

				if (grid[x, y].GetComponent<GridTile>().towerSnipe)
				{
					
					if (grid[x + 1, y] != null)
					{
						
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x + 1, y].transform.position)
							{
								Enemy.GetComponent<Enemy>().Dead();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x - 1, y] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x - 1, y].transform.position)
							{
								Enemy.GetComponent<Enemy>().Dead();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
						
					}
					
					
					if (grid[x, y + 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x, y + 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Dead();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x, y - 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x, y - 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Dead();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}

					if (grid[x - 1, y - 1] != null)
					{
						
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x - 1, y - 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x - 1, y + 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x - 1, y + 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
						
					}
					
					
					if (grid[x + 1, y + 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x + 1, y + 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
					
					if (grid[x + 1, y - 1] != null)
					{
						Enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
						foreach (GameObject Enemy in Enemies)
						{
							if (Enemy.transform.position == grid[x + 1, y - 1].transform.position)
							{
								Enemy.GetComponent<Enemy>().Damage();
								Instantiate(Splash, grid[x - 1, y].transform.position, Splash.transform.rotation);
								
							}
						}
					}
					
				}




            }

        }
        
    }
    

}


