using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour {
	public GameObject block;
	public float x;
	public float y;
	public float horizontal_dis;
	public float vertical_dis;
	public int rows;
	public int numberOfBlockFirstRow;
	Vector3 ini_Pos;
	GameObject iblock;
	int rotation;
	//int[,] status=new int[6,11];
	GameObject[,] hexa=new GameObject[6,11];
	void Start () 
	{
		ini_Pos=new Vector3(x,y);
		CreateBoard();
	}
	
	void CreateBoard()//Attempt #1
	{
		Vector3 pos=new Vector3(); //position to instantiate
		pos.x=ini_Pos.x; //set position to initial point
		pos.y=ini_Pos.y;
		Vector3 ini=new Vector3(); // hold position of first block of a row
		int num_block=numberOfBlockFirstRow;
		int b=3;
        //Print the first half of board
		for(int i = 0; i < rows; i++)
   		{
			int previousB=b;
			ini.x=pos.x;
			ini.y=pos.y;
     		for(int j = 1; j <= num_block; j++)
			{
			    pos.x+=horizontal_dis;
			    iblock=Instantiate(block, pos, Quaternion.Euler(0, 0, 60));
				iblock.transform.SetParent(transform);
				hexa[i,b]=iblock;
				b+=2;
			}
			b=previousB;
			b--;
			num_block++;
			pos.y-=vertical_dis;
			pos.x=ini.x-horizontal_dis/2;
   		}

		b=0;
		for(int i =0 ;i < rows; i++)
		{
			int previousB=b;
			ini.x=pos.x;
			ini.y=pos.y;	
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				iblock=Instantiate(block, pos, Quaternion.Euler(0, 0, 60));
				iblock.transform.SetParent(transform);
				hexa[i+3,b]=iblock;
				b+=2;
			}
			b=previousB;
			b++;
			num_block--;
			pos.y-=vertical_dis;
			pos.x=ini.x+horizontal_dis/2;
		}
		
		//Print the rest of board
		pos.x=ini_Pos.x;
		pos.y=ini_Pos.y;
		num_block=numberOfBlockFirstRow+1;
		pos.x-=horizontal_dis/2;
		pos.y-=vertical_dis/3;
		int c=2;
		for(int i =0 ;i < rows; i++)
		{
			int previousC=c;
			ini.x=pos.x;
			ini.y=pos.y;
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				iblock=Instantiate(block, pos, Quaternion.identity);
				iblock.transform.SetParent(transform);
				hexa[i,c]=iblock;
				c+=2;
			}
			c=previousC;
			c--;
			num_block++;
			pos.y-=vertical_dis;
			pos.x=ini.x-horizontal_dis/2;
		}
		
		//Reverse
		num_block-=2;
		pos.x+=horizontal_dis;
		c=1;
		for(int i =0 ;i < rows; i++)
		{
			int previousC=c;
			ini.x=pos.x;
			ini.y=pos.y;
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				iblock=Instantiate(block, pos, Quaternion.identity);
				iblock.transform.SetParent(transform);
				hexa[i+3,c]=iblock;
				c+=2;
			}
			c=previousC;
			c++;
			num_block--;
			pos.y-=vertical_dis;
			pos.x=ini.x+horizontal_dis/2;
		}
	}

}

