﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController2 : MonoBehaviour {

	float distance = 1;//distance from camera to object
    //SpriteRenderer render;
	SpriteRenderer blocklColor;
	BlockOverLapping2 boScript;
    //GameObject gameDriver;
	//GameController gameDriverScript;
    Vector3 origin;
	//int num_Child;

 void Start()
    {
        origin=transform.position;
		//num_Child=transform.childCount;
		blocklColor=GetComponent<SpriteRenderer>();
		//Debug.Log(num_Child);
    }
    void Update()
	{       	
        /* int layerMask = 1 << 8;
        //Debug.Log("The fuk");
		Collider2D hit;
		Collider2D hit2;
		
		try
		{
			hit = Physics2D.OverlapPoint(transform.GetChild(0).transform.position, layerMask);
			hit2 = Physics2D.OverlapPoint(transform.GetChild(1).transform.position, layerMask);
		}
		catch
		{
			Destroy(gameObject);
			return;
		}
		
        //Debug.DrawRay(transform.GetChild(0).transform.position, Vector3.forward*10, Color.green);
		//Debug.DrawRay(transform.GetChild(1).transform.position, Vector3.forward*10, Color.green);
        //if(hit.collider!=null)
        //Debug.DrawRay(transform.GetChild(0).transform.position, Vector3.forward*10, Color.red);
		//if(hit2.collider!=null)
		//Debug.DrawRay(transform.GetChild(1).transform.position, Vector3.forward*10, Color.red);
        if(Input.GetMouseButtonUp(0))
        {
            if (!hit || !hit2) 
		    {     
                ResetToOrigin();
				Debug.Log("Not hit");
		    }
            else 
            {
				/*render=hit.gameObject.GetComponent<SpriteRenderer>();
				if(render.color!=Color.green)
				ResetToOrigin();

				render=hit2.gameObject.GetComponent<SpriteRenderer>();
				if(render.color!=Color.green)
				ResetToOrigin();
				
				if(hit.transform!=hit2.transform && (CheckRotation(hit.transform)== CheckRotation(transform.GetChild(0).transform)))
				{
					Debug.Log("C");
					if(CheckRotation(hit2.transform)== CheckRotation(transform.GetChild(1).transform))
					{
						boScript=hit.gameObject.GetComponent<BlockOverLapping2>();
						boScript.SetColor(blocklColor.color);
						boScript.fill=true;
						boScript=hit2.gameObject.GetComponent<BlockOverLapping2>();
						boScript.SetColor(blocklColor.color);
						boScript.fill=true;
						Destroy(gameObject);
						Debug.Log("la");
					}
				}
				else
				{
					Debug.Log("Noo");
					ResetToOrigin();	
				}
				
            }
        }

		
			if(gameObject.tag=="CompoundBlock")
        	{
            	if(gameObject.transform.childCount==0)
            	Destroy(gameObject);
			} */
			
    }

    void OnMouseDrag()
	{
        Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        transform.position = objPosition;
      
	}

	void OnMouseUp()
	{
		int layerMask = 1 << 8;
        //Debug.Log("The fuk");
		Collider2D hit;
		Collider2D hit2;
		
		try
		{
			hit = Physics2D.OverlapPoint(transform.GetChild(0).transform.position, layerMask);
			hit2 = Physics2D.OverlapPoint(transform.GetChild(1).transform.position, layerMask);
		}
		catch
		{
			//Destroy(gameObject);
			return;
		}
		
       
        if (!hit || !hit2) 
		{     
            ResetToOrigin();
			Debug.Log("Not hit");
		}
        else 
        {
			if((CheckRotation(hit.transform)== CheckRotation(transform.GetChild(0).transform)))
			{
				Debug.Log("C");
				if(CheckRotation(hit2.transform)== CheckRotation(transform.GetChild(1).transform))
				{
					boScript=hit.gameObject.GetComponent<BlockOverLapping2>();
					boScript.SetColor(blocklColor.color);
					boScript.fill=true;
					boScript=hit2.gameObject.GetComponent<BlockOverLapping2>();
					boScript.SetColor(blocklColor.color);
					boScript.fill=true;
					Destroy(gameObject);
					Debug.Log("la");
				}
				else
				ResetToOrigin();
			}
			else
				{
					Debug.Log("Noo");
					ResetToOrigin();	
				}
				
            }
        
			if(gameObject.tag=="CompoundBlock")
        	{
            	if(gameObject.transform.childCount==0)
            	Destroy(gameObject);
        	}
	}

    public void ResetToOrigin()
    {
            transform.position=origin;
    }

    void OnMouseDown()
	{
		transform.Rotate(0,0,60, Space.World);   
	}

	int CheckRotation(Transform go)
	{
		//return 2 if reversed triangle, 1 if regular triangle, 0 not identified
		if((go.rotation.eulerAngles.z>=59 && go.rotation.eulerAngles.z<=61) ||
			(go.rotation.eulerAngles.z>=179 && go.rotation.eulerAngles.z<=181) ||
			(go.rotation.eulerAngles.z>=299 && go.rotation.eulerAngles.z<=301))
			{
				return 2;
			}
		else if((go.rotation.eulerAngles.z>=119 && go.rotation.eulerAngles.z<=121) ||
				(go.rotation.eulerAngles.z>=239 && go.rotation.eulerAngles.z<=241) ||
				(go.rotation.eulerAngles.z>=-1 && go.rotation.eulerAngles.z<=1))
			{
				return 1;
			}
		else
			return 0;
	}
}