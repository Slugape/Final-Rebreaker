using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI SText;
    public static int Score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Score text displayed via Score int^
        SText.text = "Score " + Score.ToString();
    }
}
