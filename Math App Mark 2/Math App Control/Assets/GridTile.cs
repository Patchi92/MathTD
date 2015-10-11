using UnityEngine;
using System.Collections;

public class GridTile : MonoBehaviour
{

    GameObject Control;

    public bool setup = false;
    public int posX;
    public int posY;
    public int tileNumber;
    bool road;
    public bool tower;

    // Use this for initialization
    void Start()
    {
        Control = GameObject.FindGameObjectWithTag("Grid");
        tower = false;

    }

    // Update is called once per frame
    void Update()
    {
        


    }


    void OnMouseDown()
    {
        if (setup == true)
        {
            
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Control.GetComponent<TowerDefGrid>().tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
            gameObject.GetComponentInChildren<TextMesh>().text = Control.GetComponent<TowerDefGrid>().tileNumber.ToString();
            tileNumber = Control.GetComponent<TowerDefGrid>().tileNumber + 1;
            Debug.Log(posX + " " + posY);
            Road();
            setup = false;
        }


        if(Control.GetComponent<TowerDefGrid>().buildTower)
        {
            if(gameObject.GetComponent<SpriteRenderer>().color == Color.green)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                tower = true;
                Control.GetComponent<TowerDefGrid>().buildTower = false;

            }

        }


    }

    void Road()
    {
        Control.GetComponent<TowerDefGrid>().Road(posX, posY);
    }
}
