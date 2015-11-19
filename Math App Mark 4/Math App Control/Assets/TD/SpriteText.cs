using UnityEngine;
using System.Collections;

public class SpriteText : MonoBehaviour {

    public string SortingLayerName = "Default";
    public int SortingOrder = 0;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
