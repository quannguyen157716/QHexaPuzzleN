﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController3 : MonoBehaviour {
	Scoring ScoreDriver;
	BoardGenerator boardGr;
	float distance = 1;//distance from camera to object
    //SpriteRenderer render;
	SpriteRenderer blocklColor;
	BlockOverLapping2 boScript;
    //GameObject gameDriver;                                                                                                                 
	//GameController gameDriverScript;
    Vector3 origin;
	int num_Child;
	GameObject board;
	float angle;
 void Start()
    {
        origin=transform.position;
		num_Child=transform.childCount;
		blocklColor=GetComponent<SpriteRenderer>();
		board=GameObject.FindGameObjectWithTag("Board");
		ScoreDriver=board.GetComponent<Scoring>();
		boardGr=board.GetComponent<BoardGenerator>();
    }
    /* void Update()
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
			} 
			
}*/
    void OnMouseDrag()
	{
        Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        transform.position = objPosition;  
	}

	void OnMouseUp()//Drop
	{
		int layerMask = 1 << 8;
        //Debug.Log("The fuk");
		Collider2D hit;
		BlockOverLapping2[] bs= new BlockOverLapping2[6];
		//Check if block fits board
		try
		{
			for(int i=0; i<num_Child; i++)
			{
				hit = Physics2D.OverlapPoint(transform.GetChild(i).transform.position, layerMask);
				if(!hit)
				{
					//Debug.Log("N hit");
					ResetToOrigin();
					return;
				}
				else
				{
					boScript=hit.gameObject.GetComponent<BlockOverLapping2>();
					if(CheckRotation(hit.transform)!=CheckRotation(transform.GetChild(i).transform) || boScript.fill)
					{
						ResetToOrigin();
						//Debug.Log("s");//
						return;
					}
					else
					bs[i]=boScript;
				}
			}
			
			for(int i=0; i<num_Child; i++)
			{
				bs[i].SetColor(blocklColor.color);
				bs[i].fill=true;
				ScoreDriver.ScorePoint();
				//add score here 
				if(i==num_Child-1)
				{
					Destroy(gameObject);
					boardGr.CheckHexa();
				}
			}
		}
		catch
		{
			//Destroy(gameObject);
			return;
		}
		   
		/* if(gameObject.tag=="CompoundBlock")
        {
            if(gameObject.transform.childCount==0)
            Destroy(gameObject);
        }*/
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
		angle=go.rotation.eulerAngles.z;
		//return 2 if reversed triangle, 1 if regular triangle, 0 not identified
		if((angle>=59 && angle<=61) ||
			(angle>=179 && angle<=181) ||
			(angle>=299 && angle<=301))
		{
			return 2;
		}
		else if((angle>=119 && angle<=121) ||
				(angle>=239 && angle<=241) ||
				(angle>=-1 && angle<=1))
		{
			return 1;
		}
		else
			return 0;
	}

	public void SetColor(Color color)
	{
		for(int i=0; i<transform.childCount;i++)
		{
			blocklColor=transform.GetChild(i).GetComponent<SpriteRenderer>();
			blocklColor.color=color;
		}
		blocklColor=gameObject.GetComponent<SpriteRenderer>();
		blocklColor.color=color;
	}
}

