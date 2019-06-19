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

	//
	
}
