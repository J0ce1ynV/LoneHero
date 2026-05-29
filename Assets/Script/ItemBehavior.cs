using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior GameManager;

    private bool collected = false;

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collected) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            collected = true;

            Debug.Log("Item collected!");

            if (GameManager != null)
            {
                GameManager.Items += 1;
            }

            Destroy(gameObject);
        }
    }
}

/*
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior GameManager;
    
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected!");

            if(GameManager != null)
            {
                GameManager.Items += 1;
            }
        }
    }
}
*/