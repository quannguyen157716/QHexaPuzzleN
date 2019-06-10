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
	//int rotation;
	//int[,] status=new int[6,11];
	GameObject[,] hexa=new GameObject[6,11];
	BlockOverLapping2[,] hex=new BlockOverLapping2[6,11];

	void Start () 
	{
		ini_Pos=new Vector3(x,y);
		CreateBoard();
		//Destroy(hexa[0,2]);
		//Debug.Log(hex[0,2].fill);
	}
	
	void Update()
	{
		//if(Input.GetMouseButtonUp(0))
		//{
			CheckHexa();
		//}
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
				hex[i,b]=iblock.GetComponent<BlockOverLapping2>();
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
				hex[i+3,b]=iblock.GetComponent<BlockOverLapping2>();
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
				hex[i,c]=iblock.GetComponent<BlockOverLapping2>();
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
				hex[i+3,c]=iblock.GetComponent<BlockOverLapping2>();
				c+=2;
			}
			c=previousC;
			c++;
			num_block--;
			pos.y-=vertical_dis;
			pos.x=ini.x+horizontal_dis/2;
		}
	}
	//Check single double triple add score
	void CheckHexa()
	{
		Color c;
		int a=2;
		int previousA;
		int number_block=numberOfBlockFirstRow;
		for(int i=0; i<rows; i++)
		{
			previousA=a;
			for(int j=1;j<=number_block; j++)
			{
				if(hex[i,a].fill)
				{
					c=hex[i,a].boardColor.color;
					if(hex[i,a+1].boardColor.color ==c && hex[i,a+2].boardColor.color==c)
					{
						if(hex[i+1,a].boardColor.color==c && hex[i+1,a+1].boardColor.color==c && hex[i+1,a+2].boardColor.color==c)					
						{
							hex[i,a].Empty();
							hex[i,a+1].Empty();
							hex[i,a+2].Empty();
							hex[i+1,a].Empty();
							hex[i+1,a+1].Empty();
							hex[i+1,a+2].Empty();

							try
							{
								if(hex[i,a+3].fill && hex[i,a+3].boardColor.color== c)//check double hexa first case 
								{
									if(hex[i,a+4].boardColor.color==c)
									{
										if(hex[i+1,a+3].boardColor.color== c && hex[i+1,a+4].boardColor.color==c)
										{
											hex[i,a+3].Empty();
											hex[i,a+4].Empty();
											hex[i+1,a+3].Empty();
											hex[i+1,a+4].Empty();
										}
										//Check triple
										if(hex[i+2,a+1].fill && hex[i+2,a+1].boardColor.color==c)
										{
											if(hex[i+2,a+2].boardColor.color==c && hex[i+2,a+3].boardColor.color==c)
											{
												hex[i+2,a+1].Empty();
												hex[i+2,a+2].Empty();
												hex[i+2,a+3].Empty();
											}
										}
									}
								}
							}
							catch(System.NullReferenceException)
							{}
							catch(System.IndexOutOfRangeException)
							{}

							try //check double hexa second case 
							{
								if(hex[i+1,a+3].fill && hex[i+1,a+3].boardColor.color==c)
								{
									//double hexa right hand side
									if(hex[i+2,a+1].boardColor.color== c && hex[i+2,a+3].boardColor.color==c&&hex[i+2,a+2].boardColor.color==c)
									{
										hex[i+1,a+3].Empty();	
										hex[i+2,a+1].Empty();
										hex[i+2,a+2].Empty();
										hex[i+2,a+3].Empty();	
										//Check triple 
										if(hex[i+1,a-1].fill && hex[i+1,a-1].boardColor.color==c)	
										{
											if(hex[i+2,a-1].boardColor.color== c && hex[i+2,a].boardColor.color==c)
											{
												Debug.Log("Fuckkkkkk");
												hex[i+1,a-1].Empty();
												hex[i+2,a-1].Empty();
												hex[i+2,a].Empty();
											}
										}					
									}
								}
							}
							catch(System.IndexOutOfRangeException)
							{Debug.Log("Out of bound");}

							try
							{
									if(hex[i+1,a-1].fill && hex[i+1,a-1].boardColor.color==c)
									{
									//double hexa left hand side
									Debug.Log("LHexa");
									if(hex[i+2,a-1].boardColor.color== c && hex[i+2,a].boardColor.color==c&&hex[i+2,a+1].boardColor.color==c)
									{
										Debug.Log("Left hexa");
										hex[i+1,a-1].Empty();
										hex[i+2,a-1].Empty();
										hex[i+2,a].Empty();
										hex[i+2,a+1].Empty();
									}
								}
							}
							catch(System.IndexOutOfRangeException)
							{}
							catch(System.NullReferenceException)
							{}
						}
					}	
				}
				a+=2;
			}
			a=previousA;
			a--;
			number_block++;
		}
		
		a=1;
		number_block-=2;
		for(int i=3; i<rows+2; i++)
		{
			previousA=a;
			for(int j=1; j<=number_block; j++)
			{
				if(hex[i,a].fill) 
				{
					c=hex[i,a].boardColor.color;
					if(hex[i,a+1].boardColor.color ==c && hex[i,a+2].boardColor.color==c)
					{
						if(hex[i+1,a].boardColor.color== c && hex[i+1,a+1].boardColor.color ==c && hex[i+1,a+2].boardColor.color==c)
						{
							hex[i,a].Empty();
							hex[i,a+1].Empty();
							hex[i,a+2].Empty();
							hex[i+1,a].Empty();
							hex[i+1,a+1].Empty();
							hex[i+1,a+2].Empty();
							try //check double hexa
							{
								if(hex[i,a+3].fill)
								{
									if(hex[i,a+3].boardColor.color==c && hex[i,a+4].boardColor.color==c)
									{
										if(hex[i+1,a+3].boardColor.color== c && hex[i+1,a+4].boardColor.color==c)
										{
											hex[i,a+3].Empty();
											hex[i,a+4].Empty();
											hex[i+1,a+3].Empty();
											hex[i+1,a+4].Empty();
										}
										//Check triple
										if(hex[i+2,a+1].fill && hex[i+2,a+1].boardColor.color==c)
										{
											if(hex[i+2,a+2].boardColor.color==c && hex[i+2,a+3].boardColor.color==c)
											{
												hex[i+2,a+1].Empty();
												hex[i+2,a+2].Empty();
												hex[i+2,a+3].Empty();
											}
										}
									}
								}
							}
							catch(System.NullReferenceException)
							{Debug.Log("Out of bound");}
							catch(System.IndexOutOfRangeException)
							{}
							
							try //check double hexa second case 
							{
								if(hex[i+1,a+3].fill && hex[i+1,a+3].boardColor.color==c)
								{
									//double hexa right hand side
									if(hex[i+2,a+1].boardColor.color== c && hex[i+2,a+3].boardColor.color==c&&hex[i+2,a+2].boardColor.color==c)
									{
										hex[i+1,a+3].Empty();	
										hex[i+2,a+1].Empty();
										hex[i+2,a+2].Empty();
										hex[i+2,a+3].Empty();	
										//Check triple 
										if(hex[i+1,a-1].fill && hex[i+1,a-1].boardColor.color==c)	
										{
											if(hex[i+2,a-1].boardColor.color== c && hex[i+2,a].boardColor.color==c)
											{
												Debug.Log("Fuckkkkkk");
												hex[i+1,a-1].Empty();
												hex[i+2,a-1].Empty();
												hex[i+2,a].Empty();
											}
										}					
									}
								}
							}
							catch(System.NullReferenceException)
							{Debug.Log("Out of bound");}
							catch(System.IndexOutOfRangeException)
							{}

							try
							{
								if(hex[i+1,a-1].fill && hex[i+1,a-1].boardColor.color==c)
								{
									//double hexa left hand side
									Debug.Log("LHexa");
									if(hex[i+2,a-1].boardColor.color== c && hex[i+2,a].boardColor.color==c&&hex[i+2,a+1].boardColor.color==c)
									{
										Debug.Log("Left hexa");
										hex[i+1,a-1].Empty();
										hex[i+2,a-1].Empty();
										hex[i+2,a].Empty();
										hex[i+2,a+1].Empty();
									}
								}
							}
							catch(System.NullReferenceException)
							{}
							catch(System.IndexOutOfRangeException)
							{}
						}
					}	
				}
				a+=2;
			}
			a=previousA;
			a++;
			number_block--;
		}
	}
}



