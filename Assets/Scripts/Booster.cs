using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class Booster : MonoBehaviour {
	public float distanceTreshold = 5f;
	public bool enablePlume = false;
	public bool deployLegs = false;
	public Transform defaultParent;
	public GameObject[] legs;
	void Start () {
		defaultParent = transform.parent;
		foreach(GameObject g in legs){
			Debug.Log("Found leg " + g.name + " in " + name);
		}
	}
	void Update () {
		EnableParticles(enablePlume);
		if(deployLegs){

		}
	}
	public void EnableParticles(bool b){
		
	}
	public void AnimateLegs(bool b){

	}

	public void Detach(){

	}

}
