﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	private bool isRotatable;
	private int RotateRandomizer;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
///		isRotatable = (this.tag == "Rotatable");

///		RotateRandomizer = Random.Range(0,500);
		
		if (isBreakable)
		{
			breakableCount++;
			print(breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	
	}

	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		print("Collision detected");
		
		if(isBreakable)
		{
			HandleHits();
		}
		
	}
	
	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length +1;
		
		if(timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BrickDestroyed();
			print(breakableCount);
			Destroy(gameObject);
		}
		
		else 
		{
			LoadSprites();
		}
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			
		}

	}


	void SimulateWin(){
	levelManager.LoadNextLevel();
	
	}
	
	
	
	
}


