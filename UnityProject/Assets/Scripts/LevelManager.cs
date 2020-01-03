using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    // GameObject.Find("物件名稱") - 找不到隱藏物件
    [Header("物件：光照與隨機技能")]
    public GameObject objLight;
    public GameObject randomSkill;

    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDool;

    private Animator door;
    private Image imgCross;

    private void Start()
    {
        door = GameObject.Find("木頭門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        if (autoShowSkill) ShowSkill();
        if (autoOpenDool) Invoke("OpenDoor", 6);    // 延遲調用(方法，延遲時間)
    }

    private void ShowSkill()
    {
        randomSkill.SetActive(true);
    }

    private void OpenDoor()
    {
        objLight.SetActive(true);
        door.SetTrigger("開門觸發");
    }

    public IEnumerator NextLevel()
    {
        print("載入下一關");

        // 迴圈 for while
        // 0.01 透明度 + 0.01
        imgCross.color += new Color(1, 1, 1, 0.01f);
        yield return new WaitForSeconds(0.01f);
    }
}
