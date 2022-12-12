using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float roundTimer = 15;

    public float countdownTimer = 3.0f;
    public static bool startCountdown = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countdowntext;

    public Canvas overlayCanvas;

    public TextMeshProUGUI coinText;

    int room = 0;

    public bool timerActivated = true;

    public GameObject enemy;

    void Update()
    {
        if (startCountdown)
        {
            countdowntext.text = "Respawning in: " + ((int)countdownTimer).ToString();
            countdownTimer -= Time.deltaTime;

            if(countdownTimer < 0)
            {
                startCountdown = false;
                PlayerController.canMove = true;
                overlayCanvas.gameObject.SetActive(false);
                countdownTimer += 3;
            }
        }
        
        //Om man avndänder timern
        if(timerActivated)
        {
            if (roundTimer < 0.0f)
            {          
                NextRound();
            }

            if (!startCountdown)
            {
                
                roundTimer -= Time.deltaTime;
                timerText.text = ((int)roundTimer).ToString();               
            }
        }
        else
        {
            timerText.SetText("");
            roundTimer = 999;
            enemy.SetActive(true);
        }

        room = GameManager.room;
    }

    public void NextRound()
    {
        if (room != 0)
        {
            PlayerCollision.numberOfCoins -= 3;
            coinText.text = "x" + PlayerCollision.numberOfCoins;
        }
        room++;
        FindObjectOfType<GameManager>().RespawnPlayer();
        FindObjectOfType<CameraMovement>().MoveCameraForward();
        PlayerController.canMove = false;
        overlayCanvas.gameObject.SetActive(true);
        startCountdown = true;
        timerText.text = "";
        AddTime();
    }

    void AddTime()
    {
        switch (room)
        {
            case 0:
                Timer.roundTimer = 10;
                return;
            case 1:
                Timer.roundTimer = 12;
                return;
            case 2:
                Timer.roundTimer = 11;
                return;
            case 3:
                Timer.roundTimer = 14;
                return;
            case 4:
                Timer.roundTimer = 17;
                return;
            case 5:
                Timer.roundTimer = 14;
                return;
            case 6:
                Timer.roundTimer = 22;
                return;
            case 7:
                Timer.roundTimer = 999;
                return;
        }
    }
}
