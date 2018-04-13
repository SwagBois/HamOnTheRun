using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genral : MonoBehaviour {

	public GameObject Startpanel,AboutPanel,ButtonSound,PauseScreen;


	// Use this for initialization
	void Start () {
		Startpanel.SetActive(true);
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			PauseScreen.SetActive(true);
		}
		
	}
	public void StartButtonClick()
	{
		Time.timeScale = 1f;
		Startpanel.SetActive(false);
		ButtonSound.SetActive(true);
	}
	public void Back()
	{
		AboutPanel.SetActive(false);
		ButtonSound.SetActive(true);
	}
	public void About()
	{
		AboutPanel.SetActive(true);
		ButtonSound.SetActive(true);
	}
	public void Buttonclicksound()
	{
		ButtonSound.SetActive(false);
	}
}
