using System.Drawing;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("生成敵人")]
    public GameObject enemy;
    [Header("生成點")]
    public Transform[] points;
    [Header("間隔時間")]
    public float time = 2.5f;
    [Header("每次降低多少時間")]
    public float timeToSub = 0.05f;


    public void Spawn()
    {
        int r = Random.Range(0, points.Length);
        Instantiate(enemy, points[r]);
        Invoke("Spawn", time);
        time -= timeToSub;
        time = Mathf.Clamp(time, 0.5f, 10f);
    }
}
