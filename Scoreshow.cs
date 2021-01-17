
using UnityEngine;
using UnityEngine.UI;

public class Scoreshow : MonoBehaviour
{
    public static int FinalscoreValue = 0;
    public Text score;
    void Start()
    {
      
        score = GetComponent<Text>();
       
    }

     void Update()
    {
        score.text = "Your score was:  " + FinalscoreValue;
   
    }

}
