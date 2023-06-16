using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            //Destroy(other.gameObject); // Coin siliniyor
            other.gameObject.SetActive(false);
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();

    }
}
