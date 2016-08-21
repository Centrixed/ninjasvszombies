using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour {
    public string levelName;
    public int lvlNum;

	// Use this for initialization
	void Start () {
	    
	}
	
    public void loadLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
        PlayerPrefs.SetInt("lvlNum", lvlNum);
    }
}
