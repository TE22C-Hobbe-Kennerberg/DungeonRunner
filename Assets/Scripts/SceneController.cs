using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);

    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

}
