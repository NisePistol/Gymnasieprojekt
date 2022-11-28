using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;

    float distance;
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
