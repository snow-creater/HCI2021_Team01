using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class printBtn : MonoBehaviour {

    public void PushButton()
    {
        SceneManager.LoadScene("quiz1");
    }
}
