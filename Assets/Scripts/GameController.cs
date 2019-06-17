using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class GameController : MonoBehaviour {
	//public GameObject[] block =new GameObject[8];
	//public Color[] blockColor = new Color[8];
	public GameObject[] respawnPoint =new GameObject[3];
	public Block[] block=new Block[8];
	GameObject blockToSpawn;
	BlockController3 blockToSpawnScript;
	public BoardColor[] color=new BoardColor[8];
	Color colorToPaint;
	int totalWeight_B;
	int totalWeight_C;
	GameObject b;
	int[] item=new int[7];
	void Start () {
		for(int i=0; i< block.Length-1; i++)
		{
			totalWeight_B+=block[i].weight;
		}

		for(int i=0; i< color.Length-3; i++)
		{
			totalWeight_C+=color[i].weight;
		}

		for(int i=0; i<=10000;i++)
		{
			CraftBlock(totalWeight_B,totalWeight_C);
		}

		
		//SpawnBlock();
		/* b=Instantiate(block[0], respawnPoint[0].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[0].transform);
		b=Instantiate(block[1], respawnPoint[1].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[1].transform);
		b=Instantiate(block[5], respawnPoint[2].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[2].transform);
		*/
	}                                  
	
	// Update is called once per frame
	void Update () 
	{
		SpawnBlock();
		/* if(respawnPoint[0].transform.childCount==0)
		{
			b=Instantiate(block[0], respawnPoint[0].transform.position, Quaternion.identity);
			b.transform.SetParent(respawnPoint[0].transform);
		}

		if(respawnPoint[1].transform.childCount==0)
		{
			b=Instantiate(block[1], respawnPoint[1].transform.position, Quaternion.identity);
			b.transform.SetParent(respawnPoint[1].transform);
		}
		if(respawnPoint[2].transform.childCount==0)
		{
			b=Instantiate(block[5], respawnPoint[2].transform.position, Quaternion.identity);
			b.transform.SetParent(respawnPoint[2].transform);
		} */
	
	}

	void CraftBlock(int total_weight, int totalWeight_C)
	{
		int rand1=Random.Range(1,totalWeight_B+1);
		int rand2=Random.Range(1, totalWeight_C+1);
		for(int i=0; i< block.Length-1; i++)
		{
			rand1-=block[i].weight;
			if(rand1<=0)
			{
				item[i]++;
				blockToSpawn=block[i].block;
				break;
			}
		}

		for(int i=0; i< color.Length-3; i++)
		{
			rand2-=color[i].weight;
			if(rand2<=0)
			{
				colorToPaint=color[i].color;
				break;
			}
		}
	}

	void SpawnBlock()
	{
		for(int i=0; i<3 ;i++)
		{
			if (respawnPoint[i].transform.childCount==0)
			{
				CraftBlock(totalWeight_B, totalWeight_C);
				b=Instantiate(blockToSpawn, respawnPoint[i].transform.position, Quaternion.identity);
				blockToSpawnScript=b.GetComponent<BlockController3>();
				blockToSpawnScript.SetColor(colorToPaint);
				b.transform.SetParent(respawnPoint[i].transform);
			}
		}
		
	}


}
