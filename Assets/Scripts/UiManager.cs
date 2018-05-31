using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject TapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake()
    {
        if(instance == null){
            instance = this;    
        }   
    }

    // Use this for initialization
    void Start () {
		
	}

    public void GameStart(){
        TapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
    }
	
    public void GameOver(){
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
