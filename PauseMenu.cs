
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject MenuUI;
 
    private void Start()
    {
        
            MenuUI.SetActive(false);

        
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
             
            }

        }

    }

   public void Resume()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        


    }

    void Pause()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
      

    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
