using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameBehavior gameManager;

    private int enemyLives = 3;
    public int EnemyLives
    {
        get { return enemyLives; }
        private set
        {
            enemyLives = value;
            if (enemyLives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down");
            }
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");

            if (gameManager != null)
            {
                gameManager.HP -= 2;
                Debug.Log("Player HP: " + gameManager.HP);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit! Enemy lives:" + enemyLives);
        }
    }
}