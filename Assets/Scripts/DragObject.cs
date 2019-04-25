using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

	float distance = 3;//distance from camera to object

    void OnMouseDrag()

	{

        Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

        transform.position = objPosition;

	}

}
