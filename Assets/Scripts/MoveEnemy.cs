using UnityEngine;
using UnityEngine.AI; // NavMeshAgentを使用するために必要

public class MoveEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase
    };

    private NavMeshAgent agent; // NavMeshAgentの追加
    private Animator animator;
    private SetPosition setPosition;
    private float waitTime = 5f;
    private float elapsedTime;
    private EnemyState state;
    private Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgentの取得
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Walk:
                agent.SetDestination(setPosition.GetDestination());
                if (agent.remainingDistance < 0.5f)
                {
                    SetState(EnemyState.Wait);
                }
                break;

            case EnemyState.Chase:
                agent.SetDestination(playerTransform.position);
                break;

            case EnemyState.Wait:
                elapsedTime += Time.deltaTime;
                if (elapsedTime > waitTime)
                {
                    SetState(EnemyState.Walk);
                }
                break;
        }
        //animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void SetState(EnemyState tempState, Transform targetObj = null)
    {//Stateを設定する
        state = tempState;
        switch (tempState)
        {
            case EnemyState.Walk:
                setPosition.CreateRandomPosition();
                agent.SetDestination(setPosition.GetDestination());
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsChasing", false);
                break;

            case EnemyState.Chase:
                playerTransform = targetObj;
                agent.SetDestination(playerTransform.position);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsChasing", true);
                break;

            case EnemyState.Wait:
                agent.ResetPath();
                elapsedTime = 0f;
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsChasing", false);
                break;
        }
    }


    public EnemyState GetState()
    {
        return state;
    }
}
