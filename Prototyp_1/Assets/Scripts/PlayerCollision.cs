using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public static int numberOfCoins = 0;

    public Canvas overlayCanvas;

    public TextMeshProUGUI timerText;

    public Transform enemyPosition;

    public float enemySpawnDistance = 4;

    int room = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            FindObjectOfType<GameManager>().RespawnPlayer();
            FindObjectOfType<CameraMovement>().MoveCameraForward();
            PlayerController.canMove = false;
            overlayCanvas.gameObject.SetActive(true);
            Timer.startCountdown = true;
            timerText.text = "";
            if (room != 0)
            {
                numberOfCoins -= 3;
                coinText.text = "x" + numberOfCoins;
            }
            AddTime();
        }
        else if (collision.tag == "Coin")
        {
            numberOfCoins++;
            coinText.text = "x" + numberOfCoins;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "FinnishLine")
        {
            GameManager.room++;

            FindObjectOfType<CameraMovement>().MoveCameraForward();

            enemyPosition.position = new Vector2(transform.position.x + enemySpawnDistance, transform.position.y);

            room++;
            AddTime();
        }
    }

    void AddTime()
    {
        switch (room)
        {
            case 0:
                Timer.roundTimer = 100;
                return;
            case 1:
                Timer.roundTimer = 100;
                return;
            case 2:
                Timer.roundTimer = 100;
                return;
            case 3:
                Timer.roundTimer = 100;
                return;
            case 4:
                Timer.roundTimer = 100;
                return;
            case 5:
                Timer.roundTimer = 100;
                return;
            case 6:
                Timer.roundTimer = 100;
                return;
            case 7:
                Timer.roundTimer = 999;
                return;
        }
    }
}

