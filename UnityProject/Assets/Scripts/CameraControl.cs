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

    private void Start()
    {
        player = GameObject.Find("玩家").transform;
    }

    // 延後更新：在 Update 之後執行
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 追蹤玩家座標方法
    /// </summary>
    private void Track()
    {
        
    }
}
