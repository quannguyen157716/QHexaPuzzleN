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

	// Use this for initialization
	void Start () {
		if(transform.rotation.z ==0)
		status=1;
		block=GetComponent<SpriteRenderer>();
		block.color=boardColor;
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
					hit.gameObject.transform.rotation.eulerAngles.z==0)
					SetColor(Color.green);
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
		block.color=color;
	}
}
