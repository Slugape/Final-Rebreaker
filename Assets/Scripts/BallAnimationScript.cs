using UnityEngine;

public class BallAnimationScript : MonoBehaviour

{

    public SpriteRenderer BallSpriteSheet;
    public Sprite[] BallAnim;
    float StartTimer1 = 0f;
    float StartTimer2 = 0f;
    private float DurationTimer1 = 1.1f;
    private float DurationTimer2 = 1.1f;
    private int SpaceCounter = 4;
    private bool SpaceActive = false;

    private float SpaceTimer = 0f;
    private float SpaceTDuration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartTimer1 += Time.deltaTime;
            Debug.Log("on");
            if (StartTimer1 < DurationTimer1)
            {
                BallSpriteSheet.sprite = BallAnim[1];
            }
            else if (StartTimer1 >= DurationTimer1)
            {
                BallSpriteSheet.sprite = BallAnim[2];
            }
            Debug.Log("2nd animation!");
            StartTimer2 = 0;
            SpaceCounter = 4;
            SpaceActive = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartTimer2 += Time.deltaTime;
            // Debug.Log("on");
            if (StartTimer2 < DurationTimer2)
            {
                BallSpriteSheet.sprite = BallAnim[3];
            }
            else if (StartTimer2 >= DurationTimer2)
            {
                BallSpriteSheet.sprite = BallAnim[4];
            }
            //Debug.Log("2nd animation!");
            StartTimer1 = 0;
            SpaceCounter = 4;
            SpaceActive = false;
        }
        else
        {
            Debug.Log("Reset");
            StartTimer1 = 0f;
            StartTimer2 = 0f;
            if (SpaceActive == false)
            {
                BallSpriteSheet.sprite = BallAnim[0];
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceActive = true;
            SpaceCounter++;
            if (SpaceCounter > 7)
            {
                SpaceCounter = 5;
            }
            SpaceTimer = 0f;
            BallSpriteSheet.sprite = BallAnim[SpaceCounter];
        }

        if (SpaceActive == true)
        {
            SpaceTimer += Time.deltaTime;
            if (SpaceTimer > SpaceTDuration)
            {
                SpaceTimer = 0f;
                SpaceCounter = 4;
                SpaceActive = false;
                BallSpriteSheet.sprite = BallAnim[0];
            }
        }
    } 
}
