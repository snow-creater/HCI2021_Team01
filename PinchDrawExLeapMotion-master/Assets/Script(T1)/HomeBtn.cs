﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour {

	public void PushButton()
    {
        SceneManager.LoadScene("Home");
    }
}
