using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

    public GameObject result;
    public GameObject answer;
    public GameObject mathProblem;


    void Start () {
        NewProblem();
	}

    void NewProblem()
    {
        gameObject.SetActive(false);
    }

    public void NextLevel ()
    {
        Debug.Log("Check");
        mathProblem.GetComponent<MathProblemCreater>().NewProblem();
        result.GetComponent<Result>().NewProblem();
        answer.GetComponent<Answer>().NewProblem();
        NewProblem();

    }
}
