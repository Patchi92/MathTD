using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Subject : MonoBehaviour {

    Text result;
    public GameObject Problem;

	
	void Update () {

        result = gameObject.GetComponent<Text>();
        result.text = Problem.GetComponent<MathProblemCreater>().subject;
    }
}
