using System.Collections;
using System.Threading;
using UnityEngine;

public class CoroutineProvider : MonoBehaviour
{
    /// <summary>
    /// �O����A�����p���I�ȏ����̊J�n���w������B
    public Coroutine Run(string name, CancellationToken token)
    {
        return StartCoroutine(RunCoroutine(name, token));
    }

    private IEnumerator RunCoroutine(string name, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            // �����p�������c
            Debug.Log($"{name}: {Time.frameCount}");
            yield return null;
        }

        // ���ꂪ���s����邱�Ƃ��Ȃ�
        Debug.Log($"{name}���I�����܂���");
    }
}