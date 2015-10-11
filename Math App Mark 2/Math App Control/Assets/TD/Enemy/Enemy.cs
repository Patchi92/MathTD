using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int multi;
    public int currentStep;
    float speed = 2f;

    Vector2 pos;
    GameObject escape;

	// Use this for initialization
	void Start () {

        escape = GameObject.FindGameObjectWithTag("End");

        pos = transform.position;
        currentStep = 1;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);


        if (transform.position == escape.transform.position)
        {
            Escape();
        }

      

    }

    public void Move(Vector2 Coord)
    {
        pos = Coord;
    }

    public void Escape()
    {
            Destroy(gameObject);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
