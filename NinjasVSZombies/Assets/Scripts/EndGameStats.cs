using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class EndGameStats : MonoBehaviour {

    public Text textControl;    //Dev Controlled
    public int whichText;       //Dev Controlled
    public A1L1Script levelScript;  //Dev Controlled
    private CanvasGroup alphaControl;
    private PlayerStatus playerStat;
    private float startTime, endTime, totalTime;    //Handles Time Tracking
    private int startCash, endCash, totalCash;      // Handles Cash Tracking
    private bool stop = false, createStats = false;

	// Use this for initialization
	void Start () {
        alphaControl = gameObject.GetComponent<CanvasGroup>();
        playerStat = GameObject.Find("MainChar").GetComponent<PlayerStatus>();
        startTime = Time.time;
        startCash = PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void Update () {
        displayChecker();
        statCreateChecker();
	}

    //If game is over, run IEnumerator to fadein the stat alpha color.
    void displayChecker() {
        if (levelScript.levelOver) {
            if (!stop) {
                endTime = Time.time;
                totalTime = endTime - startTime;
                endCash = PlayerPrefs.GetInt("Score");
                totalCash = endCash - startCash;
                createStats = true;
                StartCoroutine("FadeIn");
                stop = true;
            }
        }
    }

    //Uses the developer set integer 'whichText' to modify and control which text to show for each text component. 1 = Playerkills, 2 = Cash Earned, 3 = Time Played
    void statCreateChecker() {
        if (createStats) {
            if(whichText == 1) {
                string temp;
                temp = playerStat.kills.ToString();
                if (playerStat.kills == 1) {
                    temp += " zombie";
                }
                else {
                    temp += " zombies";
                }
                textControl.text = temp;
            }
            else if(whichText == 2) {
                string temp;
                temp = "$";
                temp += totalCash.ToString();
                textControl.text = temp;
            }
            else if(whichText == 3) {
                string temp;
                temp = totalTime.ToString("#.#");
                temp += " seconds";
                textControl.text = temp;
            }
        }
    }

    //60 loops, causing a 0.6 second delay
    IEnumerator FadeIn() {
        for(float i = 0; i < 1f; i += 0.01f) {
            alphaControl.alpha = i;
            yield return new WaitForSeconds(0.0025f);
        }
    }
}
