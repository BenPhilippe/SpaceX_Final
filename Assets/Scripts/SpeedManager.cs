using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class SpeedManager : MonoBehaviour {

	public int currentSpeedIndex = 0;
	public float acceleration = 0.8f;
	public SpeedTarget[] speedTargets;
	public GameManager GM;
	public SpeedTarget lastSpeedTarget, nextSpeedTarget;
	public BezierWalkerWithSpeed bzWalker;

	// Use this for initialization
	void Awake () {
		GM = Object.FindObjectOfType<GameManager>();
		if(GM == null){
			Debug.Log("No GameManager found.");
		}
		bzWalker = GetComponent<BezierWalkerWithSpeed>();
		//Get nearest
		float dist = Vector3.Distance(transform.position, speedTargets[currentSpeedIndex].GetComponent<Transform>().position);
		foreach(SpeedTarget st in speedTargets){
			float d2 = Vector3.Distance(transform.position, speedTargets[currentSpeedIndex+1].GetComponent<Transform>().position);
			if(d2 < dist){
				currentSpeedIndex++;
			}
		}
		bzWalker.speed = speedTargets[currentSpeedIndex].speed;
	}
	
	// Update is called once per frame
	void Update () {
		SetSpeed();
	}

	public void SetSpeed(){
		if(currentSpeedIndex > 0){
				lastSpeedTarget = speedTargets[currentSpeedIndex - 1];
			}else{
				lastSpeedTarget = speedTargets[0];
			}
			if(currentSpeedIndex < speedTargets.Length - 1){
				nextSpeedTarget = speedTargets[currentSpeedIndex + 1];
			}else{
				nextSpeedTarget = speedTargets[speedTargets.Length - 1];
			}
			if(GM.timeValue>0){
				bzWalker.speed = Mathf.MoveTowards(bzWalker.speed,
					speedTargets[currentSpeedIndex].speed,
					acceleration);

			}else{
				bzWalker.speed = speedTargets[0].speed;
			}
	}

	void OnTriggerEnter(Collider c){
		if(c.GetComponent<SpeedTarget>() != null){
			if(bzWalker.isGoingForward){
				currentSpeedIndex ++;
				if(currentSpeedIndex>speedTargets.Length-1)
					currentSpeedIndex --;
			}else{
				currentSpeedIndex --;
				if(currentSpeedIndex<0)
					currentSpeedIndex ++;
			}
		}
	}
}
