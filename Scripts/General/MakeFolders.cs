using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
 
/// Store this code as "MakeFolders.cs" in the Assets\Editor directory (create it, if it does not exist)
/// Creates a number of directories for storage of various content types.
/// Modify as you see fit.
/// Directories are created in the Assets dir.
/// Not tested on a Mac.
  

  /*
Scene Structure 
---------------
Cameras
Dynamic Objects
Gameplay
   Actors
   Items
   ...
GUI
   HUD
   PauseMenu
   ...
Management
Lights
World
   Ground
   Props
   Structure
   ...
   */
   
public class MakeFolders : ScriptableObject
{
 
    [MenuItem ( "Assets/Make Project Folders" )]
    static void MenuMakeFolders()
    {
		CreateFolders();
	}
 
	static void CreateFolders()
	{
		string f = Application.dataPath + "/";
 
		Directory.CreateDirectory(f + "_UnityCommon");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/General");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Editor");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Controllers");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/GUI");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Effects");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Physics");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Networking");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Sound");
		Directory.CreateDirectory(f + "_UnityCommon/Scripts/Development");		
		Directory.CreateDirectory(f + "_UnityCommon/Actors");
		Directory.CreateDirectory(f + "_UnityCommon/Actors/Platformer");
		Directory.CreateDirectory(f + "_UnityCommon/Actors/Shooter");
		Directory.CreateDirectory(f + "_UnityCommon/Camera");
		Directory.CreateDirectory(f + "_UnityCommon/Camera/Code");
		Directory.CreateDirectory(f + "_UnityCommon/Input");
		Directory.CreateDirectory(f + "_UnityCommon/Input/Code");
		
		Directory.CreateDirectory(f + "_Game"); 
		Directory.CreateDirectory(f + "/_Game/Animation");
		Directory.CreateDirectory(f + "/_Game/Effects");
		Directory.CreateDirectory(f + "/_Game/Plugins");
		Directory.CreateDirectory(f + "/_Game/Prefabs");
		Directory.CreateDirectory(f + "/_Game/Prefabs/Actors");
		Directory.CreateDirectory(f + "/_Game/Prefabs/Items");
		Directory.CreateDirectory(f + "/_Game/Resources");
		Directory.CreateDirectory(f + "/_Game/Resources/Sound");
		Directory.CreateDirectory(f + "/_Game/Resources/Music");
		Directory.CreateDirectory(f + "/_Game/Resources/Art");		
		Directory.CreateDirectory(f + "/_Game/Resources/Art/Actors");		
		Directory.CreateDirectory(f + "/_Game/Resources/Art/Structures");		
		Directory.CreateDirectory(f + "/_Game/Resources/Art/Props");		
		Directory.CreateDirectory(f + "/_Game/Resources/Meshes");
		Directory.CreateDirectory(f + "/_Game/Resources/Meshes/Actors");
		Directory.CreateDirectory(f + "/_Game/Resources/Meshes/Structures");
		Directory.CreateDirectory(f + "/_Game/Resources/Meshes/Props");
		Directory.CreateDirectory(f + "/_Game/Scripts");		
		Directory.CreateDirectory(f + "/_Game/Scripts/Debug");	
		Directory.CreateDirectory(f + "/_Game/Scripts/Gameplay");	
		Directory.CreateDirectory(f + "/_Game/Scripts/Gameplay/Actors");	
		Directory.CreateDirectory(f + "/_Game/Scripts/Gameplay/Items");	
		Directory.CreateDirectory(f + "/_Game/Scripts/Framework");	
		Directory.CreateDirectory(f + "/_Game/Scripts/Graphics");	
		Directory.CreateDirectory(f + "/_Game/Scripts/GUI");	
		Directory.CreateDirectory(f + "/_Game/Scenes");
		Directory.CreateDirectory(f + "/_Game/Scenes/GUI");
		Directory.CreateDirectory(f + "/_Game/Scenes/Levels");
		Directory.CreateDirectory(f + "/_Game/Scenes/TestScenes");
		Directory.CreateDirectory(f + "/_Game/UI");
		Directory.CreateDirectory(f + "/_Game/UI/Images");
		Directory.CreateDirectory(f + "/_Game/UI/Fonts");
		Directory.CreateDirectory(f + "/_Game/UI/Prefabs");
 
		Debug.Log("Created directories");
	}
}