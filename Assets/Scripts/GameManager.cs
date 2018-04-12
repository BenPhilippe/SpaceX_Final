using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isPlayMode;
	public bool isRewinding;
	public float timeValue, minTimeValue, maxTimeValue, timeMultiplier;
	public FalconHeavy falcon;
	public string currentPhase = "";

	void Start()
	{
		#if !UNITY_EDITOR && UNITY_WEBGL
		WebGLInput.captureAllKeyboardInput = false;
		#endif
		timeValue = minTimeValue;
	}
	void Update()
	{
		if(isPlayMode){
			timeValue += Time.deltaTime * timeMultiplier;
			if(timeValue>0){
				currentPhase = "Decollage";
				falcon.PauseWalkers(false);
				if(falcon.bzWalker.NormalizedT > 0.5f){
					currentPhase = ">0.5f";
				}
			}else{
				currentPhase = "Wait";
			}
		}else{
			falcon.PauseWalkers(true);
		}
		
	}

	public void EnablePlayMode(bool b){
		isPlayMode = b;
	}

	public void ChangeTimeSpeed(float value){
		float f = Snap(value);
		if(timeMultiplier + f <= 5 && timeMultiplier + f >= -2){
			timeMultiplier += f;
		}
	}
	public float Snap(float f){
		return (float)Mathf.Round(f * 2) / 2;
	}
	public void QuitGame(){
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
    UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
	}
}
