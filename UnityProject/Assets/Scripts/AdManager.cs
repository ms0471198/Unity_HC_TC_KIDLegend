using UnityEngine;
using UnityEngine.Advertisements;   // 引用廣告 API

public class AdManager : MonoBehaviour
{
    private string googlePlay = "3457913";

    private void Start()
    {
        // 廣告.初始化(廣告服務 ID，啟動測試模式)
        Advertisement.Initialize(googlePlay, true);
    }
}
