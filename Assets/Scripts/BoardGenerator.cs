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
	// Use this for initialization
	Vector3 ini_Pos;
	
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

        //Print the first half of board
		for(int i = 0; i < rows; i++)
   		{
			ini.x=pos.x;
			ini.y=pos.y;
     		for(int j = 1; j <= num_block; j++)
			{
			    pos.x+=horizontal_dis;
			    Instantiate(block, pos, Quaternion.Euler(0, 0, 60));
			}
			num_block++;
			pos.y+=vertical_dis;
			pos.x=ini.x-horizontal_dis/2;
   		}

		//Reverse
		pos.x+=horizontal_dis;
		num_block-=2;		
		for(int i =0 ;i < rows; i++)
		{
			ini.x=pos.x;
			ini.y=pos.y;
			
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				Instantiate(block, pos, Quaternion.Euler(0, 0, 60));
			}
			num_block--;
			pos.y+=vertical_dis;
			pos.x=ini.x+horizontal_dis/2;
		}
		
		//Print the rest of board
		pos.x=ini_Pos.x;
		pos.y=ini_Pos.y;
		num_block=numberOfBlockFirstRow-1;
		pos.x+=horizontal_dis/2;
		pos.y-=vertical_dis/3;
		for(int i =0 ;i < rows; i++)
		{
			ini.x=pos.x;
			ini.y=pos.y;
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				Instantiate(block, pos, Quaternion.identity);
			}
			num_block++;
			pos.y+=vertical_dis;
			pos.x=ini.x-horizontal_dis/2;
		}
		
		//Reverse
		for(int i =0 ;i < rows; i++)
		{
			ini.x=pos.x;
			ini.y=pos.y;
			for(int j= 1; j<= num_block; j++)
			{
				pos.x+=horizontal_dis;
				Instantiate(block, pos, Quaternion.identity);
			}
			num_block--;
			pos.y+=vertical_dis;
			pos.x=ini.x+horizontal_dis/2;
		}
	}
}
