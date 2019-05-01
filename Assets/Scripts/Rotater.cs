using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    void Update()
	{}
	void OnMouseDown()
	{
		if(!enabled) 
		return;
		else
		transform.Rotate(0,0,60);
	}
}
