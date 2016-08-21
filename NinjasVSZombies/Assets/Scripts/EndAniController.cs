using UnityEngine;
using System.Collections;

public class EndAniController : MonoBehaviour {

    public A1L1Script levelCont;
    private Animator canvasAni;
    private GameObject lvlComplete, lvlFail;
    private PlayerStatus playerStat;
    private bool stop = false;

	// Use this for initialization
	void Start () {
        canvasAni = gameObject.GetComponent<Animator>();
        lvlComplete = GameObject.Find("LvlEndScreen");
	}
	
	// Update is called once per frame
	void Update () {
        if (levelCont.levelOver) {
            if (!stop) {
                lvlComplete.SetActive(true);
                canvasAni.SetTrigger("End");
                stop = true;
            }
        }
        else if (!levelCont.levelOver) {
            lvlComplete.SetActive(false);
        }
	}
}

