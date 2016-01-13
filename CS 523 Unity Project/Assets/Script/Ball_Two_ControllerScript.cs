using UnityEngine;
using UnityEngine.UI;

public class Ball_Two_ControllerScript : MonoBehaviour
{
    public Rigidbody ball;
    public float speed = 6.0F;
    public int jumpForce = 10;
    public static int PlayerTwoScore = 0;
    public Text playerTwoText;

    void Start()
    {
        if (Ball_One_ControllerScript.gameEnd)
        {
            return;
        }
        ball = GetComponent<Rigidbody>();
        playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
    }

    void FixedUpdate()
    {
        if (Ball_One_ControllerScript.gameEnd)
        {
            return;
        }
        if (!PlayButtonClick.play)
        {
            return;
        }
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection.x = -5 * speed;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection.x = 5 * speed;
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirection.z = 5 * speed;
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirection.z = -5 * speed;
        if (Input.GetKey(KeyCode.PageUp))
        {
            Vector3 position = transform.position;

            if (position.y <= 1.2f)
            {
                moveDirection.y = jumpForce;
                //Debug.Log("jump" + position);
            }
        }
        ball.AddForce(moveDirection);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            PlayerTwoScore += 25;
            Ball_One_ControllerScript.TotalObject--;
            playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
        }
        else if (other.gameObject.CompareTag("Crystal"))
        {
            other.gameObject.SetActive(false);
            PlayerTwoScore += 50;
            Ball_One_ControllerScript.TotalObject--;
            playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            other.gameObject.SetActive(false);
            PlayerTwoScore += 500;
            Ball_One_ControllerScript.TotalObject--;
            playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
        }
        /*if (other.gameObject.CompareTag("Player"))
        {
            float velocity2 = ball.velocity.magnitude;
            float velocity1 = other.attachedRigidbody.velocity.magnitude;

            if (velocity1 > velocity2)
            {
                Ball_One_ControllerScript.PlayerOneScore -= 10;
                //     Ball_One_ControllerScript.playerOneText.text = "Player 1 : " + Ball_One_ControllerScript.PlayerOneScore.ToString();
            }
            else
            {
                Ball_Two_ControllerScript.PlayerTwoScore -= 10;
                //   Ball_Two_ControllerScript.playerTwoText.text = "Player 2 : " + Ball_Two_ControllerScript.PlayerTwoScore.ToString();
            }
        }*/
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        float velocity1 = collisionInfo.rigidbody.velocity.magnitude;
        float velocity2 = ball.velocity.magnitude;

        Debug.Log("p2 velocity1 " + velocity1);
        Debug.Log("p2 velocity2 " + velocity2);

        if (velocity1 > velocity2)
        {
            Ball_One_ControllerScript.PlayerOneScore -= 10;
            //Ball_One_ControllerScript.playerOneText.text = "Player 1 : " + Ball_One_ControllerScript.PlayerOneScore.ToString();
        }
        else
        {
            Ball_Two_ControllerScript.PlayerTwoScore -= 10;
            playerTwoText.text = "Player 2 : " + PlayerTwoScore.ToString();
        }
    }

}