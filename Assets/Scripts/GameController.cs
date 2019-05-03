using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	Color m_color; //color to change the board
	bool rotating=true; //determine when a block can rotate
	bool drop=false;
	bool fit=false;
	public GameObject[] block =new GameObject[8];
	public GameObject[] respawnPoint =new GameObject[3];
	//Vector2 pos1;
	// Use this for initialization
	void Start () {
		//pos1=new Vector2(-0.03f,-3.2f);
		Instantiate(block[0], respawnPoint[0].transform.position, Quaternion.identity);
		Instantiate(block[1], respawnPoint[1].transform.position, Quaternion.identity);
		Instantiate(block[0], respawnPoint[2].transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*int layerMask=1 << 9;
		if (Input.GetMouseButton(0)) 
		 {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Debug.DrawRay(mousePos, Vector3.forward*10, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, layerMask);
            if (hit.collider != null) 
			{
                Debug.Log(hit.collider.gameObject.name);
				hit.collider.gameObject.transform.position=mousePos2D;
            }
        }*/
	}


	public Color M_color
	{
		get{return m_color;}
		set{m_color=value;}
	}

	public bool Rotating
	{
		get{return rotating;}
		set{rotating=value;}
	}

	public bool Drop
	{
		get{return drop;}
		set{drop=value;}
	}

	public bool Fit
	{
		get{return fit;}
		set{fit=value;}
	}
}
