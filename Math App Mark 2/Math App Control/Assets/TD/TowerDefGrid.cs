using UnityEngine;
using System.Collections;

public class TowerDefGrid : MonoBehaviour
{

    public GameObject tile;
    int gridWidth;
    int gridHeight;

    GameObject[,] grid = new GameObject[13, 13];

    public bool firstRun;

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

    // Use this for initialization
    void Start()
    {
        CreateGrid();
        firstRun = true;

        GameObject gridTileStart = (GameObject)Instantiate(tile);
        gridTileStart.transform.position = new Vector2(gridTileStart.transform.position.x + 1, gridTileStart.transform.position.y + 3);
        gridTileStart.GetComponent<GridTile>().posX = 1;
        gridTileStart.GetComponent<GridTile>().posY = 3;
        grid[1, 3] = gridTileStart;

        GameObject gridTileEnd = (GameObject)Instantiate(tile);
        gridTileEnd.transform.position = new Vector2(gridTileEnd.transform.position.x + 12, gridTileEnd.transform.position.y + 10);
        gridTileEnd.GetComponent<GridTile>().posX = 12;
        gridTileEnd.GetComponent<GridTile>().posY = 10;
        grid[12, 10] = gridTileEnd;

        grid[1, 3].GetComponent<SpriteRenderer>().color = Color.red;
        grid[12, 10].GetComponent<SpriteRenderer>().color = Color.red;

        Build();
    }

    // Update is called once per frame
    void Update()
    {



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
        




        if (grid[x + 1, y] != null)
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
            }
        }

        if (grid[x - 1, y] != null)
        {
            if (grid[x - 1, y].GetComponent<SpriteRenderer>().color != Color.red && grid[x - 1, y].GetComponent<SpriteRenderer>().color != Color.green)
            {
                grid[x - 1, y].GetComponent<SpriteRenderer>().color = Color.blue;
                grid[x - 1, y].GetComponent<GridTile>().setup = true;
                towerPointXTwo = x - 1;
                towerPointYTwo = y;
                towerPointTwo = true;
                Debug.Log("Check1");
            }
        }
        else
        {
            towerPointTwo = false;
            Debug.Log("Check2");
        }




        if (grid[x, y + 1] != null)
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
            }
        }

        if (grid[x, y - 1] != null)
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
            }
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
}


