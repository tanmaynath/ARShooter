using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public Texture2D crossHairSprite;
    private float xPos, yPos;

	// Use this for initialization
	void Start () {
        xPos = (Screen.width / 2) - (crossHairSprite.width / 2);
        yPos = (Screen.height / 2) - (crossHairSprite.height / 2);
	}

    private void OnGUI()
    {
        GUI.DrawTexture((new Rect(xPos,yPos,crossHairSprite.width,crossHairSprite.height)), crossHairSprite);
    }


}
