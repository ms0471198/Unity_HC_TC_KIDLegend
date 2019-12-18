using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody rig;

    public float speed = 10;

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
        float v = joystick.Vertical;        // 垂直
        float h = joystick.Horizontal;      // 水平

        rig.AddForce(-h * speed, 0, -v * speed);    // 推力(-水平，0，-垂直)
    }
}
