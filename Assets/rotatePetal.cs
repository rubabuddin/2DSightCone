using UnityEngine;
using System.Collections;


public class rotatePetal : MonoBehaviour {

	public float speed1 = 1.0f;
	private int i;
	private float p;
	//public Color lerpedColor = Color.white;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
		void Update () {
		if (i % (Random.value* 20) == 0) {
			p = Random.value;
				}
		//transform.Rotate(Vector3.left * Time.deltaTime * speed1);
		//transform.Rotate(new Vector3(Random.value, 0,Random.value*0.5f) * Time.deltaTime * speed1);
		//transform.Translate(new Vector3(Random.value, 0,Random.value*0.5f) * Time.deltaTime);
		transform.Rotate(new Vector3(p, Random.value, p) * Time.deltaTime * speed1);
		transform.Translate(new Vector3(Random.value, 0, p) * Time.deltaTime);
		i++;
	}
}
