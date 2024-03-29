﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOverLapping2 : MonoBehaviour {
	//GameObject board;
	//BoardGenerator boardScript;
	public float horizontal_dis;
	public float vertical_dis;
	SpriteRenderer blockRender;
	
	[HideInInspector]
	public SpriteRenderer boardColor;
	[HideInInspector]
	public bool fill=false;

	int layerMask;// = 1 << 9;
	float angle;
	Collider2D hit;//=Physics2D.OverlapPoint(transform.position,layerMask);

	// Use this for initialization
	void Awake()
	{
		boardColor=GetComponent<SpriteRenderer>();
		layerMask = 1 << 9;
	
		//board=GameObject.FindGameObjectWithTag("Board");
		//boardScript=board.GetComponent<BoardGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!fill)
		{
			Fit2();
		}
	}

	bool Drop()
	{
		
		if(Input.GetMouseButtonUp(0))
		return true;	
		else
		return false;
	}
	/*/void Fit()
	{
		int layerMask = 1 << 9;
		


	    Collider2D hit=Physics2D.OverlapPoint(transform.position,layerMask);
		
		if(hit)
		{
			Debug.Log(hit.gameObject.transform.eulerAngles.z);
			if(Drop())
			{
				//Debug.Log("Drop");
				blockRender=hit.gameObject.GetComponent<SpriteRenderer>();
				SetColor(blockRender.color);
				Debug.Log(blockRender.color);
				fill=true;
				Destroy(hit.gameObject);
				//Debug.Log(a.gameObject.name);
			}
			else
			{
				if(transform.rotation.z!=0)
				{
					if((hit.gameObject.transform.rotation.eulerAngles.z>=59 && hit.gameObject.transform.rotation.eulerAngles.z<=61) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=179 && hit.gameObject.transform.rotation.eulerAngles.z<=181) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=299 && hit.gameObject.transform.rotation.eulerAngles.z<=301))
					SetColor(Color.green);
				}	
				else
				{
					if((hit.gameObject.transform.rotation.eulerAngles.z>=119 && hit.gameObject.transform.rotation.eulerAngles.z<=121) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=239 && hit.gameObject.transform.rotation.eulerAngles.z<=241) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=-1 && hit.gameObject.transform.rotation.eulerAngles.z<=1))
					SetColor(Color.green);
				}
			}	
		}
		else
		{
			SetColor(new Color(0f, 0f, 0f, 0.3f));
		}
	} */
	
	void Fit2()
	{
		//int layerMask = 1 << 9;
		
	    hit=Physics2D.OverlapPoint(transform.position,layerMask);
		
		if(hit)
		{
			angle=hit.gameObject.transform.rotation.eulerAngles.z;
			//Debug.Log(angle);
			if(transform.rotation.z!=0)
				{
					//Debug.Log("r0");
					if((angle>=59 && angle<=61) ||
					(angle>=179 && angle<=181) ||
					(angle>=299 && angle<=301))
					{
						SetColor(Color.green);
						/* if(Drop())
						{
							//Debug.Log("r0ColorChange");
							blockRender=hit.gameObject.GetComponent<SpriteRenderer>();
							//SetColor(blockRender.color);
							//Debug.Log(blockRender.color);
							//fill=true;
							//Destroy(hit.gameObject);
						}*/
					}
				}	
			else
				{
					//Debug.Log("r1");
					if((angle>=119 && angle<=121) ||
					(angle>=239 && angle<=241) ||
					(angle>=-1 && angle<=1))
					{
						SetColor(Color.green);
						/* if(Drop())
						{
							//Debug.Log("r1ColorChange");
							blockRender=hit.gameObject.GetComponent<SpriteRenderer>();
							//SetColor(blockRender.color);
							//Debug.Log(blockRender.color);
							//fill=true;
							//Destroy(hit.gameObject);
							//Debug.Log(a.gameObject.name);
						}*/
					}					
				}
		}
		else
		{
			SetColor(new Color(0f, 0f, 0f, 0.3f));
		}

	}

	public void SetColor(Color color)
	{
		boardColor.color=color;
	}

	public void Empty()
	{
		boardColor.color=new Color(0f, 0f, 0f, 0.3f);
		fill=false;
	}
}
