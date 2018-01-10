using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpDown : MonoBehaviour {

	public float radian = 0;//弧度
	public float perChangeRadian = 0.03f;//每次变化的弧度
	public float radius = 0.8f;//半径
	private Vector3 originPos;//开始时的坐标

	// Use this for initialization
	void Start () {
		originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		radian += perChangeRadian;
		float dy = Mathf.Cos(radian) * radius;//每次上下变换的幅度
		transform.position = originPos + new Vector3(0, dy, 0);
	}
}
