using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  TriangleGenerator: MonoBehaviour {

	Mesh mesh;
	Vector3[] verticles;
	int[] triangles;
	// Use this for initialization
	void Start () {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		CreateShape();
		UpdateMesh();
	}
	
	void CreateShape()
	{
		verticles =new Vector3[]
		{
			new Vector3 (0,0,0),//0
			new Vector3 (1,0,2),//1
			new Vector3(2,0,0),//2
			new Vector3(2,0,3)//3
		};

		triangles =new int[]
		{
			0, 1, 2, 2, 3, 1
		};
	}

	void UpdateMesh()
	{
		mesh.Clear();
		mesh.vertices=verticles;
		mesh.triangles=triangles;
	}
}
