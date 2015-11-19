using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result : MonoBehaviour {

    Text result;
    public GameObject Problem;
    public GameObject Next;


    void Start()
    {
        NewProblem();
    }

    public void NewProblem()
    {
        result = gameObject.GetComponent<Text>();
        result.text = "";
    }


    public void ShowResultCorrect()
    {
        result.text = "Correct";
        Next.SetActive(true);
    }

    public void ShowResultWrong()
    {
        result.text = "Wrong - The correct answer is: " + Problem.GetComponent<MathProblemCreater>().answer.ToString();
        Next.SetActive(true);
    }


}
