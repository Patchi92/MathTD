using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MathProblemCreater : MonoBehaviour {

    Text MathProblem;
    int problem;
    public int answer;
    public string subject;
  

	// Use this for initialization
	void Start () {
        NewProblem();
	}
	
	// Update is called once per frame
	void Update () {

      


    }

    public void NewProblem()
    {
        problem = Random.Range(1, 4);

        if (problem == 1)
        {
            RandomPlus();
            subject = "Plus";
        }
        else if (problem == 2)
        {
            RandomMinus();
            subject = "Minus";
        }
        else if (problem == 3)
        {
            RandomMulti();
            subject = "Gange";
        }
        else
        {
            Debug.Log("Error");
        }
    }

    void RandomPlus()
    {
        int x;
        int y;

        x = Random.Range(1, 10);
        y = Random.Range(1, 10);


        MathProblem = gameObject.GetComponent<Text>();
        MathProblem.text = x + " + " + y;

        answer = x + y;
        

    }

    void RandomMinus()
    {
        int x;
        int y;

        x = Random.Range(1, 10);
        y = Random.Range(1, 10);

        if(y > x)
        {
            x = Random.Range(1, 10);
            y = Random.Range(1, 10);
            return;
        }

        MathProblem = gameObject.GetComponent<Text>();
        MathProblem.text = x + " - " + y;

        answer = x - y;
    }

    void RandomMulti()
    {
        int x;
        int y;

        x = Random.Range(1, 4);
        y = Random.Range(1, 4);


        MathProblem = gameObject.GetComponent<Text>();
        MathProblem.text = x + " * " + y;

        answer = x * y;
    }
}
