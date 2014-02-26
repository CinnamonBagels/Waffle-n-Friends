using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(10, 10, 0);
	}
}
