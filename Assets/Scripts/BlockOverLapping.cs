using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOverLapping : MonoBehaviour {
	SpriteRenderer block;
	public float horizontal_dis;
	public float vertical_dis;
	Collider2D a,b,c;
	bool fill=false;//
	GameObject gameDriver;
	GameController gameDriverScript;
	// Use this for initialization
	void Start () {
		block=GetComponent<SpriteRenderer>();
		gameDriver=GameObject.FindGameObjectWithTag("GameDriver");	
		gameDriverScript=gameDriver.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!fill)
		{
			if(Fit())
			{
				if(Drop())
				{
					//block.color=Color.blue;
					SetColor(gameDriverScript.M_color);
					fill=true;
				}
			}
		}		
		//Fit();
	}

	bool Drop()
	{
		if(Input.GetMouseButtonUp(0))
		return true;
		else
		return false;
	}

	bool Fit()
	{
		int layerMask = 1 << 8;
		layerMask = ~layerMask;
		//Collider2D hit=Physics2D.OverlapPoint(transform.position,layerMask);
		if(transform.rotation.z==0)
		{
			//Calculate 3 points of triangle
			c=Physics2D.OverlapPoint(new Vector2(transform.position.x+horizontal_dis/2,transform.position.y-vertical_dis/3),layerMask);
		    b=Physics2D.OverlapPoint(new Vector2(transform.position.x-horizontal_dis/2,transform.position.y-vertical_dis/3),layerMask);
		    a=Physics2D.OverlapPoint(new Vector2(transform.position.x,transform.position.y+(vertical_dis/3)*2),layerMask);
		}
		else
		{
			//Reverse triangle, calculate 3 points
			c=Physics2D.OverlapPoint(new Vector2(transform.position.x+horizontal_dis/2,transform.position.y+vertical_dis/3),layerMask);
			b=Physics2D.OverlapPoint(new Vector2(transform.position.x-horizontal_dis/2,transform.position.y+vertical_dis/3),layerMask);
			a=Physics2D.OverlapPoint(new Vector2(transform.position.x,transform.position.y-(vertical_dis/3)*2),layerMask);
		}
		
		if(a && b && c)
		{
			//block.color=Color.green;
			SetColor(Color.green);
			return true;
		}
		else
		{
			//block.color=new Color(0f, 0f, 0f, 0.3f);
			SetColor(new Color(0f, 0f, 0f, 0.3f));
			return false;
		}
	}

	public void SetColor(Color color)
	{
		block.color=color;
	}
}
