using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOverLapping2 : MonoBehaviour {

	Collider2D a;
	SpriteRenderer block;

	// Use this for initialization
	void Start () {
		block=GetComponent<SpriteRenderer>();
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
		a=Physics2D.OverlapPoint(transform.position,layerMask);
		
		
		if(a)
		{
			if(transform.rotation.z==0)
			{
				Debug.Log("T");
				Debug.Log(a.gameObject.transform.localEulerAngles.z);
				if(a.gameObject.transform.localEulerAngles.z ==120 | a.gameObject.transform.localEulerAngles.z ==0
				| a.gameObject.transform.localEulerAngles.z ==240)
				SetColor(Color.green);
			}
			/*/else
			{
				Debug.Log("RT");
				if(a.gameObject.transform.rotation.z==60 || a.gameObject.transform.rotation.z==180 || a.gameObject.transform.rotation.z==-60)
				SetColor(Color.green);
			}*/
			
			
			//block.color=Color.green;	
			//return true;
		}
		else
		{
			//block.color=new Color(0f, 0f, 0f, 0.3f);
			SetColor(new Color(0f, 0f, 0f, 0.3f));
			//return false;
		}
	}

	public void SetColor(Color color)
	{
		block.color=color;
	}
}
