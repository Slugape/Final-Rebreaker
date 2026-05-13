using UnityEngine;

public class RShotScript : MonoBehaviour
{
    private float Rspeed = 25f;
    
   // void OnTriggerEnter2D(Collider2D collide)
   // {
       // Debug.Log("Hit Brick" + collide.gameObject.name);
       // if (collide.gameObject.tag == "Brick")
     //   {
          //  Destroy(collide.gameObject);
            //Destroy(gameObject);
           // GameObject.Find("Score").GetComponent<ScoreScript>().Score += 100;
            //Debug.Log("Hit Brick");
       // }
 //   }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Trajectory of rocket
        transform.position += transform.up * Rspeed * Time.deltaTime;
        
        //collision via Raycast
        RaycastHit2D Shothit = Physics2D.Raycast(transform.position, transform.up, Rspeed * Time.deltaTime);
        if (Shothit.collider != null && Shothit.collider.gameObject.GetComponent<BrickScript>())
            {
                Shothit.collider.gameObject.GetComponent<BrickScript>().BrickDestruction();
                Destroy(gameObject);
                ScoreScript.Score += 100;
               // Debug.Log("ray hit" + Shothit.collider.gameObject.name);
            }
        

    }
}
