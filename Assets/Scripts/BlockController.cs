using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	float distance = 1;//distance from camera to object
    SpriteRenderer render;
    //GameObject gameDriver;
	//GameController gameDriverScript;
    Vector3 origin;
    public bool movable=true;
    void Start()
    {
        origin=transform.position;
    }
    void Update()
	{       
        int layerMask = 1 << 8;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0,layerMask);
        //Debug.DrawRay(transform.position, Vector3.forward*10, Color.green);
        //if(hit.collider!=null)
        //Debug.DrawRay(transform.position, Vector3.forward*10, Color.red);
        if(Input.GetMouseButtonUp(0))
        {
            if (hit.collider == null) 
		    {     
               ResetToOrigin();
		    }
            else 
            {
                      
                render=hit.collider.gameObject.GetComponent<SpriteRenderer>();
                if(render.color !=Color.green)
                ResetToOrigin();
            }
        }

        if(gameObject.tag=="CompoundBlock")
        {
            if(gameObject.transform.childCount==0)
            Destroy(gameObject);
        }
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

    public void ResetToOrigin()
        {
            transform.position=origin;
        }

    void OnMouseDown()
	{
		//if(transform.position==origin) 
		//return;
		//else
		transform.Rotate(0,0,60, Space.World);
	}
}
