using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BallScript : MonoBehaviour
{
    //For Ball
    public Rigidbody2D BallRB;
    public float Bspeed = 18f;
    
    //For Rocket
    public bool RocketOn = false;
    private bool RocketSpawn = false;
    public GameObject BallRocket;
    public GameObject RocketPFB;
    public GameObject RocketShot;
    
    private float radius = 1.5f;
    
    //For ColorWheel
    public bool ColorWOn = false;
    public bool ColorWSpawn = false;
    //public GameObject BallColorW;
    //public GameObject ColorWPFB;  (NOT IN USE)
    // public GameObject ColorWFreeze;
    
    //CW math items
    private float CWradius;
    private float angle;
    private float hue;
    private float saturation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallRB.linearVelocity = new Vector2(0,Bspeed +10f); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            BallRB.linearVelocity = new Vector2(BallRB.linearVelocity.x,Bspeed+10f); 
            //Debug.Log("bouncey");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (ColorWOn == false)
        {
            Vector2 vel = new Vector2(0, BallRB.linearVelocity.y);
            //Ball movement via <- -> arrows
            if (Input.GetKey(KeyCode.S))
            {
                vel.x = Bspeed;
                BallRB.linearVelocity = vel;
                //Debug.Log("yes");
            }

            else if (Input.GetKey(KeyCode.A))
            {
                vel.x = -Bspeed;
                BallRB.linearVelocity = vel;
                //Debug.Log(Input.GetKey(KeyCode.LeftArrow));
            }
            else
            {
                BallRB.linearVelocity = new Vector2(0, BallRB.linearVelocity.y);
            }
        }

        //Instantiate Rocket when collected
        if (RocketOn == true && RocketSpawn == false)
        {
            BallRocket = Instantiate(RocketPFB, new Vector2(transform.position.x, transform.position.y +1.5f), Quaternion.identity);
            RocketSpawn = true;
            //Debug.Log("rSpawn");
            
        }
        //Rocket aiming around ball
        if (RocketSpawn == true)
        {
            //Math for following mouse
            Vector3 FollowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = FollowMousePos - BallRocket.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            BallRocket.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            //Debug.Log(angle);

            //Follows Ball orbit via polar to cartesian conversion
            BallRocket.transform.position = new Vector2(
                transform.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad),
                transform.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad));

            //Rocket shot
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(RocketShot, BallRocket.transform.position, BallRocket.transform.rotation);
                Destroy(BallRocket);
                BallRocket = null;
                RocketSpawn = false;
                RocketOn = false;

            }
        }

        //Instantiate ColorWheel
        //if (ColorWOn == true && ColorWSpawn == false)
        {
                //BallColorW = Instantiate(ColorWPFB, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
                //ColorWSpawn = true;
                //Debug.Log("CwSpawn");
        }
        
        if (ColorWOn == true) 
        {
            BallRB.linearVelocity = Vector2.zero;
            GameObject.Find("Paddle").GetComponent<PaddleScript>().PFreeze = true;
            
            //Raw mouse position of entire screen
            Vector3 Rmouse = Input.mousePosition;
            //Since raw camera's plane is -10 in the Z direction, you add 10 to make it 0
            Rmouse.z = 10f;
            //Convert raw mouse position to relative to game world screen camera
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Rmouse);

            //The transform.position is (x2,y2), making sure it's at an origin 
            CWradius = (mousePos - transform.position).magnitude;
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // * converts radian to degree

            if (angle < 0)
            {
                angle += 360f;
            }
            //Debug.Log(radius);
            //Debug.Log(angle); 
            //Debug.Log(mousePos); 

            //cam color changer
            hue = angle / 360f; // will give a value from 0-1 for H
            saturation = CWradius / 10f; //will give me a value from 0-1 for S
            Camera.main.backgroundColor = Color.HSVToRGB(hue, saturation, 1f);
            Color newcolor = Color.HSVToRGB(hue, saturation, 1f);

            //mouse click destroy
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D mClick = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);
                if (mClick.collider != null && mClick.collider.gameObject.GetComponent<BrickScript>())
                {
                    mClick.collider.gameObject.GetComponent<BrickScript>().BrickDestruction();
                    GameObject.Find("Score").GetComponent<ScoreScript>().Score += 100;
                    ColorWOn = false;
                    //Destroy(BallColorW);  (NOT IN USE)
                    //BallColorW = null; 
                    GameObject.Find("Paddle").GetComponent<PaddleScript>().PFreeze = false;
                    BallRB.linearVelocity = new Vector2(0,Bspeed +10f); 
                }
            }
            ///if (Screen.width > 211 || Screen.height > 132)
            // {
            //    Color maxColor = newcolor;
            // }
            //Debug.Log(newcolor);
            //Debug.Log(saturation);
            //Debug.Log(hue);
            
            //Debug after the end math as it goes through it from top to bottom
            //atan by default returns -Pi to Pi (-180, +180) and we want all degrees of a circle so that is why
            //we +=360f
        }
    }
}