using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour {

	public static DataController db;
	public PlayerData playerData;

	void Awake () {
		if (db == null) {
			DontDestroyOnLoad (gameObject);
			db = this;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		bf.Serialize (file, playerData);
		file.Close ();
	}

	public void Load() {
		string filePath = Application.persistentDataPath + "/playerInfo.dat";
		if (File.Exists (filePath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filePath, FileMode.Open);
			playerData = bf.Deserialize (file) as PlayerData;
//			Debug.Log ("xxxxx");
		} else {
			playerData = new PlayerData();
			playerData.avatarModels = new List<string>{"GameScene/Prefabs/Avatars/Cube", "GameScene/Prefabs/Avatars/Sphere"};
			playerData.avatarMats = new List<string>{"GameScene/Materials/red", "GameScene/Materials/black"};
			playerData.coins = 3760;
			playerData.avatarModelIndx = 0;
			playerData.avatarMatIndx = 0;
			Save ();
		}
	}

	public void AddItem(string item, int num) {
		if (num == 1) {
			playerData.avatarModels.Add (item);
		} else if (num == 0) {
			playerData.avatarMats.Add (item);
		} else {
			//playerData.effect.Add (item);
		}
		Save ();
	}

	public bool CheckItem(string item, int num) {
		if (num == 0) {
			return CheckItemHelper (item, playerData.avatarMats);
		} else if (num == 1) {
			return CheckItemHelper (item, playerData.avatarModels);
		} else {
			//return CheckItemHelper (item, playerData.effect);
			return true;
		}
	}

	private bool CheckItemHelper(string item, List<string> list) {
		foreach (string item_ in list) {
			if (item == item_)
				return false;
		}
		return true;
	}
}

[Serializable]
public class PlayerData {
	public int coins;
	public List<string> avatarModels;
	public List<string> avatarMats;

	public int avatarModelIndx;
	public int avatarMatIndx;
}