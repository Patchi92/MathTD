using UnityEngine;
using System.Collections;

public class GridTile : MonoBehaviour
{

    GameObject Control;

    public bool setup = false;
    public int posX;
    public int posY;
    bool road;

    // Use this for initialization
    void Start()
    {
        

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
            Debug.Log(posX + " " + posY);
            Road();
            setup = false;
        }


    }

    void Road()
    {
        Control = GameObject.FindGameObjectWithTag("Grid");
        Control.GetComponent<TowerDefGrid>().Road(posX, posY);
    }
}
