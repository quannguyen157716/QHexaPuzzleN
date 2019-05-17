using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOverLapping2 : MonoBehaviour {

	public float horizontal_dis;
	public float vertical_dis;
	public Color boardColor;
	bool fill=false;
	SpriteRenderer blockRender;
	SpriteRenderer block;
	int status;
	Collider2D[] point=new Collider2D[3];
	//Collider2D hit;
	// Use this for initialization
	void Start () {
		if(transform.rotation.z ==0)
		status=1;
		block=GetComponent<SpriteRenderer>();
		boardColor=block.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(!fill)
		{
			Fit();
		}
	}

	bool Drop()
	{
		
		if(Input.GetMouseButtonUp(0))
		return true;	
		else
		return false;
	}
	void Fit()
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
					(hit.gameObject.transform.rotation.eulerAngles.z>=-1 && hit.gameObject.transform.rotation.eulerAngles.z<=1)
					)
					SetColor(Color.green);
				}
			}	
		}
		else
		{
			SetColor(new Color(0f, 0f, 0f, 0.3f));
		}
	}
	
	void Fit2()
	{
		int layerMask = 1 << 9;
		
	    //Collider2D hit=Physics2D.OverlapPoint(transform.position,layerMask);

		if(transform.rotation.z==0)
		{
			//Calculate 3 points of triangle
			point[0]=Physics2D.OverlapPoint(new Vector2(transform.position.x+horizontal_dis/2,transform.position.y-vertical_dis/3),layerMask);//r
		    point[1]=Physics2D.OverlapPoint(new Vector2(transform.position.x-horizontal_dis/2,transform.position.y-vertical_dis/3),layerMask);//l
		    point[2]=Physics2D.OverlapPoint(new Vector2(transform.position.x,transform.position.y+(vertical_dis/3)*2),layerMask);
		}
		else
		{
			//Reverse triangle, calculate 3 points
			point[0]=Physics2D.OverlapPoint(new Vector2(transform.position.x+horizontal_dis/2,transform.position.y+vertical_dis/3),layerMask);
			point[1]=Physics2D.OverlapPoint(new Vector2(transform.position.x-horizontal_dis/2,transform.position.y+vertical_dis/3),layerMask);
			point[2]=Physics2D.OverlapPoint(new Vector2(transform.position.x,transform.position.y-(vertical_dis/3)*2),layerMask);
		}

		foreach (Collider2D hit in point)
		{
			if(hit)
			{
				if(transform.rotation.z!=0)
				{
					if((hit.gameObject.transform.rotation.eulerAngles.z>=59 && hit.gameObject.transform.rotation.eulerAngles.z<=61) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=179 && hit.gameObject.transform.rotation.eulerAngles.z<=181) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=299 && hit.gameObject.transform.rotation.eulerAngles.z<=301))
					SetColor(Color.green);
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
				}	
				else
				{
					if((hit.gameObject.transform.rotation.eulerAngles.z>=119 && hit.gameObject.transform.rotation.eulerAngles.z<=121) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=239 && hit.gameObject.transform.rotation.eulerAngles.z<=241) ||
					(hit.gameObject.transform.rotation.eulerAngles.z>=-1 && hit.gameObject.transform.rotation.eulerAngles.z<=1)
					)
					SetColor(Color.green);
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
				}
			}
			else
			SetColor(new Color(0f, 0f, 0f, 0.3f));
			return;
		}

		/* if(hit)
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
					(hit.gameObject.transform.rotation.eulerAngles.z>=-1 && hit.gameObject.transform.rotation.eulerAngles.z<=1)
					)
					SetColor(Color.green);
				}
			}	
		}
		else
		{
			SetColor(new Color(0f, 0f, 0f, 0.3f));
		}*/
	}
	/* void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Enter");
		if(!fill)
		{
			if(Drop())
			{
				//Debug.Log("Drop");
				//blockRender=hit.gameObject.GetComponent<SpriteRenderer>();
				blockRender=col.gameObject.GetComponent<SpriteRenderer>();
				SetColor(blockRender.color);
				fill=true;
				Destroy(col.gameObject);
				//Debug.Log(a.gameObject.name);
			}
			else
			{
				if(transform.rotation.z!=0)
				{
					if((col.gameObject.transform.rotation.eulerAngles.z>=59 && col.gameObject.transform.rotation.eulerAngles.z<=61) ||
					(col.gameObject.transform.rotation.eulerAngles.z>=179 && col.gameObject.transform.rotation.eulerAngles.z<=181) ||
					(col.gameObject.transform.rotation.eulerAngles.z>=299 && col.gameObject.transform.rotation.eulerAngles.z<=301))
					SetColor(Color.green);
				}	
				else
				{
					if((col.gameObject.transform.rotation.eulerAngles.z>=119 && col.gameObject.transform.rotation.eulerAngles.z<=121) ||
					(col.gameObject.transform.rotation.eulerAngles.z>=239 && col.gameObject.transform.rotation.eulerAngles.z<=241) ||
					(col.gameObject.transform.rotation.eulerAngles.z>=-1 && col.gameObject.transform.rotation.eulerAngles.z<=1)
					)
					SetColor(Color.green);
				}
			}	
		}
		else
		SetColor(new Color(0f, 0f, 0f, 0.3f));
	}*/

	public void SetColor(Color color)
	{
		block.color=color;
	}
}
