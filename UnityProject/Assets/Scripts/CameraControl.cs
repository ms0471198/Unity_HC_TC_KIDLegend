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
        Vector3 posPlayer = player.position;                    // 玩家.座標
        Vector3 posCamera = transform.position;                 // 攝影機.座標

        posPlayer.x = 0;                                        // 取得的 玩家座標.x = 0
        posPlayer.z = Mathf.Clamp(posPlayer.z, top, bottom);    // 取得的 玩家座標.z 夾住在 上方限制 與 下方限制 之間

        transform.position = Vector3.Lerp(posCamera, posPlayer, 0.5f * Time.deltaTime * speed);
    }
}
