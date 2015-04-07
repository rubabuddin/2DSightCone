using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buildSensors : MonoBehaviour {

	public GameObject unit;
	public int stickLen;
	public Vector3 scale;
	private GameObject clone;
	private SmoothFollow smoo;


	// Use this for initialization
	void Start () {
		int i = 0;
		while (i < stickLen) {
			clone = (GameObject)Instantiate(unit, new Vector3(0,i * 1.0F, 0), Quaternion.Euler (0, 180,0));
			clone.transform.parent = this.transform;
			i++;
		}

		GameObject go = GameObject.Find("stickBuilder");
		testFrustumGeom other = go.GetComponent<testFrustumGeom>();
		other.initBounds();

		smoo = Camera.main.GetComponent<SmoothFollow>();
	}



	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			smoo.enabled = !smoo.enabled;
		}
	}
}
