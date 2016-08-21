using UnityEngine;
using System.Collections;

public class SlideParticles : MonoBehaviour {

    public GameObject player;
    private Animator playerAni;
    private SpriteRenderer playerSprite;
    public bool isPlaying = false;
    private ParticleSystem particleSys;
    private Transform particleTrans;
    private float particleAdjust;
    private Vector2 rotateVector;

    // Use this for initialization
    void Start() {
        particleSys = GetComponent<ParticleSystem>();
        particleTrans = GetComponent<Transform>();
        playerAni = player.GetComponent<Animator>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        particleAdjust = 3;
    }

    // Update is called once per frame
    void Update() {
        if (particleSys.isPlaying) {
            isPlaying = true;
        }
        else {
            isPlaying = false;
        }

        //Adjusts position depending on face direction of player
        if (!playerSprite.flipX) {
            rotateVector = new Vector2(0, 180);
            particleTrans.localRotation = Quaternion.Euler(rotateVector);
            particleAdjust = 2.25f;
        }
        else if (playerSprite.flipX) {
            rotateVector = new Vector2(0, 0);
            particleTrans.localRotation = Quaternion.Euler(rotateVector);
            particleAdjust = -2.25f;
        }

        //Checks for sliding, then sets shadow slide animation bool
        if (playerAni.GetBool("Slide")) {
            particleTrans.localPosition = new Vector2(particleAdjust, -1.43f);
            particleSys.Play();
        }
        else if (isPlaying && !playerAni.GetBool("Slide")) {
            particleTrans.localPosition = new Vector2(0.08f, -1.43f);
            particleSys.Stop();
            particleSys.Clear();
        }
    }
}
