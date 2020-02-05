using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(1, 300)]
    public float speed = 10;
    [Header("玩家資料")]
    public PlayerData data;

    private Joystick joystick;              // 虛擬搖桿類別
    private Rigidbody rig;                  // 剛體
    private Animator ani;                   // 動畫控制器
    private Transform target;               // 目標
    private LevelManager levelManager;      // 關卡管理器
    private HpValueManager hpDamManager;    // 血量數值管理器

    private void Start()
    {
        rig = GetComponent<Rigidbody>();                                    // 取得元件<泛型>() (取得相同屬性面板)
        ani = GetComponent<Animator>();
        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();    // 遊戲物件.尋找("物件名稱").取得元件<泛型>()

        // target = GameObject.Find("目標").GetComponent<Transform>();       // 原本寫法
        target = GameObject.Find("目標").transform;                          // 簡寫 - GetComponent<Transform>() 可以直接寫成 transform
        //levelManager = GameObject.Find("遊戲管理器").GetComponent<LevelManager>();
        levelManager = FindObjectOfType<LevelManager>();                    // 僅限於一個
        hpDamManager = GetComponentInChildren<HpValueManager>();            // 取得子物件的元件 (僅限於子物件內只有一個)
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送區域")
        {
            //levelManager.NextLevel();
            levelManager.StartCoroutine("NextLevel");
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;                // 垂直
        float h = joystick.Horizontal;              // 水平

        rig.AddForce(-h * speed, 0, -v * speed);    // 推力(-水平，0，-垂直)

        ani.SetBool("跑步開關", v != 0 || h != 0);  // 動畫控制器.設定布林值("參數"，垂直不等於 0 或者 水平不等於 0)

        Vector3 posPlayer = transform.position;                                         // 玩家座標 = 玩家.座標
        Vector3 posTarget = new Vector3(posPlayer.x - h, 0.26f, posPlayer.z - v);       // 目標座標 = 新 三維向量(玩家座標.X - 水平，0.26f，玩家座標.Z - 垂直)
        target.position = posTarget;    // 目標物件.座標 = 計算後的座標
        posTarget.y = posPlayer.y;      // 目標 Y = 玩家 Y (避免吃土)
        transform.LookAt(posTarget);    // 看著(目標座標)
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收傷害值</param>
    public void Hit(float damage)
    {
        data.hp -= damage;
        hpDamManager.UpdateHpBar(data.hp, data.hpMax);

        // 啟動協程(血量傷害值管理器.顯示數值(傷害值，-，1，白色))
        StartCoroutine(hpDamManager.ShowValue(damage, "-", Vector3.one, Color.white));

        if (data.hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);                   // 死亡動畫
        enabled = false;                                // 取消此類別運作

        StartCoroutine(levelManager.ShowRevival());     // 啟動協程(關卡管理器.顯示復活介面())
    }
}
