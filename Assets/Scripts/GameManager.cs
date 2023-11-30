using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage=1;
    public int sccore;

    public static GameManager I;

    void Awake()
    {
        I = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

}
