using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardUIBlue : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    private int blueScore;
    // Start is called before the first frame update
    void Start()
    {
        blueScore = 0;
        tmpText.SetText(blueScore.ToString());
    }
    
    public void increaseBlue()
    {
        blueScore++;
        tmpText.SetText(blueScore.ToString());
    }
    
    public int getScoreBlue()
    {
        return blueScore;
    }

    public void changeColor()
    {
        tmpText.color = Color.blue;
    }
    
    public void changeColorWhite()
    {
        tmpText.color = Color.white;
    }
    
}
