using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    //public GameDriver gameDriver;
	float distance = 1;//distance from camera to object
    SpriteRenderer render;
    GameObject gameDriver;
	GameController gameDriverScript;
    Vector3 origin;
    public GameObject board_triangle;
    SpriteRenderer boardRender;
    void Start()
    {
        render=GetComponent<SpriteRenderer>();
        gameDriver=GameObject.FindGameObjectWithTag("GameDriver");	
		gameDriverScript=gameDriver.GetComponent<GameController>();
        origin=transform.position;
        //boardRender=board_triangle.GetComponent<SpriteRenderer>();
    }
    void Update()
	{       
        int layerMask = 1 << 8;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0,layerMask);
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.green);
        if(hit.collider!=null)
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.red);
        if(Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null) 
		    {
                gameDriverScript.M_color=render.color;
                Debug.Log(hit.collider.gameObject.name);
                //transform.localScale=hit.collider.gameObject.transform.localScale;
                if(hit.collider.gameObject.transform.rotation.z==transform.rotation.z)
                {
                    
                    //Destroy(this.gameObject);
                }
                else
                transform.position=origin;
		    }
            else
            transform.position=origin;
            //else
            //transform.position=origin;
        }
       
    }

    void OnMouseDrag()
	{
        //Debug.Log("Drag");
        Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        transform.position = objPosition;

        /* int layerMask = 1 << 8;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0,layerMask);
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.green);
        if(Input.GetMouseButtonUp(0))
        {

            if (hit.collider != null) 
		    {
                Debug.Log(hit.collider.gameObject.name);
                transform.localScale=hit.collider.gameObject.transform.localScale;
                
                //Destroy(hit.collider.gameObject);
		    }
            //else
            //transform.position=origin;
        }*/
	}
}
