using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillTracker : MonoBehaviour {

    public PlayerStatus playerStat;
    private Text text;

    void Start() {
        text = GetComponent<Text>();
    }
    void Update() {
        text.text = playerStat.kills.ToString();
    }
}
