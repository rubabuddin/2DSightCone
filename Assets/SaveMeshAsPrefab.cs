using UnityEngine;
using UnityEditor;
using System.Collections;

// assetSaver v1.0 - attach this script to any object, assign the target transfrom (from where the mesh is saved), give some filename. Play. Then press F to save.

public class SaveMeshAsPrefab : MonoBehaviour
{
	
	public string name1;
	public Transform obj1;
	
	void Update ()
	{
		if (Input.GetKeyDown("f"))
		{
			SaveAsset();
		}
	}
	
	void SaveAsset()
	{
		AssetDatabase.CreateFolder("Assets", "Prefab Folder");
		MeshFilter[] m1 = obj1.GetComponentsInChildren<MeshFilter>();
		int i = 0;
		foreach (MeshFilter mx in m1) {
			GameObject x = new GameObject("Empty");
			x.AddComponent("MeshFilter");
			x.AddComponent("MeshRenderer");
			x.GetComponent<MeshFilter>().mesh = mx.mesh;
						AssetDatabase.CreateAsset (x, "Assets/Prefab Folder/" + name1+ "_"+i + ".asset"); // saves to "assets/"
			i++;
				}
			//AssetDatabase.SaveAssets(); // not needed?
	}
	
}