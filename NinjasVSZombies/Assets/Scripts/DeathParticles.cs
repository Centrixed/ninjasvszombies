using UnityEngine;
using System.Collections;

public class DeathParticles : MonoBehaviour {

    public GameObject player;
    private PlayerStatus playerStat;
    public ParticleSystem particles;
    private bool running = false;

	// Use this for initialization
	void Start () {
        playerStat = player.GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerStat.dead) {
            if (running) {

            }
            else if (!running) {
                particles.Play();
                running = true;
            }
        }
	}
}
