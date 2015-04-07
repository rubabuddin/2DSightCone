using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class testFrustumGeom : MonoBehaviour {

	public Camera cam;
	private Plane[] planes;
	public Material lit;
	public Material dark;
	private List<Transform> objects = new List<Transform> ();
	public GameObject stick;

	void Start() {
		/*
		planes = GeometryUtility.CalculateFrustumPlanes(cam);
		int i = 0;
		while (i < planes.Length) {
			GameObject p = GameObject.CreatePrimitive(PrimitiveType.Plane);
			p.name = "Plane " + i.ToString();
			p.transform.position = -planes[i].normal * planes[i].distance;
			p.transform.rotation = Quaternion.FromToRotation(Vector3.up, planes[i].normal);
			i++;
		}
*/


	}

	public void initBounds() {
		stick = GameObject.Find ("stickBuilder");
		//this has to execute after the stick is built.
		FindLeaves (stick.transform, objects);
		
		InvokeRepeating ("calcFrustum", 0, .3f);
	}

	void calcFrustum() {
		Debug.Log ("calculating Frustum");
		planes = GeometryUtility.CalculateFrustumPlanes(cam);
	}

	void FindLeaves(Transform item, List<Transform> leafArray)
	{
		if (item.childCount == 0)
		{
			leafArray.Add(item);
		}
		else
		{
			foreach (Transform child in item)
			{
				FindLeaves(child, leafArray);
			}
		}
	}
	
	



	void Update() {
		foreach (Transform obT in objects) {
			GameObject ob = obT.gameObject;
			Debug.Log(ob.name);
			if (ob.name == "stickBuilder") {return;}
			if (GeometryUtility.TestPlanesAABB(planes, ob.collider.bounds)){

				ob.renderer.material = lit;
				ob.GetComponent<TimedTrailRenderer>().emit = true;

				//ob.GetComponent<TrailRenderer>().enabled = true;
				Debug.Log(ob.name + " has been detected!");
			} else {
				//ob.GetComponent<TrailRenderer>().startWidth = 0.0f;
				//ob.GetComponent<TrailRenderer>().endWidth = 0.0f;
				//ob.GetComponent<TrailRenderer>().enabled = false;
				ob.GetComponent<TimedTrailRenderer>().emit = false;
				ob.renderer.material = dark;
				Debug.Log("Nothing has been detected");
			}
		}
	}
}
