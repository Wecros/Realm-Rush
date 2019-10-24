﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Waypoint> path;
	[SerializeField] float dwellTime;

	// Use this for initialization
	void Start () {
		StartCoroutine(FollowPath());
		print("Hey I'm back at Start");
	}

	IEnumerator FollowPath()
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in path)
		{
			print("Visiting: " + waypoint.name);
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
		}
		print("Ending patrol...");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
