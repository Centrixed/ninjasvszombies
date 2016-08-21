using UnityEngine;
using System.Collections;

public class RunParticles : MonoBehaviour {

    public ParticleSystem particle;
    public Animator animate;
    public bool isPlaying = false;
    private PlayerStatus playerStat;
    private GameObject player;
    private MovementScript playerMove;

	void Start () {
        player = GameObject.Find("MainChar");
        animate = player.GetComponent<Animator>();
        playerStat = player.GetComponent<PlayerStatus>();
        playerMove = player.GetComponent<MovementScript>();
	}
	
	void Update () {
        if (!playerStat.dead) {
            if (animate.GetBool("isIdle") || playerMove.isSliding) {
                if (particle.isStopped) {
                    isPlaying = false;
                }
                else {
                    particle.Stop();
                    particle.Clear();
                }
            }
            else if (!animate.GetBool("isIdle") && !playerMove.isSliding) {
                if (particle.isPlaying) {
                    isPlaying = true;
                }
                else if (particle.isStopped) {
                    particle.Play();
                }
                else {
                    particle.Play();
                }
            }
        }
	}
}
