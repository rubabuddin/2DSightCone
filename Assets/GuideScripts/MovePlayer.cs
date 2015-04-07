using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	float timer;
	public static Vector3 startPos;
	Vector3 endPos;
	
	void Start() 
	{
		RandomPosition();
	}
	
	void RandomPosition()
	{
		timer = Time.time;
		startPos = transform.position;
		//endPos = new Vector3(Random.Range(-12f, 12f), 1, Random.Range(8f, 14f));
		startPos.x++;
		if (startPos.x > 10) 
		{
						startPos.x = -10;
						startPos.z--;
		}


		endPos = new Vector3 (startPos.x, 1, startPos.z);

	}
	
	void Update()
	{
		if (Time.time - timer > 0.1)
		{
			RandomPosition();
		}
		transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);
	}}
