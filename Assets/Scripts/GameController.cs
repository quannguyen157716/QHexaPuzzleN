using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	Color m_color; //color to change the board
	public GameObject[] block =new GameObject[8];
	public GameObject[] respawnPoint =new GameObject[3];
	GameObject b;
	//Vector2 pos1;
	// Use this for initialization
	void Start () {
		//pos1=new Vector2(-0.03f,-3.2f);
		b=Instantiate(block[0], respawnPoint[0].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[0].transform);
		b=Instantiate(block[1], respawnPoint[1].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[1].transform);
		b=Instantiate(block[2], respawnPoint[2].transform.position, Quaternion.identity);
		b.transform.SetParent(respawnPoint[2].transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(respawnPoint[0].transform.childCount==0)
		{
			b=Instantiate(block[0], respawnPoint[0].transform.position, Quaternion.identity);
			b.transform.SetParent(respawnPoint[0].transform);
		}
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



}
