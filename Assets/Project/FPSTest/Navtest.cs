using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;　//①←これを足しておかないと動かないので必須です。

public class Navtest : MonoBehaviour
{

    public GameObject goal; 　//②←目的地になるオブジェクトを取得するための変数
    public NavMeshAgent agent;　//③コンポーネント取得用の変数

    // Use this for initialization
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();　//③コンポーネントの取得
        //goal = GameObject.Find("Player");　//②ここで目的地を取得
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.transform.position;　//④ここで目的地を設定
    }
}