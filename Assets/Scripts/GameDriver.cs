using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour {

	public GameObject block;
	Vector3 pos1;
	// Use this for initialization
	void Start () {
		pos1=new Vector3(-0.01f,-2.5f);
		Instantiate(block,pos1,Quaternion.identity);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
