using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity );
		if(hit.collider !=null)
		{
			Debug.Log("Hit");
		}
		else	
			Debug.Log("NOt Hit");
	}
}
