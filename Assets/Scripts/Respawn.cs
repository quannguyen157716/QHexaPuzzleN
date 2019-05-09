using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	GameObject block;
	// Use this for initialization
	
	// Update is called once per frame

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Trigger");
	}
}
