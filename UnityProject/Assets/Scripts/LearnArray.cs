using UnityEngine;

public class LearnArray : MonoBehaviour
{
    public int pA = 10;
    public int pB = 20;
    public int pC = 30;

    // 陣列：類型[]
    public int[] players;
    public float[] speeds;
    public bool[] missions;
    public Color[] colors;

    // 指定預設值
    public string[] names = new string[5];              // 指定五個空值
    public string[] animals = { "Dog", "Cat", "Bird" };

    private void Start()
    {
        // 取得陣列資料 陣列名稱[索引值]
        print(animals[1]);
        // 存放陣列資料 陣列名稱[索引值] = 值
        animals[2] = "Mouse";

        // 陣列.長度(數量)
        print(animals.Length);
    }
}
