﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TargetFollower : MonoBehaviour {

	public Transform target;
	public float followSpeed;
    public float distance;
    public float xSpeed = 50.0f;
    public float ySpeed = 70.0f;
 
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
 
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    float x = 0.0f;
    float y = 0.0f;

	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}
	
	public void ChangeTarget(Transform t){
		target = t;
	}

	// Update is called once per frame
	void LateUpdate () {
		if(target){
            if(Input.GetMouseButton(2) && !EventSystem.current.IsPointerOverGameObject()){
                x += Input.GetAxis("Mouse X") * xSpeed;
                y -= Input.GetAxis("Mouse Y") * ySpeed;
            }
 
            y = ClampAngle(y, yMinLimit, yMaxLimit);
 
            Quaternion rotation = Quaternion.Euler(y, x, 0);
 
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*15, distanceMin, distanceMax);
 
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
 
            transform.rotation = rotation;
			transform.position = Vector3.MoveTowards(position, target.position, followSpeed);

		}
	}
	public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}