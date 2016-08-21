using UnityEngine;
using System.Collections;

public class EnemyAnimate : MonoBehaviour {

    private Animator enemyAni;
    private SpriteRenderer enemySprite; //Used to flip sprite.
    private EnemyStatus enemyStat;
    private Rigidbody2D enemyRigid;
    private RigidbodyConstraints2D pos, pos1;
    private bool deathStopper = false;

	// Use this for initialization
	void Start () {
        enemyAni = gameObject.GetComponent<Animator>();
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        enemyStat = gameObject.GetComponent<EnemyStatus>();
        enemyRigid = gameObject.GetComponent<Rigidbody2D>();
        pos = RigidbodyConstraints2D.FreezeAll;
        pos1 = RigidbodyConstraints2D.FreezeRotation;
        StartCoroutine("spawnWait");
	}
	
	// Update is called once per frame
	void Update () {
        checkDead();
        if (enemyRigid.velocity.x > 0.1 || enemyRigid.velocity.x < -0.1 || enemyRigid.velocity.y > 0.1 || enemyRigid.velocity.y < -0.1) {
            enemyAni.SetBool("Running", true);
            if(enemyRigid.velocity.x < -0.1) {
                enemySprite.flipX = true;
            }
            else if(enemyRigid.velocity.x > 0.1) {
                enemySprite.flipX = false;
            }
        }
        else {
            enemyAni.SetBool("Running", false);
        }
	}

    //If enemy dies, then initiate the animation for it,
    void checkDead() {
        if (enemyStat.dead && !deathStopper) {
            enemyAni.ResetTrigger("SpawnWait");
            enemyAni.SetBool("Running", false);
            enemyAni.SetTrigger("Dead");
            deathStopper = true;
        }
    }

    //Allows for the zombie spawn animation to occur without the enemy moving.
    IEnumerator spawnWait() {
        enemyRigid.constraints = pos;
        yield return new WaitForSeconds(0.8f);
        enemyAni.SetTrigger("SpawnWait");
        enemyRigid.constraints = pos1;
    }
}
