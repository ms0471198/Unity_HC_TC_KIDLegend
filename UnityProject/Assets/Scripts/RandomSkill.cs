using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace KID
{
    public class RandomSkill : MonoBehaviour
    {
        [Header("圖片區域")]
        public Sprite[] spritesBlur;        // 陣列 模糊 Sprite 16
        public Sprite[] spritesSkill;       // 陣列 正常 Sprite 8
        [Header("速度"), Range(0.01f, 1f)]
        public float speed = 0.2f;
        [Header("模糊圖片執行次數"), Range(1, 30)]
        public int count = 3;

        public AudioClip soundScroll;       // 捲動音效
        public AudioClip soundSkill;        // 技能音效

        private string[] namesSkill = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量增加", "攻擊增加", "攻速增加", "爆擊增加" };
        private AudioSource aud;            // 喇叭
        private Image imgSkill;             // 圖片
        private Button btn;                 // 按鈕
        private Text textName;              // 文字
        private GameObject skillPanel;      // 隨機技能面板
        private int index;                  // 儲存隨機編號

        private void Start()
        {
            aud = GetComponent<AudioSource>();  // 取得元件<喇叭>
            imgSkill = GetComponent<Image>();   // 取得元件<圖片>
            btn = GetComponent<Button>();       // 取得元件<按鈕>
            textName = transform.GetChild(0).GetComponent<Text>();  // 變形.取得子物件(編號).取得元件<>
            skillPanel = GameObject.Find("隨機技能");                // 尋找("隨機技能")

            btn.onClick.AddListener(ChooseSkill);                   // 按鈕.點擊.增加監聽者(方法)

            StartCoroutine(RandomEffect());
        }

        private IEnumerator RandomEffect()
        {
            btn.interactable = false;

            // 連續變更圖片 1 - 16 張：捲動效果
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < spritesBlur.Length; i++)
                {
                    aud.PlayOneShot(soundScroll, 0.1f);     // 播放一次(音效，音量)
                    imgSkill.sprite = spritesBlur[i];
                    yield return new WaitForSeconds(speed);
                }
            }

            // 捲動結束後
            btn.interactable = true;
            index = Random.Range(0, spritesSkill.Length);   // 隨機選一張技能 1 - 8 張
            imgSkill.sprite = spritesSkill[index];              // 圖片 = 技能[隨機值]
            aud.PlayOneShot(soundSkill, 0.5f);
            textName.text = namesSkill[index];                  // 文字 = 技能名稱[隨機值]
        }

        private void ChooseSkill()
        {
            skillPanel.SetActive(false);    // 技能面板隱藏
            print(namesSkill[index]);       // 技能名稱
        }
    }
}
