using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public int ranNum;
    public bool levelOver = false;
    public float waitTimer = 2.5f;
    public GameObject player;
    public GameObject enemyPrefab, casterPrefab, heavyPrefab;
    public Transform sp1, sp2, sp3, sp4, sp5;
    private PlayerStatus playerStat;
    private EnemyMovement cloneMove;
    private GameObject clone;
    private Rigidbody2D cloneRigid;
    private int heavySpeed, enemySpeed, casterSpeed, enemyId;
    private int spawnCount = 20;

    void Start () {
        playerStat = player.GetComponent<PlayerStatus>();
        enemyId = 0;                                               //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY
        ranNum = Random.Range(1, 6);
        heavySpeed = Random.Range(45, 50);
        enemySpeed = Random.Range(60, 70);
        casterSpeed = Random.Range(35, 40);
        StartCoroutine("spawnSequence");
	}

    //Picks a random number from the range, and instantiates the preferred enemy at that location.
    IEnumerator spawnSequence() {
        do {
            if (ranNum == 1) {
                yield return new WaitForSeconds(waitTimer);
                if(enemyId == 0) {
                    clone = (GameObject)Instantiate(enemyPrefab, sp1.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = enemySpeed;
                }
                else if(enemyId == 1) {
                    clone = (GameObject)Instantiate(casterPrefab, sp1.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = casterSpeed;
                    enemyId = 0;
                }
                else if(enemyId == 2) {
                    clone = (GameObject)Instantiate(heavyPrefab, sp1.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = heavySpeed;
                    enemyId = 0;
                }
            }
            else if (ranNum == 2) {
                yield return new WaitForSeconds(waitTimer);
                if (enemyId == 0) {
                    clone = (GameObject)Instantiate(enemyPrefab, sp2.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = enemySpeed;
                }
                else if (enemyId == 1) {
                    clone = (GameObject)Instantiate(casterPrefab, sp2.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = casterSpeed;
                    enemyId = 0;
                }
                else if (enemyId == 2) {
                    clone = (GameObject)Instantiate(heavyPrefab, sp2.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = heavySpeed;
                    enemyId = 0;
                }
            }
            else if (ranNum == 3) {
                yield return new WaitForSeconds(waitTimer);
                if (enemyId == 0) {
                    clone = (GameObject)Instantiate(enemyPrefab, sp3.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = enemySpeed;
                }
                else if (enemyId == 1) {
                    clone = (GameObject)Instantiate(casterPrefab, sp3.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = casterSpeed;
                    enemyId = 0;
                }
                else if (enemyId == 2) {
                    clone = (GameObject)Instantiate(heavyPrefab, sp3.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = heavySpeed;
                    enemyId = 0;
                }
            }
            else if (ranNum == 4) {
                yield return new WaitForSeconds(waitTimer);
                if (enemyId == 0) {
                    clone = (GameObject)Instantiate(enemyPrefab, sp4.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = enemySpeed;
                }
                else if (enemyId == 1) {
                    clone = (GameObject)Instantiate(casterPrefab, sp4.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = casterSpeed;
                    enemyId = 0;
                }
                else if (enemyId == 2) {
                    clone = (GameObject)Instantiate(heavyPrefab, sp4.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = heavySpeed;
                    enemyId = 0;
                }
            }
            else if (ranNum == 5) {
                yield return new WaitForSeconds(waitTimer);
                if (enemyId == 0) {
                    clone = (GameObject)Instantiate(enemyPrefab, sp5.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = enemySpeed;
                }
                else if (enemyId == 1) {
                    clone = (GameObject)Instantiate(casterPrefab, sp5.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = casterSpeed;
                    enemyId = 0;
                }
                else if (enemyId == 2) {
                    clone = (GameObject)Instantiate(heavyPrefab, sp5.position, Quaternion.identity);
                    cloneMove = clone.GetComponent<EnemyMovement>();
                    cloneMove.speed = heavySpeed;
                    enemyId = 0;
                }
            }

            if(spawnCount == 0) {
                levelOver = true;
                break;
            }
            --spawnCount;
        }
        while (!playerStat.dead);
    }
	
	void Update () {
        ranNum = Random.Range(1, 6);
        heavySpeed = Random.Range(45, 50);
        enemySpeed = Random.Range(60, 70);
        casterSpeed = Random.Range(35, 40);

        //Spawn 1 caster during the level.
        if(spawnCount == 10) {
            enemyId = 1;
        }

        if(levelOver == true) {
            //Display End Level Screen
            Debug.Log("End Of Level");
            PlayerPrefs.SetInt("Score", playerStat.score);  //Saves player score
            PlayerPrefs.SetInt("A1L1", 1);      //Sets level one to complete.
        }

    }
}
