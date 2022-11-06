using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public Transform startingPosition;

    public Transform enemyPosition;

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
        else if (collision.tag == "FinnishLine")
        {
            FindObjectOfType<CameraMovement>().MoveCamera();

            //enemyPosition.position = new Vector2(transform.position.x + 3, 0);
        }
    }

    public void ResetPosition()
    {
        transform.position = startingPosition.position;
    }
}

