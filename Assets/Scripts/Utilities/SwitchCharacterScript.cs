using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour {

	// referenses to controlled game objects
	public GameObject avatar1, avatar2;
	public Vector2 temp;

	// variable contains which avatar is on and active
	

	// Use this for initialization
	void Start () {

		// anable first avatar and disable another one
		avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
		temp = avatar1.transform.position;
	}
	
	void Update()
	{

		SwitchAvatar();
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		// switch (whichAvatarIsOn) {

		// if the first avatar is on
		// case 1:

			// then the second avatar is on now
			// whichAvatarIsOn = 2;
			if(Input.GetKey(KeyCode.Q))
			{
				avatar1.transform.position = avatar2.transform.position;
				avatar1.gameObject.SetActive (true);
				avatar2.gameObject.SetActive (false);
			}	
			else if (Input.GetKey(KeyCode.W))
			{
				avatar1.gameObject.SetActive (false);
				avatar2.transform.position = avatar1.transform.position;
				avatar2.gameObject.SetActive (true);	
			}
			// disable the first one and anable the second one
			

		// if the second avatar is on
	
	}

}
