using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Ball_One_ControllerScript : MonoBehaviour
{
    public Rigidbody ball;
    public float speed = 6.0F;
    public int jumpForce = 10;
    public static int PlayerOneScore = 0;
    public Text playerOneText;
    public Text winText;
    public Text timerText;
    public static int TotalObject = 195;
    public static bool gameEnd = false;

    public float allowedTime = 90.0f;

    void Start()
    {

        ball = GetComponent<Rigidbody>();
        playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
        winText.text = "";

        int time = (int)allowedTime;

        int sec = time % 60;
        int min = time / 60;

        timerText.text = min.ToString() + ":" + sec.ToString();
    }

    void Update()
    {
        if (gameEnd)
            return;

        if (allowedTime > 0 && PlayButtonClick.play)
            allowedTime -= Time.deltaTime;

        int time = (int)allowedTime;

        int sec = time % 60;
        int min = time / 60;

        if (sec > 9)
            timerText.text = min.ToString() + ":" + sec.ToString();
        else
            timerText.text = min.ToString() + ":0" + sec.ToString();

        if (allowedTime < 0)
            checkWinner();
    }

    void FixedUpdate()
    {
        if (gameEnd)
            return;

        if (!PlayButtonClick.play)
        {
            winText.text = "Paused";
            return;
        }
        else
        {
            winText.text = "";
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            moveDirection.x = -5 * speed;
        if (Input.GetKey(KeyCode.D))
            moveDirection.x = 5 * speed;
        if (Input.GetKey(KeyCode.W))
            moveDirection.z = 5 * speed;
        if (Input.GetKey(KeyCode.S))
            moveDirection.z = -5 * speed;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 position = transform.position;

            if (position.y <= 1.2f)
            {
                moveDirection.y = jumpForce;
                //Debug.Log("jump" + position);
            }
        }
        ball.AddForce(moveDirection);

        checkWinner();
    }

    void checkWinner()
    {
        if (TotalObject <= 0)
        {
            if (PlayerOneScore > Ball_Two_ControllerScript.PlayerTwoScore)
                winText.text = "Player 1 won the game";
            else if (PlayerOneScore < Ball_Two_ControllerScript.PlayerTwoScore)
                winText.text = "Player 2 won the game";
            else
                winText.text = "Game Draw";
            gameEnd = true;
        }
        else if (allowedTime <= 0)
        {
            if (PlayerOneScore > Ball_Two_ControllerScript.PlayerTwoScore)
                winText.text = "Player 1 won the game";
            else if (PlayerOneScore < Ball_Two_ControllerScript.PlayerTwoScore)
                winText.text = "Player 2 won the game";
            else if (PlayerOneScore == Ball_Two_ControllerScript.PlayerTwoScore)
                winText.text = "Game Draw";
            else
                winText.text = "Time Out";
            gameEnd = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            PlayerOneScore += 25;
            TotalObject--;
            playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
        }
        else if (other.gameObject.CompareTag("Crystal"))
        {
            other.gameObject.SetActive(false);
            PlayerOneScore += 50;
            TotalObject--;
            playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            other.gameObject.SetActive(false);
            PlayerOneScore += 500;
            TotalObject--;
            playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
        }
        /*if (other.gameObject.CompareTag("Player"))
        {
            float velocity1 = ball.velocity.magnitude;
            float velocity2 = other.attachedRigidbody.velocity.magnitude;
           
            if (velocity1 > velocity2)
            {
                PlayerOneScore -= 10;
                playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
            }
            else
            {
                Ball_Two_ControllerScript.PlayerTwoScore -= 10;
                //     Ball_Two_ControllerScript.playerTwoText.text = "Player 2 : " + Ball_Two_ControllerScript.PlayerTwoScore.ToString();
            }
        }*/
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        float velocity2 = collisionInfo.rigidbody.velocity.magnitude;
        float velocity1 = ball.velocity.magnitude;

        Debug.Log("p1 velocity1 " + velocity1);
        Debug.Log("p1 velocity2 " + velocity2);

        if (velocity1 > velocity2)
        {
            Ball_One_ControllerScript.PlayerOneScore -= 10;
            playerOneText.text = "Player 1 : " + Ball_One_ControllerScript.PlayerOneScore.ToString();
        }
        else
        {
            Ball_Two_ControllerScript.PlayerTwoScore -= 10;
            //playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
        }
    }
}

/*void OnCollisionEnter(Collision collision)
    {
        float velocity2 = collision.collider.attachedRigidbody.velocity.magnitude;
        float velocity1 = ball.velocity.magnitude;


        Debug.Log("velocity1 " + velocity1);
        Debug.Log("velocity2 " + velocity2);
        /*{
            PlayerOneScore -= 100;
            playerOneText.text = "Player 1 : " + PlayerOneScore.ToString();
        }
        else
        {
            Ball_Two_ControllerScript.PlayerTwoScore -= 100;
            //     Ball_Two_ControllerScript.playerTwoText.text = "Player 2 : " + Ball_Two_ControllerScript.PlayerTwoScore.ToString();
        }
    }*/
