using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public GameObject RocketPF;

    public GameObject ColorWPF;
    
    //Ball impact
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Breaker Ball") 
        {
            BrickDestruction();
        }
    }
    
    //Brick type destroyed and Score + Powerup
   public void BrickDestruction()
    {
        if (gameObject.tag == "Brick")
        {
            Destroy(gameObject);
            ScoreScript.Score += 50;
            Debug.Log(ScoreScript.Score);
        }
        if (gameObject.tag == "RBrick")
        {
            Destroy(gameObject);
            ScoreScript.Score += 50;
            Debug.Log(ScoreScript.Score);
            Instantiate(RocketPF, transform.position, Quaternion.identity);
        }
        if (gameObject.tag == "CWBrick")
        {
            Destroy(gameObject);
            ScoreScript.Score += 50;
            Debug.Log(ScoreScript.Score);
            Instantiate(ColorWPF, transform.position, Quaternion.identity);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
} 
