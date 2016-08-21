using UnityEngine;
using System.Collections;

public class CasterProjectile : MonoBehaviour {

    private Animator projAni;
    private PlayerStatus playerStat;
    private Rigidbody2D projRigid;
    private RigidbodyConstraints2D freeze;

    void Start() {
        projAni = GetComponent<Animator>();
        projRigid = GetComponent<Rigidbody2D>();
        freeze = RigidbodyConstraints2D.FreezeAll;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "MainChar") {
            playerStat = coll.gameObject.GetComponent<PlayerStatus>();
            projAni.SetTrigger("Hit");
            projRigid.constraints = freeze;
            playerStat.health -= 25;
            Destroy(gameObject, 0.5f);
        }
    }
}
