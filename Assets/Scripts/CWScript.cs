using UnityEngine;


//rectangular -> Polar Conversion
//To Do - 1. Find mouse position (x,y,z)
// 2. Convert mouse pos into polar coordinates, angle & radius

public class HSV : MonoBehaviour

{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Breaker Ball")
        {
            Destroy(gameObject);
            GameObject.Find("Breaker Ball").GetComponent<BallScript>().ColorWOn  = true; 
            //Debug.Log(GameObject.Find("Breaker Ball").GetComponent<BallScript>().ColorWOn);
        }
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Screen Width : " + Screen.width / 2);
        //Debug.Log("Screen Height : " + Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}



//Debug after the end math as it goes through it from top to bottom
//atan by default returns -Pi to Pi (-180, +180) and we want all degrees of a circle so that is why
//we +=360f
