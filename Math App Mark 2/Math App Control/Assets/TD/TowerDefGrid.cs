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
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;


    public GameObject tile;
    int gridWidth;
    int gridHeight;

    GameObject[,] grid = new GameObject[13, 13];


    public bool firstRun;

    public int tileNumber = 0;
    Vector2 Coord;

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


    bool roundBuild;
    int roundTime;
    bool reduceTime;

    bool waitingRound;
    int waitingTime;
    bool reduceWaitngTime;

    bool towerRound;
    int towerTime;
    bool reduceTowerTime;

    // Use this for initialization
    void Start()
    {
        CreateGrid();
        firstRun = true;
        roundBuild = false;
        waitingRound = false;
        buildTower = false;


        gridTileStart = (GameObject)Instantiate(tile);
        gridTileStart.transform.position = new Vector2(gridTileStart.transform.position.x + 1, gridTileStart.transform.position.y + 3);
        gridTileStart.GetComponent<GridTile>().posX = 1;
        gridTileStart.GetComponent<GridTile>().posY = 3;
        gridTileStart.transform.tag = "Start";
        gridTileStart.GetComponentInChildren<TextMesh>().text = tileNumber.ToString();
        grid[1, 3] = gridTileStart;

        gridTileEnd = (GameObject)Instantiate(tile);
        gridTileEnd.transform.position = new Vector2(gridTileEnd.transform.position.x + 12, gridTileEnd.transform.position.y + 10);
        gridTileEnd.GetComponent<GridTile>().posX = 12;
        gridTileEnd.GetComponent<GridTile>().posY = 10;
        gridTileEnd.transform.tag = "End";
        grid[12, 10] = gridTileEnd;

        grid[1, 3].GetComponent<SpriteRenderer>().color = Color.red;
        grid[12, 10].GetComponent<SpriteRenderer>().color = Color.red;

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


    }

    void Build()
    {

        Road(1, 3);
    }

    void CreateGrid()
    {
        gridWidth = 12;
        gridHeight = 12;

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


                if (grid[x + 1, y].GetComponent<SpriteRenderer>().color != Color.red && grid[x + 1, y].GetComponent<SpriteRenderer>().color != Color.green)
                {
                    grid[x + 1, y].GetComponent<SpriteRenderer>().color = Color.blue;
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

                if (grid[x - 1, y].GetComponent<SpriteRenderer>().color != Color.red && grid[x - 1, y].GetComponent<SpriteRenderer>().color != Color.green)
                {
                    grid[x - 1, y].GetComponent<SpriteRenderer>().color = Color.blue;
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


                if (grid[x, y + 1].GetComponent<SpriteRenderer>().color != Color.red && grid[x, y + 1].GetComponent<SpriteRenderer>().color != Color.green)
                {
                    grid[x, y + 1].GetComponent<SpriteRenderer>().color = Color.blue;
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


                if (grid[x, y - 1].GetComponent<SpriteRenderer>().color != Color.red && grid[x, y - 1].GetComponent<SpriteRenderer>().color != Color.green)
                {
                    grid[x, y - 1].GetComponent<SpriteRenderer>().color = Color.blue;
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
            if (grid[towerPointXOne, towerPointYOne].GetComponent<SpriteRenderer>().color != Color.red)
            {
                grid[towerPointXOne, towerPointYOne].GetComponent<SpriteRenderer>().color = Color.green;
                grid[towerPointXOne, towerPointYOne].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointTwo)
        {
            if (grid[towerPointXTwo, towerPointYTwo].GetComponent<SpriteRenderer>().color != Color.red)
            {
                grid[towerPointXTwo, towerPointYTwo].GetComponent<SpriteRenderer>().color = Color.green;
                grid[towerPointXTwo, towerPointYTwo].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointThree)
        {
            if (grid[towerPointXThree, towerPointYThree].GetComponent<SpriteRenderer>().color != Color.red)
            {
                grid[towerPointXThree, towerPointYThree].GetComponent<SpriteRenderer>().color = Color.green;
                grid[towerPointXThree, towerPointYThree].GetComponent<GridTile>().setup = false;
            }
        }

        if (towerPointFour)
        {
            if (grid[towerPointXFour, towerPointYFour].GetComponent<SpriteRenderer>().color != Color.red)
            {
                grid[towerPointXFour, towerPointYFour].GetComponent<SpriteRenderer>().color = Color.green;
                grid[towerPointXFour, towerPointYFour].GetComponent<GridTile>().setup = false;
            }
        }

    }


    public void Begin()
    {
        UI.GetComponent<UIControl>().EndMaze();
        UI.GetComponent<UIControl>().EndTimer();

        gridTileEnd.GetComponent<GridTile>().tileNumber = tileNumber + 1;

        gridWidth = 12;
        gridHeight = 12;

        for (int x = 2; x < gridWidth; x++)
        {
            for (int y = 2; y < gridWidth; y++)
            {
                if (grid[x, y].GetComponent<SpriteRenderer>().color == Color.blue)
                {
                    grid[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                }

                if (grid[x, y].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    grid[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
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
        roundTime = 4;
        roundBuild = true;
        towerRound = false;
        reduceTime = true;
        SpawnEnemy();

        buildTower = true;
    }

    void WaitRound()
    {
        Debug.Log("Wait Round");
        waitingTime = 3;
        waitingRound = true;
        roundBuild = false;
        reduceWaitngTime = true;
        MoveEnemy();
    }

    void TowerRound()
    {
        Debug.Log("Tower Round");
        towerTime = 2;
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
        random = Random.Range(1, 6);

        if (random == 1)
        {
            GameObject Enemy = (GameObject)Instantiate(enemy);
            Enemy.transform.position = new Vector2(grid[1, 3].transform.position.x, grid[1, 3].transform.position.y);
        }

        if (random == 2)
        {
            GameObject Enemy2 = (GameObject)Instantiate(enemy2);
            Enemy2.transform.position = new Vector2(grid[1, 3].transform.position.x, grid[1, 3].transform.position.y);
        }

        if (random == 3)
        {
            GameObject Enemy3 = (GameObject)Instantiate(enemy3);
            Enemy3.transform.position = new Vector2(grid[1, 3].transform.position.x, grid[1, 3].transform.position.y);
        }

        if (random == 4)
        {
            GameObject Enemy4 = (GameObject)Instantiate(enemy4);
            Enemy4.transform.position = new Vector2(grid[1, 3].transform.position.x, grid[1, 3].transform.position.y);
        }

      
    }

    void MoveEnemy()
    {


        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in Enemies)
        {

            if (Enemy.GetComponent<Enemy>().multi == 1)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 1)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 1;

            }


            if (Enemy.GetComponent<Enemy>().multi == 2)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 2)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 2;

            }


            if (Enemy.GetComponent<Enemy>().multi == 3)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 3)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 3;

            }


            if (Enemy.GetComponent<Enemy>().multi == 4)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 4)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 4;

            }


            if (Enemy.GetComponent<Enemy>().multi == 5)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 5)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 5;

            }


            if (Enemy.GetComponent<Enemy>().multi == 6)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 6)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 6;

            }


            if (Enemy.GetComponent<Enemy>().multi == 7)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 7)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 7;

            }


            if (Enemy.GetComponent<Enemy>().multi == 8)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 8)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 8;

            }


            if (Enemy.GetComponent<Enemy>().multi == 9)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 9)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 9;

            }


            if (Enemy.GetComponent<Enemy>().multi == 10)
            {

                gridWidth = 12;
                gridHeight = 12;

                for (int x = 2; x < gridWidth; x++)
                {
                    for (int y = 2; y < gridWidth; y++)
                    {
                        if (grid[x, y].GetComponent<GridTile>().tileNumber == Enemy.GetComponent<Enemy>().currentStep + 10)
                        {
                            Coord = new Vector2(grid[x, y].transform.position.x, grid[x, y].transform.position.y);
                        }

                    }

                }
                Enemy.GetComponent<Enemy>().currentStep = Enemy.GetComponent<Enemy>().currentStep + 10;

            }







            if (Enemy.GetComponent<Enemy>().currentStep >= gridTileEnd.GetComponent<GridTile>().tileNumber)
            {
                Coord = new Vector2(gridTileEnd.transform.position.x, gridTileEnd.transform.position.y);
            }

            Enemy.GetComponent<Enemy>().Move(Coord);
        }


    }


    void ShootEnemy()
    {
        
        gridWidth = 12;
        gridHeight = 12;

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
                                Enemy.GetComponent<Enemy>().Dead();

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

                            }
                        }
                    }

                }

            }

        }
        
    }
    

}


