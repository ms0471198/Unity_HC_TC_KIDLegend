using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public Vector3 a = new Vector3(0, 0, 0);
    public Vector3 b = new Vector3(0, 0, 100);

    public float f = 0.5f;

    private void Start()
    {
        // 三維向量.插值(A，B，百分比)
        Vector3 result = Vector3.Lerp(a, b, f);

        print(result);
    }
}
