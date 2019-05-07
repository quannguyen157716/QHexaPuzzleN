using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	float distance = 1;//distance from camera to object
    SpriteRenderer render;
    GameObject gameDriver;
	GameController gameDriverScript;
    Vector3 origin;
    SpriteRenderer boardRender;
    public bool movable=true;
    void Start()
    {
        render=GetComponent<SpriteRenderer>();
        origin=transform.position;
    }
    void Update()
	{       
        /* int layerMask = 1 << 8;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0,layerMask);
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.green);
        if(hit.collider!=null)
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.red);
        if(Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null) 
		    {
                Debug.Log(hit.collider.gameObject.name);
                boardRender=hit.collider.gameObject.GetComponent<SpriteRenderer>();
                boardRender.color=render.color;   
                Destroy(gameObject);
		    }
        }*/
    }

    void OnMouseDrag()
	{
        //Debug.Log("Drag");
        if(movable)
        {
            Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
            transform.position = objPosition;
        }
       
	}

   /*  void OnMouseDown()
	{
		if(!enabled) 
		return;
		else
		transform.Rotate(0,0,60, Space.Self);
	}*/
}
