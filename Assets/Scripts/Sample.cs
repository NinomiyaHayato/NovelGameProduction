using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField]
    private float _duration = 1F; // アニメーション時間（秒単位）

    [SerializeField]
    private Color _from = Color.clear; // この色からフェード処理する

    [SerializeField]
    private Color _to = Color.white; // この色に向かってフェード処理する

    [SerializeField] private int _count = 5;

    IEnumerator Start()
    {
        Image[] images = new Image[_count];
        // Image コンポーネントを持つオブジェクトを生成
        for (int i = 0; i < _count; i++)
        {
            var obj = new GameObject("Image");
            obj.transform.parent = transform;
            var image = obj.AddComponent<Image>();
            images[i] = image;
            images[i].color = _from;
        }
        for (int i = 0; i < _count; i++)
        {
            yield return StartCoroutine(FadeAsync(images[i]));
        }
    }
    private IEnumerator FadeAsync(Image image)
    {
        var t = 0F;
        image.color = _from; // 開始色で初期化
        while (t < _duration)
        {
            t += Time.deltaTime; // 経過時間
            var p = t / _duration; // 進捗率
            image.color = _from + ((_to - _from) * p); // 線形補間
            // image.color = Color.Lerp(_from, _to, p); // これも同じ
            yield return null;
        }
        image.color = _to; // 終了色
    }
}