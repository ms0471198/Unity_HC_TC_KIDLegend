using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    public string[] names = { "KID", "TOM", "PETER" };

    public GameObject[] player;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        // 條件成立時執行一次
        if (true)
        {

        }

        int count = 0;

        // while 迴圈
        // while (布林值) { 敘述 }
        // 條件成立時執行持續執行
        while (count < 5)
        {
            count++;
            print("while 迴圈執行：" + count);
        }

        // for 迴圈
        // (初始值；條件；跌代器)
        for (int number = 0; number < 5; number++)
        {
            print("for 迴圈執行：" + number);
        }

        for (int number = 0; number < names.Length; number++)
        {
            print(names[number]);
        }
    }
}
