using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	public int i;
	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		if(transform.rotation.z ==0)
		{
			Debug.Log("dfdfdfdf");
			i=1;
		}
		else
		{
			i=2;
		}
	}
	
	void Update()
	{
		Debug.Log(i);
	}
	// Update is called once per frame
}
