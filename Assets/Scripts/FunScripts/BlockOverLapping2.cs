using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOverLapping2 : MonoBehaviour {

	Collider2D a,b,c;
	SpriteRenderer block;
	bool flip=false;
	PolygonCollider2D col;
	// Use this for initialization
	void Start () {
		if(transform.rotation.z==0)
		flip=true;
		Debug.Log(flip);
		block=GetComponent<SpriteRenderer>();
		col=GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Fit();
	}

	void Fit()
	{
		int layerMask = 1 << 9;
		
		//Collider2D hit=Physics2D.OverlapPoint(transform.position,layerMask);
		
			//Calculate 3 points of triangle
		a=Physics2D.OverlapPoint(col.points[0],layerMask);
		b=Physics2D.OverlapPoint(col.points[1],layerMask);
		c=Physics2D.OverlapPoint(col.points[2],layerMask);
		
		if(a && b && c)
		{
			SetColor(Color.green);
		}
		else
		{
			block.color=new Color(0f, 0f, 0f, 0.3f);
			SetColor(new Color(0f, 0f, 0f, 0.3f));
			//return false;
		}
	}

	public void SetColor(Color color)
	{
		block.color=color;
	}
}
