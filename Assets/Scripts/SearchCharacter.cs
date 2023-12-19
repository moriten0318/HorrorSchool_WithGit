using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SearchCharacter : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
    }

    void OnTriggerStay(Collider col)
    {
        //�@�v���C���[�L�����N�^�[�𔭌�
        if (col.tag == "Player")
        {
            //�@�G�L�����N�^�[�̏�Ԃ��擾
            MoveEnemy.EnemyState state = moveEnemy.GetState();
            //�@�G�L�����N�^�[���ǂ��������ԂłȂ���Βǂ�������ݒ�ɕύX
            if (state != MoveEnemy.EnemyState.Chase)
            {
                Debug.Log("�v���C���[����");
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }
}