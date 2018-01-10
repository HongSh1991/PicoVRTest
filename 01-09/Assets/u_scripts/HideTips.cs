using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTips : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("秒表").transform.position.y > 1.032)
		{
			gameObject.SetActive(false);
		}
	}
}
