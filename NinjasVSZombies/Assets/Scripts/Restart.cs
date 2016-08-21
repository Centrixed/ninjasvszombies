using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {
	// Use this for initialization
	void Start () {
       
	}

    public void restart() {
        SceneManager.LoadScene("A1L1");
    }
}
