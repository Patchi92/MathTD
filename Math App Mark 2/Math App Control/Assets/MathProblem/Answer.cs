using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Answer : MonoBehaviour {

    public GameObject Problem;
    public GameObject Result;

    string guess;
    Text endGuess;

    void Start()
    {
        NewProblem();
    }



    void Update () {
        endGuess = gameObject.GetComponent<Text>();
        endGuess.text = guess;
    }


   public void NewProblem()
    {
        guess = "";
    }


    public void SendGuess()
    {
        if(guess == Problem.GetComponent<MathProblemCreater>().answer.ToString())
        {
            Result.GetComponent<Result>().ShowResultCorrect();
            PlayerPrefs.SetInt("Rank", PlayerPrefs.GetInt("Rank") + 10);
            PlayerPrefs.SetInt("High Score", PlayerPrefs.GetInt("High Score") + 10);
            PlayerPrefs.SetInt("Current Combo", PlayerPrefs.GetInt("Current Combo") + 1);

            if(PlayerPrefs.GetInt("Current Combo") > PlayerPrefs.GetInt("Best Combo"))
            {
                PlayerPrefs.SetInt("Best Combo", PlayerPrefs.GetInt("Current Combo"));
            }

        } else
        {
            Result.GetComponent<Result>().ShowResultWrong();
            PlayerPrefs.SetInt("Current Combo", 0);
            PlayerPrefs.SetInt("Rank", PlayerPrefs.GetInt("Rank") - 10);

            if (PlayerPrefs.GetInt("Rank") < 0)
            {
                PlayerPrefs.SetInt("Rank", 0);
            }
        }
    }


    public void RemoveGuess()
    {
        guess = "";
    }

    public void Zero()
    {
        guess = guess + "0";
    }

    public void One()
    {
        guess = guess + "1";
    }

    public void Two()
    {
        guess = guess + "2";
    }

    public void Three()
    {
        guess = guess + "3";
    }

    public void Four()
    {
        guess = guess + "4";
    }

    public void Five()
    {
        guess = guess + "5";
    }

    public void Six()
    {
        guess = guess + "6";
    }

    public void Seven()
    {
        guess = guess + "7";
    }

    public void Eight()
    {
        guess = guess + "8";
    }

    public void Nine()
    {
        guess = guess + "9";
    }
}
