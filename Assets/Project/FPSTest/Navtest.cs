using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;�@//�@������𑫂��Ă����Ȃ��Ɠ����Ȃ��̂ŕK�{�ł��B

public class Navtest : MonoBehaviour
{

    public GameObject goal; �@//�A���ړI�n�ɂȂ�I�u�W�F�N�g���擾���邽�߂̕ϐ�
    public NavMeshAgent agent;�@//�B�R���|�[�l���g�擾�p�̕ϐ�

    // Use this for initialization
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();�@//�B�R���|�[�l���g�̎擾
        //goal = GameObject.Find("Player");�@//�A�����ŖړI�n���擾
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.transform.position;�@//�C�����ŖړI�n��ݒ�
    }
}