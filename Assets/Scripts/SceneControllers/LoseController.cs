using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
