using UnityEngine;
using System.Collections;

public class A1L1Script : MonoBehaviour {
    public int ranNum;         //lvlNum is Dev Controlled
    public bool levelOver = false;
    public float waitTimer;
    public GameObject player;
    public GameObject enemyPrefab, casterPrefab, heavyPrefab;
    public Transform sp1, sp2, sp3, sp4, sp5;
    private PlayerStatus playerStat;
    private EnemyMovement cloneMove;
    private CasterMovement casterMove;
    private HeavyMovement heavyMove;
    private GameObject clone, heavyClone, casterClone;
    private Rigidbody2D cloneRigid;
    private bool playing = true;
    private int heavySpeed, enemySpeed, casterSpeed, enemyId;
    private int spawnCount;
    private int reqKills;
    private int lvlNum;
    public int overrideNum;
    public bool overrideLvl = false;


    void Start () {
        //checks for dev lvl overriding
        if (!overrideLvl) {
            lvlNum = PlayerPrefs.GetInt("lvlNum");
        } else if (overrideLvl) {
            lvlNum = overrideNum;
        }

        playerStat = player.GetComponent<PlayerStatus>();
        ranNum = Random.Range(1, 6);
        heavySpeed = Random.Range(45, 50);
        enemySpeed = Random.Range(60, 70);
        casterSpeed = Random.Range(35, 40);
        setupFunct();
    }

    //Custom gamespawner loops for each level
    IEnumerator tutLoop() {
        do {
            //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY

            yield return new WaitForSeconds(1);

            //If player is dead break the loop.
            if (playerStat.dead) {
                break;
            }

        }
        while (spawnCount > 0);
    }

    IEnumerator A1L1Loop() {
        do {
            //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY

            //Spawns a caster enemy at the spawncount of 5
            if (spawnCount == 5) {
                enemyId = 1;
            }
            else {
                enemyId = 0;
            }

            if (spawnCount > 0) {
                if (ranNum == 1) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp1.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp1.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp1.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 2) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp2.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp2.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp2.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 3) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp3.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp3.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp3.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 4) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp4.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp4.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp4.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 5) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp5.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp5.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp5.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
            }

            if (playerStat.dead) { 
                break;
            }

        }
        while (spawnCount > 0);
    }
	
    IEnumerator A1L2Loop() {
        do {
            //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY

            //Spawns a caster enemy at the spawncount of 10
            if (spawnCount == 10) {
                enemyId = 1;
            }
            else if (spawnCount == 5) {
                enemyId = 2;
            }
            else {
                enemyId = 0;
            }

            if (spawnCount > 0) {
                if (ranNum == 1) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp1.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp1.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp1.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 2) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp2.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp2.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp2.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 3) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp3.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp3.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp3.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 4) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp4.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp4.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp4.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 5) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp5.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp5.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp5.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
            }

            //If player is dead break the loop.
            if (playerStat.dead) {
                break;
            }

        }
        while (spawnCount > 0);
    }

    IEnumerator A1L3Loop() {
        do {
            //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY

            //Spawns 2 of each enemy
            if (spawnCount == 10 || spawnCount == 25) {
                enemyId = 1;
            }
            else if (spawnCount == 20 || spawnCount == 15) {
                enemyId = 2;
            }
            else {
                enemyId = 0;
            }

            if (spawnCount > 0) {
                if (ranNum == 1) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp1.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp1.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp1.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 2) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp2.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp2.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp2.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 3) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp3.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp3.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp3.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 4) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp4.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp4.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp4.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 5) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp5.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp5.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp5.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
            }

            //If player is dead break the loop.
            if (playerStat.dead) {
                break;
            }

        }
        while (spawnCount > 0);
    }

    IEnumerator A1L4Loop() {
        do {
            //ENEMY ID'S: 0 - NORMAL, 1 - CASTER, 2 - HEAVY

            //Spawns 3 of each enemy
            if (spawnCount == 10 || spawnCount == 20 || spawnCount == 30) {
                enemyId = 1;
            }
            else if (spawnCount == 15 || spawnCount == 25 || spawnCount == 35) {
                enemyId = 2;
            }
            else {
                enemyId = 0;
            }

            if (spawnCount > 0) {
                if (ranNum == 1) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp1.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp1.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp1.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 2) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp2.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp2.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp2.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 3) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp3.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp3.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp3.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 4) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp4.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp4.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp4.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
                else if (ranNum == 5) {
                    yield return new WaitForSeconds(waitTimer);
                    --spawnCount;
                    if (enemyId == 0) {
                        clone = (GameObject)Instantiate(enemyPrefab, sp5.position, Quaternion.identity);
                        cloneMove = clone.GetComponent<EnemyMovement>();
                        cloneMove.speed = enemySpeed;
                    }
                    else if (enemyId == 1) {
                        casterClone = (GameObject)Instantiate(casterPrefab, sp5.position, Quaternion.identity);
                        casterMove = casterClone.GetComponent<CasterMovement>();
                        casterMove.speed = casterSpeed;
                    }
                    else if (enemyId == 2) {
                        heavyClone = (GameObject)Instantiate(heavyPrefab, sp5.position, Quaternion.identity);
                        heavyMove = heavyClone.GetComponent<HeavyMovement>();
                        heavyMove.speed = heavySpeed;
                    }
                }
            }

            //If player is dead break the loop.
            if (playerStat.dead) {
                break;
            }

        }
        while (spawnCount > 0);
    }

    void Update () {
        //Creates random values for each class of enemy & their spawn locations
        ranNum = Random.Range(1, 6);
        heavySpeed = Random.Range(45, 50);
        enemySpeed = Random.Range(60, 70);
        casterSpeed = Random.Range(35, 40);

        //If player meets required kills to win, end level and save stats
        if(playerStat.kills == reqKills) {
            //Display End Level Screen
            levelOver = true;
            if (playing) {
                Debug.Log("end");
                PlayerPrefs.SetInt("Score", playerStat.score);  //Saves player score
                playing = false;
                if (lvlNum == 0) {
                    PlayerPrefs.SetInt("Tut", 1);       //Sets tutorial to complete.
                }
                else if (lvlNum == 1) {
                    PlayerPrefs.SetInt("A1L1", 1);      //Sets level one to complete.
                }
                else if (lvlNum == 2) {
                    PlayerPrefs.SetInt("A1L2", 1);      //Sets level two to complete.
                }
                else if (lvlNum == 3) {
                    PlayerPrefs.SetInt("A1L3", 1);      //Sets level three to complete.
                }
                else if (lvlNum == 4) {
                    PlayerPrefs.SetInt("A1L4", 1);      //Sets level four to complete.
                }
            }
        }

    }

    //Determines the amount of kills required to complete each level, then runs the level loop ienumerator (level 0 is tutorial)
    void setupFunct() {
        if (lvlNum == 0) {
            reqKills = 5;
            spawnCount = reqKills;
            StartCoroutine("tutLoop");
        }
        else if (lvlNum == 1) {
            reqKills = 10;
            spawnCount = reqKills;
            StartCoroutine("A1L1Loop");
        }
        else if (lvlNum == 2) {
            reqKills = 20;
            spawnCount = reqKills;
            StartCoroutine("A1L2Loop");
        }
        else if (lvlNum == 3) {
            reqKills = 30;
            spawnCount = reqKills;
            StartCoroutine("A1L3Loop");
        }
        else if (lvlNum == 4) {
            reqKills = 40;
            spawnCount = reqKills;
            StartCoroutine("A1L4Loop");
        }
    }
}
