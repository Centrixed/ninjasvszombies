using UnityEngine;
using System.Collections;

public class LevelAniController : MonoBehaviour {

    public A1L1Script levelCont;
    public Animator canvasAni;
    private GameObject lvlComplete, lvlFail;
    private PlayerStatus playerStat;
    private bool stop = false;

	// Use this for initialization
	void Start () {
        canvasAni = GetComponent<Animator>();
        lvlComplete = GameObject.Find("LvlEndScreen");
        lvlFail = GameObject.Find("DeathScreen");
        playerStat = GameObject.Find("MainChar").GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
        if (levelCont.levelOver) {
            lvlComplete.SetActive(true);
            Debug.Log("Setting canvas trigger");
            canvasAni.SetBool("End", true);
        }
        else if (!levelCont.levelOver) {
            lvlComplete.SetActive(false);
        }

        if (!playerStat.dead) {
            lvlFail.SetActive(false);
        }
        else if (playerStat.dead) {
            lvlFail.SetActive(true);
        }
	}
}

