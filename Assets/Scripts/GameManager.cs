using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public GameObject puck;
    
    [SerializeField] private string[] levels;

    public int score1;
    public int score2;

    public Text Player1;
    public Text Player2;
    
    float timeLeft = 300f;

    void Update()
    {
        Player1.text = "" + score1;
        Player2.text = "" + score2;
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            Debug.Log("Gameover");
        }

        if (score1 == 5)
            SceneManager.LoadScene("Victory1");
        
        if (score2 == 5)
            SceneManager.LoadScene("Victory2");
        
        
    }

    private void Awake()
    {
        instance = this;
        puck = GameObject.FindGameObjectWithTag("Puck");
        DontDestroyOnLoad(gameObject);
    }
    
    public void Respawn()
    {
        puck.GetComponent<Rigidbody>().velocity = Vector3.zero;
        puck.transform.position = LevelManager.instance.spawnPos;
    }

    
}
