using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerDefGrid : MonoBehaviour
{
    public GameObject UI;

    public GameObject timer;

    GameObject gridTileStart;
    GameObject gridTileEnd;

    public GameObject[] Enemies;

    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;
	public GameObject enemy7;
	public GameObject enemy8;
	public GameObject enemy9;
	public GameObject enemy10;


	// Towers

	public Sprite GrassTile;
	public Sprite GrassTileGrid;
	public Sprite TowerTile;
	public Sprite TowerTileGrid;
	public Sprite RoadTile;




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

    bool towerPointOne = false;
    bool towerPointTwo = false;
    bool towerPointThree = false;
    bool towerPointFour = false;

    bool wayUp;
    bool wayDown;
    bool wayLeft;
    bool wayRight;

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

    // Use this for initialization
    void Start()
    {
        CreateGrid();
        firstRun = true;
        roundBuild = false;
        waitingRound = false;
        buildTower = false;
        life = 3;


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

        grid[1, 4].GetComponent<SpriteRenderer>().sprite = RoadTile;
        grid[14, 11].GetComponent<SpriteRenderer>().sprite = RoadTile;

		grid[14, 11].GetComponent<GridTile>().road = true;


        Build();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (roundBuild)
        {
            timer.GetComponent<Text>().text = "Tid: " + roundTime;

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
            timer.GetComponent<Text>().text = "Venter på creeps";

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
            timer.GetComponent<Text>().text = "SKYD!";

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


        if(life == 0)
        {
            Application.LoadLevel("MathTowerDefTest");
        }


    }

    void Build()
    {

        Road(1, 4);
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

        wayUp = true;
        wayDown = true;
        wayLeft = true;
        wayRight = true;



        if (grid[x + 1, y] != null)
        {

            if (grid[x + 1, y].tag != "End")
            {


				if (grid[x + 1, y].GetComponent<GridTile>().road == false && grid[x + 1, y].GetComponent<GridTile>().tower == false)
                {
                    grid[x + 1, y].GetComponent<SpriteRenderer>().sprite = RoadTile;
					grid[x + 1, y].GetComponent<GridTile>().canBuild = true;
                    grid[x + 1, y].GetComponent<GridTile>().setup = true;
                    towerPointXOne = x + 1;
                    towerPointYOne = y;
                    towerPointOne = true;
                }
                else
                {
                    towerPointOne = false;
                    wayRight = false;
                    Debug.Log("Right");
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
					grid[x - 1, y].GetComponent<SpriteRenderer>().sprite = RoadTile;
					grid[x - 1, y].GetComponent<GridTile>().canBuild = true;
                    grid[x - 1, y].GetComponent<GridTile>().setup = true;
                    towerPointXTwo = x - 1;
                    towerPointYTwo = y;
                    towerPointTwo = true;
                }
                else
                {
                    towerPointTwo = false;
                    wayLeft = false;
                    Debug.Log("Left");
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
					grid[x, y + 1].GetComponent<SpriteRenderer>().sprite = RoadTile;
					grid[x, y + 1].GetComponent<GridTile>().canBuild = true;
                    grid[x, y + 1].GetComponent<GridTile>().setup = true;
                    towerPointXThree = x;
                    towerPointYThree = y + 1;
                    towerPointThree = true;
                }
                else
                {
                    towerPointThree = false;
                    wayUp = false;
                    Debug.Log("Up");
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
					grid[x, y - 1].GetComponent<SpriteRenderer>().sprite = RoadTile;
					grid[x, y - 1].GetComponent<GridTile>().canBuild = true;
                    grid[x, y - 1].GetComponent<GridTile>().setup = true;
                    towerPointXFour = x;
                    towerPointYFour = y - 1;
                    towerPointFour = true;
                }
                else
                {
                    towerPointFour = false;
                    wayDown = false;
                    Debug.Log("Down");
                }
            }
            else
            {
                UI.GetComponent<UIControl>().EndMaze();
            }
        }








        if (!wayDown && !wayUp && !wayLeft && !wayRight)
        {
            Application.LoadLevel("MathTowerDefTest");
        }

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

    }


    public void Begin()
    {
        UI.GetComponent<UIControl>().EndMaze();
        UI.GetComponent<UIControl>().EndTimer();
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

				if (grid[x, y].GetComponent<SpriteRenderer>().sprite == TowerTileGrid)
                {
					grid[x, y].GetComponent<SpriteRenderer>().sprite = TowerTile;
                }

				if (grid[x, y].GetComponent<GridTile>().canBuild)
				{
					grid[x, y].GetComponent<SpriteRenderer>().sprite = TowerTile;
					grid[x, y].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
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
        roundTime = 20;
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
        random = Random.Range(1, 10);

        if (random == 1)
        {
            GameObject Enemy2 = (GameObject)Instantiate(enemy2);
            Enemy2.transform.position = startPos;
        }

        if (random == 2)
        {
            GameObject Enemy3 = (GameObject)Instantiate(enemy3);
			Enemy3.transform.position = startPos;
        }

        if (random == 3)
        {
            GameObject Enemy4 = (GameObject)Instantiate(enemy4);
			Enemy4.transform.position = startPos;
        }

        if (random == 4)
        {
            GameObject Enemy5 = (GameObject)Instantiate(enemy5);
			Enemy5.transform.position = startPos;
        }

		if (random == 5)
		{
			GameObject Enemy6 = (GameObject)Instantiate(enemy6);
			Enemy6.transform.position = startPos;
		}

		if (random == 6)
		{
			GameObject Enemy7 = (GameObject)Instantiate(enemy7);
			Enemy7.transform.position = startPos;
		}

		if (random == 7)
		{
			GameObject Enemy8 = (GameObject)Instantiate(enemy8);
			Enemy8.transform.position = startPos;
		}

		if (random == 8)
		{
			GameObject Enemy9 = (GameObject)Instantiate(enemy9);
			Enemy9.transform.position = startPos;
		}

		if (random == 9)
		{
			GameObject Enemy10 = (GameObject)Instantiate(enemy10);
			Enemy10.transform.position = startPos;
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


            if (Enemy.GetComponent<Enemy>().multi == 10)
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

						if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 10)
                        {
							Coord[10] = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 10;
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
				Enemy.GetComponent<Enemy>().path[10] = Coord[10];

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
                if (grid[x, y].GetComponent<GridTile>().tower)
                {

                    if (grid[x + 1, y] != null)
                    {

                        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject Enemy in Enemies)
                        {
                            if (Enemy.transform.position == grid[x + 1, y].transform.position)
                            {
                                Enemy.GetComponent<Enemy>().Damage();

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

                            }
                        }
                    }

                }

            }

        }
        
    }
    

}


