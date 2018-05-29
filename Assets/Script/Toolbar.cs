using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class Toolbar : MonoBehaviour {

	public void SaveGame(){
		EditorSceneManager.SaveScene(SceneManager.GetActiveScene(),"Assets/Scenes/Saved_Game.unity");
	}
}
