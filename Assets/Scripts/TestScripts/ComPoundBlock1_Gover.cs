using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComPoundBlock1_Gover : MonoBehaviour {

	public GameObject board;
	public bool CP1_Fit(BlockOverLapping2[,] map, int i, int j)
	{
		if(!map[i,j].fill)
		return true;
		else
		return false;
	}

	
}
