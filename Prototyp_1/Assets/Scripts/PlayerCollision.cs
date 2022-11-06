using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public Transform startingPosition;
    public TextMeshProUGUI coinText;
    int numberOfCoins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            ResetPosition();
        }
        else if (collision.tag == "Coin")
        {
            numberOfCoins++;
            coinText.text = "x" + numberOfCoins;
            Destroy(collision.gameObject);
        }
    }

    public void ResetPosition()
    {
        transform.position = startingPosition.position;
    }


}

