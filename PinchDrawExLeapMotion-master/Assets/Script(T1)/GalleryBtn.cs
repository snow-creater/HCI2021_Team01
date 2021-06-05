using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryBtn : MonoBehaviour
{

    public void PushButton()
    {
        SceneManager.LoadScene("Gallery");
    }
}
