using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour {

	public GameObject[] block =new GameObject[8];
	Vector3 pos1;
	// Use this for initialization
	void Start () {
		pos1=new Vector3(-0.03f,-3.2f);
		Instantiate(block[0],pos1,Quaternion.identity);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
