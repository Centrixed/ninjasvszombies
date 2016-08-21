using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MobileBackButton : MonoBehaviour {

    public string previousScene;
    private Scene current;
    private A1L1Script lvlScript;
    private string convert;

    void Start() {
        lvlScript = gameObject.GetComponent<A1L1Script>();
        current = SceneManager.GetActiveScene();
    }

    public void loadPrevious() {
        if (lvlScript.levelOver) {
            SceneManager.LoadScene(previousScene);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (current.name == "Menu") {
                Application.Quit();
            }
            else {
                SceneManager.LoadScene(previousScene);
            }
        }
    }
}
