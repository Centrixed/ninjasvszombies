using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectShader : MonoBehaviour {

    public int whichLevel;              //Dev Controlled
    public Image imageController;       //Dev Controlled
    private Color alphaControl;
    private bool stop = false;

    // Sets alpha object to 0, then sets image alpha to the object. Starts fade in loop.
    void Start () {
        alphaControl = imageController.color;
        alphaControl.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ifLevelCompleted();
	}

    //Fades in the shader along with the level
    IEnumerator FadeIn() {
        yield return new WaitForSeconds(0.5f);
        for(float i = 0f; i <= 1f; i += 0.05f) {
            alphaControl.a = i;
            imageController.color = alphaControl;
            yield return new WaitForSeconds(0.05f);
        }
    }
   
    
    /////////////////////////////////////////////////////////////////////////////
    // Uses the dev controlled whichLevel value to check for level completion. //
    // If completed, run the fade in IEnumerator function                      //
    /////////////////////////////////////////////////////////////////////////////
    void ifLevelCompleted() {
        if (whichLevel == 0) {
            if(PlayerPrefs.GetInt("Tut") == 1) {
                if (!stop) {
                    Debug.Log("0");
                    StartCoroutine("FadeIn");
                    stop = true;
                }
            }
        }
        else if (whichLevel == 1) {
            if (PlayerPrefs.GetInt("A1L1") == 1) {
                if (!stop) {
                    Debug.Log("1");
                    stop = true;
                    StartCoroutine("FadeIn");
                }
            }
        }
        else if (whichLevel == 2) {
            if (PlayerPrefs.GetInt("A1L2") == 1) {
                if (!stop) {
                    Debug.Log("2");
                    stop = true;
                    StartCoroutine("FadeIn");
                }
            }
        }
        else if (whichLevel == 3) {
            if (PlayerPrefs.GetInt("A1L3") == 1) {
                if (!stop) {
                    Debug.Log("3");
                    stop = true;
                    StartCoroutine("FadeIn");
                }
            }
        }
        else if (whichLevel == 4) {
            if (PlayerPrefs.GetInt("A1L4") == 1) {
                if (!stop) {
                    Debug.Log("4");
                    stop = true;
                    StartCoroutine("FadeIn");
                }
            }

        }
    }
}
