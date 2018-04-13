using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public GameManager GM;

	public GameObject startImage;
	public Image pauseImage, playImage;
	public Text timeText, altitudeText, timeMultiplierText;
	public Transform cameraTarget;

	Color imageTargetColor = Color.white;
	Color transparent = new Color(0f, 0f, 0f, 0f);
	bool clickedOnStartImage = false;

	void Start()
	{
		ChangePauseButtonTexture(GM.isPlayMode);
		startImage.GetComponent<Image>().color = Color.black;
	}

	void Update()
	{
		timeText.text = FormatTime(GM.timeValue);
		timeMultiplierText.text = (int)GM.timeMultiplier + "x";
		altitudeText.text = GM.falcon.bzWalker.speed.ToString("F2");//= (Camera.main.transform.position.y - GM.transform.position.y).ToString("F1") + " m";
		if(!clickedOnStartImage){
			ChangeImageColor(startImage.GetComponent<Image>(), imageTargetColor);
		}else{
			ChangeImageColor(startImage.GetComponent<Image>(), transparent);
		}

	}

	public string FormatTime(float t){
		int sec = (int)(Mathf.Abs(t) % 60);
		int min = (int)(Mathf.Abs(t) / 60) % 60;
		int ct = (int)(Mathf.Abs(t) * 100) % 100;
		string s = "";
		if(t<0){
			s = "- ";
		}
		s += string.Format("{0:00}:{1:00}:{2:00}", min, sec, ct);
		return s;
	}
	public void ChangeCurrentTarget(Transform t){
		cameraTarget.GetComponent<TargetFollower>().ChangeTarget(t);
	}
	public void PauseButton(){
		GM.EnablePlayMode(!GM.isPlayMode);
		ChangePauseButtonTexture(GM.isPlayMode);
	}
	public void ChangePauseButtonTexture(bool b){
		playImage.gameObject.SetActive(!b);
		pauseImage.gameObject.SetActive(b);
	}
	public void EnableStartImage(bool b){
		startImage.SetActive(b);
		clickedOnStartImage = true;
	}
	public void ChangeTimeSpeedButton(int i){
		GM.ChangeTimeSpeed(i);
	}
	public void ChangeImageColor(Image i, Color c){
		i.color = Color.LerpUnclamped(i.color, c, 0.1f);
	}
	public void LoadMainLevel(){
		SceneManager.LoadScene(1);
	}
	public void QuitButton(){
		GM.QuitGame();
	}
}
