﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

		public GameObject targetObject;
		public Texture2D buttonTexture;
		public Texture2D playTexture;
		public Texture2D homeTexture;
		static public bool visible = false;
		static public bool dead = false;
		float originalWidth = 720f;  // define here the original resolution
		float originalHeight = 1280f; // you used to create the GUI contents 
		private Vector3 scale;
		float playerScore = 0;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float targetObjectX = targetObject.transform.position.x;
		
				Vector3 newCameraPosition = transform.position;
				newCameraPosition.x = targetObjectX + 2;
				transform.position = newCameraPosition;

				if (Application.platform == RuntimePlatform.Android) {
						if (Input.GetKeyDown (KeyCode.Escape)) {
								if (Time.timeScale == 1f) {
										Time.timeScale = 0f;
										visible = true;
								} else {
										Time.timeScale = 1f;
										visible = false;
								}
						}
				}
				playerScore += Time.deltaTime;
		}

		public void IncreaseScore (int amount)
		{
				playerScore += amount;
		}

		void OnGUI ()
		{
				scale.x = Screen.width / originalWidth; // calculate hor scale
				scale.y = Screen.height / originalHeight; // calculate vert scale
				scale.z = 1;
				var svMat = GUI.matrix; // save current matrix
				// substitute matrix - only scale is altered from standard
				GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);
				// draw your GUI controls here:

				GUIStyle myStyle = new GUIStyle (GUI.skin.box);
				myStyle.fontSize = 50;
				// Make a background box
				if (visible)
						GUI.Box (new Rect (originalWidth / 2 - playTexture.width / 2 - 130 - 60, originalHeight / 2 - playTexture.height / 2 - 60
			                 , originalWidth - (originalWidth / 2 - playTexture.width / 2 - 130) * 2 + 120, playTexture.height + 120), "Pause", myStyle);
				if (GUI.Button 
		    (new Rect 
		 (originalWidth - buttonTexture.width - 2, 0, buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) {
						Time.timeScale = 0f;
						visible = true;
				}
				if (visible || dead) {
						if (GUI.Button 
			                          (new Rect (originalWidth / 2 - playTexture.width / 2 - 130, originalHeight / 2 - playTexture.height / 2   
			                              , playTexture.width, playTexture.height), playTexture, GUIStyle.none)) {
								Time.timeScale = 1f;
								visible = false;
								if (dead) {
										dead = false;
										Application.LoadLevel (1);
										return;
								}    
						}
						if (GUI.Button 
			    (new Rect (originalWidth / 2 - homeTexture.width / 2 + 130, originalHeight / 2 - homeTexture.height / 2   
			           , homeTexture.width, homeTexture.height), homeTexture, GUIStyle.none)) {
								Time.timeScale = 1f;
								visible = false;
								dead = false;
								Application.LoadLevel (0);
								return;
						}
				}
				GUIStyle myStyle2 = new GUIStyle ();
				myStyle2.fontSize = 70;
				myStyle2.normal.textColor = Color.black;
				GUI.Label (new Rect (10, 10, 0, 0), "" + (int)playerScore, myStyle2); 
				if (dead) {
						GUI.Box (new Rect (originalWidth / 2 - playTexture.width / 2 - 130 - 60, originalHeight / 2 - playTexture.height / 2 - 60
			                   , originalWidth - (originalWidth / 2 - playTexture.width / 2 - 130) * 2 + 120, playTexture.height + 120), ""
								+ (int)playerScore, myStyle);
			            
						Time.timeScale = 0f;
				}
		

				GUI.matrix = svMat; // restore matrix
		}	
}