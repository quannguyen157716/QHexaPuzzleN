using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    //public GameDriver gameDriver;
	float distance = 3;//distance from camera to object
    SpriteRenderer render;
    GameObject gameDriver;
	GameController gameDriverScript;

    void Start()
    {
        render=GetComponent<SpriteRenderer>();
        gameDriver=GameObject.FindGameObjectWithTag("GameDriver");	
		gameDriverScript=gameDriver.GetComponent<GameController>();
    }
    void Update()
	{
        
    }

    void OnMouseDrag()
	{
        Debug.Log("Drag");
        Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        transform.position = objPosition;
        gameDriverScript.M_color=render.color;
	}

    /* void OnMouseDown()
	{
		if(!enabled) 
		return;
		else
		transform.Rotate(0,0,60);
	}*/

}
