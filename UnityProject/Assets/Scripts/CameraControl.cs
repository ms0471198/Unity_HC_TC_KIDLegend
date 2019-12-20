using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region 欄位
    private Transform player;

    [Header("跟蹤速度"), Range(0, 10)]
    public float speed = 1.5f;
    [Header("上方限制"), Tooltip("")]
    public float top = -10;
    [Header("下方限制"), Tooltip("")]
    public float bottom = 5;
    #endregion
}
