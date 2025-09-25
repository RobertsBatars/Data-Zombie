using Pathfinding;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    private Transform player;
    private AIPath ai;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ai = GetComponent<AIPath>();
        ai.maxSpeed = speed;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePath()
    {
        ai.destination = player.position;
    }
}
