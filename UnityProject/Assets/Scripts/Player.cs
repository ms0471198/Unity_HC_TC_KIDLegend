using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(1, 300)]
    public float speed = 10;

    private Joystick joystick;  // 虛擬搖桿類別
    private Rigidbody rig;      // 剛體

    private void Start()
    {
        rig = GetComponent<Rigidbody>();                                    // 取得元件<泛型>() (取得相同屬性面板)
        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();     // 遊戲物件.尋找("物件名稱").取得元件<泛型>()
    }

    // 固定更新：一秒 50 次 - 控制物理
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;                // 垂直
        float h = joystick.Horizontal;              // 水平

        rig.AddForce(-h * speed, 0, -v * speed);    // 推力(-水平，0，-垂直)
    }
}
