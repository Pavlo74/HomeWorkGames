using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//для роботи з інтерфейсом

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)//для підрахунку
    {
        if(collision.tag == "Score")
        {
            score++;
        }
    }
}
