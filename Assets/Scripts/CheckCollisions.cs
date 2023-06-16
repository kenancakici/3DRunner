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
            playerController.runningSpeed = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Çarpýþma oldu.....");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }





    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();

    }
}
