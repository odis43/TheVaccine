
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game");


    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}
