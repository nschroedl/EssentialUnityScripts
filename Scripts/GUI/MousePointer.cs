
//Uses a default resource and also only changes the cursor if it collides with the gameobject.
/*
 * http://www.unifycommunity.com/wiki/index.php?title=Custom_Mouse_Pointer
 * Authors: Kiyaku, ananasblau
 */
using UnityEngine;
using System.Collections;
 
public class MousePointer : MonoBehaviour 
{
    public Texture2D cursorImage;
 
    private int cursorWidth = 16;
    private int cursorHeight = 16;
    private bool showCursor = false;
   private string defaultResource = "MousePointer";
 
    void Start()
    {
		if(!cursorImage) {
			cursorImage = (Texture2D) Resources.Load(defaultResource);
			Debug.Log(cursorImage);
		}
		//cursorImage = (Texture2D) Instantiate(cursorImage);
    }
 
 
    void OnMouseEnter()
    {
		Debug.Log("Entered");
		Screen.showCursor = false;
		showCursor = true;
	}
	void OnGUI() {
		if(showCursor) {
        	GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
		}
    }
	void OnMouseExit()
	{
		Debug.Log("Left");
		showCursor = false;
		Screen.showCursor = true;
	}
}


//Usage:
//Attach this script to any gameObject you want, preferable a new empty one. Assign your custom Texture to the script.

using UnityEngine;
using System.Collections;
 
public class mousePointer : MonoBehaviour 
{
    public Texture2D cursorImage;
 
    private int cursorWidth = 32;
    private int cursorHeight = 32;
 
    void Start()
    {
        Screen.showCursor = false;
    }
 
 
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
    }
}