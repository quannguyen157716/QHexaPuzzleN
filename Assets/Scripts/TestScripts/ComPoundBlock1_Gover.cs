using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComPoundBlock1_Gover : MonoBehaviour {

	public GameObject board;
	BoardGenerator boardGeScript;

	void Start()
    {
       boardGeScript=board.GetComponent<BoardGenerator>();
    }

	public bool EmptyCP1()
	{
		bool gv=false;
		int pi=0,pj=0;//position in array
		for(int i=pi; i<6;i++)
		{
			for(int j=pj; j<11;j++)
			{
				if(boardGeScript.hex[i,j]!=null && !boardGeScript.hex[i,j].fill)
				{
					gv=true;
					pi=i;
					pj=j;
					return gv;
				}
				else if(boardGeScript.hex[i,j]!=null && boardGeScript.hex[i,j].fill)
				gv=false;
			}
		}

		return gv;
	} 
}
