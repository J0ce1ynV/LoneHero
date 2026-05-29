using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour
{
    private GameBehavior gameManager;
    private int enemyLives = 3;

    private UnityEngine.AI.NavMeshAgent _agent;
    public Transform PatrolRoute;
    private List<Transform> _locations = new List<Transform>();
    private Transform _player;

    private int _locationIndex = 0;

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
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        _player = GameObject.Find("Player").transform;

        if (PatrolRoute != null)
        {
            foreach (Transform child in PatrolRoute)
            {
                _locations.Add(child);
            }
        }

        if (_locations.Count > 0)
        {
            MoveToNextPatrolLocation();
        }
    }

    void Update()
    {
        if (_locations.Count > 0 && _agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }


    void MoveToNextPatrolLocation()
    {
        if (_locations.Count == 0) return;

        _agent.destination = _locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % _locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");

            if (gameManager != null)
            {
                gameManager.HP = gameManager.HP - 2;
                Debug.Log("Player HP: " + gameManager.HP);
            }

            if (_agent != null && _player != null)
            {
                _agent.destination = _player.position;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");

            if (_locations.Count > 0)
            {
                MoveToNextPatrolLocation();
            }

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