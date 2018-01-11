using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class teleportmove : MonoBehaviour
{


	private Vector3 cameraposition;
	private Transform pvr_unitysdkposition;
	public ParabolicPointer parabolicPointer;
	// Use this for initialization
	void Start()
	{

		pvr_unitysdkposition = GameObject.Find("Pvr_UnitySDK").transform;
		cameraposition = pvr_unitysdkposition.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (parabolicPointer.PointOnNavMesh)
		{
			if (Controller.UPvr_GetKeyDown(Pvr_KeyCode.TOUCHPAD) || Input.GetMouseButtonDown(0))
			{
				pvr_unitysdkposition.position = parabolicPointer.SelectedPoint + Vector3.up;// + new Vector3(0, 0.67f, 0)
			}

		}
	}
}
