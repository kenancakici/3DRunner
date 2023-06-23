using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    Vector3  PlayerStartPos;
    public GameObject speedBoosterIcon;
    //private InGameRanking ig;

    private void Start()
    {
        PlayerStartPos = new Vector3( transform.position.x,transform.position.y,transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            //Destroy(other.gameObject); // Coin siliniyor
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Bravoooo Baþardýn....!!!");
            PlayerFinished();



        }

        if (other.CompareTag("speedboost"))
        {
            playerController.runningSpeed = playerController.runningSpeed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterWhileContinue());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Çarpýþma oldu.....");
            transform.position = PlayerStartPos;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private IEnumerator SlowAfterWhileContinue()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }

    void PlayerFinished()
    {
        playerController.runningSpeed = 0f;
        transform.Rotate(transform.rotation.x, 180, transform.rotation.y, Space.Self);
    }


    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();

    }
}
