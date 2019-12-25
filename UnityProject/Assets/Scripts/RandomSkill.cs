using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace KID
{
    public class RandomSkill : MonoBehaviour
    {
        [Header("圖片區域")]
        // 陣列 模糊 Sprite 16
        public Sprite[] spritesBlur;
        // 陣列 正常 Sprite 8
        public Sprite[] spritesSkill;

        public Image imgSkill;

        [Header("速度"), Range(0.01f, 1f)]
        public float speed = 0.2f;

        private void Start()
        {
            StartCoroutine(RandomEffect());
        }

        // 連續變更圖片 1 - 16 張：捲動效果
        private IEnumerator RandomEffect()
        {
            for (int i = 0; i < spritesBlur.Length; i++)
            {
                imgSkill.sprite = spritesBlur[i];
                yield return new WaitForSeconds(speed);
            }
        }

        // 捲動結束後

        // 隨機選一張技能 1 - 8 張
    }
}

