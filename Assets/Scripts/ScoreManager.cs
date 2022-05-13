using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Kills = 0;
    public Text Score;
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        Kills = 0;
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = Kills.ToString();
        if (Kills > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Kills);
            highscore.text = Kills.ToString();
        }
    }
}
