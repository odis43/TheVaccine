
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool GamehasEnded = false;
    public float delay;
    public void EndGame()
    {
        if (GamehasEnded == true)
        {
            GamehasEnded = false;
            
            Debug.Log("GAME OVER");
            
        }

    }
    public void DeathMenu()
    {
        SceneManager.LoadScene("DeathMenu");
        Invoke("DeathMenu", delay);
        
    }

   
}
