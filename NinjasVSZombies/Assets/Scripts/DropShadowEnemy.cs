using UnityEngine;
using System.Collections;

public class DropShadowEnemy : MonoBehaviour {

    public Animator enemyAni;
    private Animator shadowAni;
    private bool delay;

    // Use this for initialization
    void Start() {
        shadowAni = GetComponent<Animator>();
        delay = false;
    }

    // Update is called once per frame
    void Update() {

        //Checks for running, then sets shadow pulse animation bool
        if (!delay && enemyAni.GetBool("Running")) {
            shadowAni.SetBool("Pulse", true);
            delay = true;
        }
        else if (delay && !enemyAni.GetBool("Running")) {
            shadowAni.SetBool("Pulse", false);
            delay = false;
        }
    }
}
