﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class Booster : MonoBehaviour {
	public float distanceTreshold = 5f;
	public bool isAttached = true;
	public bool enablePlume = false;
	public bool deployLegs = false;
	public Transform defaultParent;
	public SpeedManager speedM;
	public Vector3 nearestPointOnCurve;
	public BezierWalkerWithSpeed bzWalker;
	public GameObject[] legs;
	void Awake () {
		defaultParent = transform.parent;
		if(bzWalker == null){
			bzWalker = GetComponent<BezierSolution.BezierWalkerWithSpeed>();
		}
		foreach(GameObject g in legs){
			Debug.Log("Found leg " + g.name + " in " + name);
		}
	}
	void Update () {
		EnableParticles(enablePlume);
		EnableComponents();
		if(isAttached){
			nearestPointOnCurve = bzWalker.spline.FindNearestPointTo(transform.position, 100f);
		}

		if(deployLegs){

		}
	}

	public void EnableComponents(){
		if(isAttached){
			if(bzWalker.enabled == true || speedM.enabled == true){
				bzWalker.enabled = false;
				speedM.enabled = false;
			}
		}else{
			if(speedM.enabled == false){
				speedM.enabled = true;
			}
			if(bzWalker.enabled == false){
				if(Vector3.Distance(transform.position, nearestPointOnCurve)< distanceTreshold){
					bzWalker.enabled = true;
				}else{
					transform.position = Vector3.MoveTowards(transform.position, nearestPointOnCurve, bzWalker.speed / 50f);
				}
			}
		}
	}

	public void EnableParticles(bool b){
		
	}
	public void AnimateLegs(bool b){

	}

	public void Detach(){
		bzWalker.speed = transform.parent.GetComponent<BezierWalkerWithSpeed>().speed;
		foreach(Collider c in GetComponentsInChildren<Collider>()){
			c.enabled = true;
		}
		transform.parent = null;
		isAttached = false;
	}
	public void Detach(float speed){
		bzWalker.speed = speed;
		foreach(Collider c in GetComponentsInChildren<Collider>()){
			c.enabled = true;
		}
		transform.parent = null;
		isAttached = false;
	}

}
