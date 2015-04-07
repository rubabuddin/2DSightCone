using UnityEngine;
using System.Collections;

public class SightConeMod : MonoBehaviour {

	public static Vector3 coneLength = MovePlayer.startPos;
	float zSca = 0f;
	float xSca = 0f;
	// Use this for initialization
	void Start () {
		zSca = (Mathf.Abs (coneLength.z))/2f;
		transform.localScale.Set (coneLength.x, coneLength.y, zSca);
	}
	
	// Update is called once per frame
	void Update () {
		coneLength = MovePlayer.startPos;
		zSca = (Mathf.Abs (coneLength.z))/2f;
		xSca = Mathf.Abs (coneLength.x);
		print (zSca);
		transform.localScale = new Vector3 (1f, coneLength.y, zSca);
	}

	void OnGUI() {
		// Make a background box
		GUI.Box(new Rect(20,20,300,70), "Data");
		
		GUI.Label(new Rect(20,35,300,50), "Length of Cone of Vision: " + zSca + " m");
		GUI.Label(new Rect(20,55,300,50), "Sweeping Lightbulb " + xSca + " m from Observer");
	}
}
