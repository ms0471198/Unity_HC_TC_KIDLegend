using UnityEngine;
using System.Collections;   // 引用 系統.集合 API

public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());     // 啟動協程(協程名稱());
    }

    private IEnumerator Test()
    {
        print("遊戲開始!");

        yield return new WaitForSeconds(3); // 等待(秒數)

        print("三秒過後!");

        yield return new WaitForSeconds(3); // 等待(秒數)

        print("再三秒過後!");
    }

    public Transform knight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Big());
        }
    }

    private IEnumerator Big()
    {
        for (int i = 0; i < 10; i++)
        {
            knight.localScale += Vector3.one * 0.5f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
