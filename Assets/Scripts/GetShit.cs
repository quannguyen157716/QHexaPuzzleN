using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShit : MonoBehaviour {
	public GameObject block;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		pos =new Vector3(-2.3f,-1);
		  Instantiate(block, pos, Quaternion.Euler(0, 0, 60));
		  Instantiate(block, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
