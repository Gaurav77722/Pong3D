using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText; 
    private int greenScore;
    private int blueScore;
    
    // Start is called before the first frame update
    void Start()
    {
        greenScore = 0;
        tmpText.SetText(greenScore.ToString());
    }

    public void increaseGreen()
    {
        greenScore++;
        tmpText.SetText(greenScore.ToString());
    }

    public int getScoreGreen()
    {
        return greenScore;
    }

    public void changeColor()
    {
        tmpText.color = Color.green;
    }
    
    public void changeColorWhite()
    {
        tmpText.color = Color.white;
    }
    
    
}
