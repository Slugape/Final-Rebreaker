using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    //For Paddle
    public Transform PaddleT;
    public float Pspeed = 8;
    private float minX = -15.5f;
    private float maxX = 15.5f;
    bool moveRight = true;
    public bool PFreeze = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PFreeze == false)
        {
            //Paddle Movement
            if (PaddleT.position.x > maxX)
            {
                moveRight = false;
                // Debug.Log("full right");
            }

            if (PaddleT.position.x < minX)
            {
                moveRight = true;
                //Debug.Log("full left");
            }

            if (moveRight)
            {
                PaddleT.position = new Vector3(PaddleT.position.x + Pspeed * Time.deltaTime, PaddleT.position.y,
                    PaddleT.position.z);
            }
            else
            {
                PaddleT.position = new Vector3(PaddleT.position.x - Pspeed * Time.deltaTime, PaddleT.position.y,
                    PaddleT.position.z);
            }
        }
    } 
}
