﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostGameMenu : MonoBehaviour {

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
