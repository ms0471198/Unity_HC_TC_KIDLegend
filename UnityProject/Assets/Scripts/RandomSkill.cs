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

        private AudioSource aud;            // 喇叭
        private Image imgSkill;             // 圖片
        private Button btn;                 // 按鈕

        private void Start()
        {
            aud = GetComponent<AudioSource>();  // 取得元件<喇叭>
            imgSkill = GetComponent<Image>();   // 取得元件<圖片>
            btn = GetComponent<Button>();       // 取得元件<按鈕>

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
                    aud.PlayOneShot(soundScroll, 0.5f);     // 播放一次(音效，音量)
                    imgSkill.sprite = spritesBlur[i];
                    yield return new WaitForSeconds(speed);
                }
            }

            // 捲動結束後
            btn.interactable = true;
            int r = Random.Range(0, spritesSkill.Length);   // 隨機選一張技能 1 - 8 張
            imgSkill.sprite = spritesSkill[r];              // 圖片 = 技能[隨機值]
            aud.PlayOneShot(soundSkill, 0.5f);
        }
    }
}

