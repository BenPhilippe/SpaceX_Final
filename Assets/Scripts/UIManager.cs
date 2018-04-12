using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameManager GM;

	public Image pauseImage, playImage;
	public Text timeText;

	void Start()
	{
		ChangePauseButtonTexture(GM.isPlayMode);
	}

	void Update()
	{
		timeText.text = FormatTime(GM.timeValue);
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

	public void PauseButton(){
		GM.EnablePlayMode(!GM.isPlayMode);
		ChangePauseButtonTexture(GM.isPlayMode);
	}
	public void ChangePauseButtonTexture(bool b){
		playImage.gameObject.SetActive(!b);
		pauseImage.gameObject.SetActive(b);
	}
	public void QuitButton(){
		GM.QuitGame();
	}
}
