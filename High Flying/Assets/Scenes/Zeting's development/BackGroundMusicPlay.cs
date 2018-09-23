﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackGroundMusicPlay : MonoBehaviour {

	// Use this for initialization
	AudioSource audioSource;
	Scene currentScene;
	string nameOfStart="";
	[SerializeField] AudioClip CityNoise;
	[SerializeField] AudioClip Wind;
	public bool isPlaying ;
	AudioClip music;
		
	private void Awake()
    {
		checkDouble();
		isPlaying=false;
	}

	void Start(){
		setupPlayer();
	}


	public void setupPlayer()
	{
		this.currentScene= SceneManager.GetActiveScene();
		this.audioSource = GetComponent<AudioSource>();		
		this.SetClipForPlay();
		this.audioSource.loop=true;
		this.PlayMusic();
	}
	public void switchPlay()
	{
		
		if(this.isPlaying)
		{
			this.StopPlay();
		}
		else
		{
			this.PlayMusic();
		}
	}
	void Update()
	{
		this.CheckUpdate();	
		
	}

	
	private bool PlayMusic()
	{
		if(!this.isPlaying)
		{
			this.audioSource.Play();
			this.isPlaying=!this.isPlaying;
		}
		return isPlaying;
	}

	private void CheckUpdate()
	{ 

		this.currentScene= SceneManager.GetActiveScene();
		
		if(!currentScene.name.Equals(nameOfStart))//if this change happened
		{
			if((nameOfStart.Contains("Main")&&currentScene.name.Contains("City"))||currentScene.name.Contains("City")||currentScene.name.Contains("Main"))
			{	
				this.DoUpdateMusic();
			}
		}
	}

	private void DoUpdateMusic()
	{
		this.StopPlay();;
		this.SetClipForPlay();
		this.PlayMusic();
		nameOfStart=this.currentScene.name;
	}

	private void SetClipForPlay()
	{
		this.audioSource.clip=(this.currentScene.name.Contains("City"))?CityNoise:Wind;
	}
	

	private bool StopPlay()
	{
		if(this.isPlaying)
		{
			this.audioSource.Stop();
			this.isPlaying=!this.isPlaying;
		}
		return isPlaying;
	}

	private void checkDouble()
	{
		if(GameObject.FindObjectsOfType<BackGroundMusicPlay>().Length>1)
			{
				Destroy(gameObject);
			}
			else{
				DontDestroyOnLoad(this.gameObject);
			}
	}
}
