using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(bool online)
    {
        SceneManager.LoadScene("Singleplayer");
    }
}