using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;


public class logger: MonoBehaviour {

	public GameObject gm_Obj;
	public float countTime;
	private String filepathIncludingFileName;


void Start () {
		countTime = 0.0f;
	filepathIncludingFileName  = Application.persistentDataPath+"/logView.csv";

	StartCoroutine(WriteTracker(gm_Obj));
}



void Update () {
	
		countTime += Time.deltaTime;
}


IEnumerator WriteTracker (GameObject player) {
	
	while(true){
			StringBuilder sb = new StringBuilder();
		
		if (!System.IO.File.Exists(filepathIncludingFileName)){
				sb.AppendLine("Time Stamp,Pos(x),Pos(y),Pos(z),Rot(x),Rot(y),Rot(z),CountTime");
		}
		
		sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}", DateTime.Now, player.transform.position.x.ToString("F6"),player.transform.position.y.ToString("F6"), player.transform.position.z.ToString("F6"), player.transform.eulerAngles.x.ToString("F6"), player.transform.eulerAngles.y.ToString("F6"), player.transform.eulerAngles.z.ToString("F6"), countTime.ToString()  ).AppendLine();
		System.IO.File.AppendAllText(filepathIncludingFileName, sb.ToString());
			//Debug.Log("writen to:"+filepathIncludingFileName);
			yield return new WaitForSeconds(0.02f);
	}
}

}