﻿using UnityEngine;
using System.Collections;

public class Camer : MonoBehaviour {
	WebCamTexture back;
	// Use this for initialization
	void Start () {
		back = new WebCamTexture ();

		renderer.material.mainTexture = back;
		back.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
