using UnityEngine;
using System.Collections;

public class DropShadow : MonoBehaviour {

    public Animator playerAni;
    public SpriteRenderer playerSprite;
    public Transform playerTrans;
    private Animator shadowAni;
    private Transform shadowTrans;
    private float slideAdjust;
    private bool delay, slideHold;

	// Use this for initialization
	void Start () {
        shadowAni = GetComponent<Animator>();
        shadowTrans = GetComponent<Transform>();
        delay = false;
        slideHold = false;
        slideAdjust = 6;
	}
	
	// Update is called once per frame
	void Update () {
        
        //Checks for running, then sets shadow pulse animation bool
        if (!delay && (playerAni.GetBool("RunRight") || playerAni.GetBool("RunLeft"))) {
            shadowAni.SetBool("Pulse", true);
            delay = true;
        }
        else if(delay && playerAni.GetBool("isIdle")) {
            shadowAni.SetBool("Pulse", false);
            delay = false;
        }

        //Checks for sliding, then sets shadow slide animation bool
        if (!slideHold && playerAni.GetBool("Slide")) {
            if (!playerSprite.flipX) {
                slideAdjust = 6;
            }
            else if (playerSprite.flipX) {
                slideAdjust = -6;
            }
            shadowAni.SetBool("Slide", true);
            for(float i = 0; i < 4; i += 1) {
                shadowTrans.position = new Vector2(shadowTrans.position.x + slideAdjust, shadowTrans.position.y + i);
            }
            slideHold = true;
        }
        else if (slideHold && !playerAni.GetBool("Slide")) {
            shadowAni.SetBool("Slide", false);
            for (float i = 0; i < 4; i += 1) {
                shadowTrans.position = new Vector2(shadowTrans.position.x - slideAdjust, shadowTrans.position.y - i);
            }
            slideHold = false;
        }
    }
}
