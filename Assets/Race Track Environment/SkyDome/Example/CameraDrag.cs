using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
		
	}

	private Vector3 lastMousePosition;
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3 .Distance(transform.position, target.position);
		distance = Mathf.Clamp (distance+Input.mouseScrollDelta.y/10,1,5);
		Vector3 angle = transform.eulerAngles;
		if (Input.GetMouseButtonDown (0)) {
		}else if(Input.GetMouseButton(0)){
			Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
			angle.y += mouseDelta.x;
			angle.x -= mouseDelta.y;
			angle.x = Mathf.Clamp (angle.x,0,80);
		}
		transform.eulerAngles = angle;
		transform.position = target.position - transform.forward * distance;
		lastMousePosition = Input.mousePosition;
	}
}
