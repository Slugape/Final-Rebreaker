using UnityEngine;

public class ParallaxMousePos : MonoBehaviour

{
    public GameObject Foreground;
    public GameObject Midground;
    public GameObject Background;

    public float ForgroundSpeed = 0.1f;
    public float MidgroundSpeed = 0.05f;
    public float BackgroundSpeed = 0.01f;
    
    private Vector3 ForegroundStart;
    private Vector3 MidgroundStart;
    private Vector3 BackgroundStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         ForegroundStart= Foreground.transform.position;
         MidgroundStart= Midground.transform.position;
         BackgroundStart= Background.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float mouseXpos = (Input.mousePosition.x / Screen.width) - 0.5f;
        Foreground.transform.position = new Vector2(ForegroundStart.x + mouseXpos * ForgroundSpeed, ForegroundStart.y) ;
        Midground.transform.position = new Vector2(MidgroundStart.x + mouseXpos * MidgroundSpeed, MidgroundStart.y) ;
        Background.transform.position = new Vector2(BackgroundStart.x + mouseXpos * BackgroundSpeed, BackgroundStart.y) ;
        
    }
}