using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField]
    private float _duration = 1F; // �A�j���[�V�������ԁi�b�P�ʁj

    [SerializeField]
    private Color _from = Color.clear; // ���̐F����t�F�[�h��������

    [SerializeField]
    private Color _to = Color.white; // ���̐F�Ɍ������ăt�F�[�h��������

    [SerializeField] private int _count = 5;

    IEnumerator Start()
    {
        Image[] images = new Image[_count];
        // Image �R���|�[�l���g�����I�u�W�F�N�g�𐶐�
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
        image.color = _from; // �J�n�F�ŏ�����
        while (t < _duration)
        {
            t += Time.deltaTime; // �o�ߎ���
            var p = t / _duration; // �i����
            image.color = _from + ((_to - _from) * p); // ���`���
            // image.color = Color.Lerp(_from, _to, p); // ���������
            yield return null;
        }
        image.color = _to; // �I���F
    }
}