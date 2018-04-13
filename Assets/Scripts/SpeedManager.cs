using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class SpeedManager : MonoBehaviour {

	public int currentSpeedIndex = 1;
	public float acceleration = 0.8f;
	public List<SpeedTarget> speedTargets;
	public float[] speeds;
	public float speedToAttain;
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
		/*float dist = Vector3.Distance(transform.position, speedTargets[currentSpeedIndex].GetComponent<Transform>().position);
		foreach(SpeedTarget st in speedTargets){
			if(currentSpeedIndex + 1 < speedTargets.Count){
				float d2 = Vector3.Distance(transform.position, speedTargets[currentSpeedIndex+1].GetComponent<Transform>().position);
				if(d2 < dist){
					currentSpeedIndex++;
				}
			}
		}*/
		bzWalker.speed = speeds[0];
		speedToAttain = speeds[currentSpeedIndex];
	}
	
	// Update is called once per frame
	void Update () {
		SetSpeed();
	}

	public void SetSpeed(){

		if(GM.timeValue>0){
			speedToAttain = speeds[currentSpeedIndex];
			bzWalker.speed = Mathf.MoveTowards(bzWalker.speed,
					speedToAttain * GM.timeMultiplier,//nextSpeedTarget.speed,
					acceleration);

		}else{
			bzWalker.speed = speeds[0];
		}
	}

	void OnTriggerEnter(Collider c){
		SpeedTarget tmp = c.GetComponent<SpeedTarget>();
		if(tmp != null && GM.timeValue>0){
			Debug.Log("Changing speed target");
			if(bzWalker.isGoingForward){
				currentSpeedIndex+=1;
				if(currentSpeedIndex>speeds.Length-1){
					currentSpeedIndex-=1;
				}
			}else{
				currentSpeedIndex-=1;
				if(currentSpeedIndex<0){
					currentSpeedIndex+=1;
				}
			}
		}
	}
}
