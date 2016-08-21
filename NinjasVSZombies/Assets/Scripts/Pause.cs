using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public Animation pauseAnimation;
    private GameObject pauseObject;
    private Animator pauseAnimate, canvasAnimate;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        pauseObject = gameObject;
        pauseAnimate = gameObject.GetComponent<Animator>();
        canvasAnimate = GameObject.Find("Canvas").GetComponent<Animator>();
        pauseObject.SetActive(false);
	}

    //If button is clicked, if not paused, pause. Otherwise unpause the game.
    public void pauseGame() {
        if (!paused) {
            pauseObject.SetActive(true);
            pauseAnimate.SetBool("Pause", true);
            canvasAnimate.SetBool("End", true);
            StartCoroutine("Wait");
            paused = true;
        }
        else if (paused) {
            pauseAnimate.SetBool("Pause", false);
            canvasAnimate.SetBool("End", false);
            Time.timeScale = 1;
            paused = false;
            pauseObject.SetActive(false);
        }
    }

    //Waits for animation to finish, then pauses game
    IEnumerator Wait() {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
