using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CoroutineProvider : MonoBehaviour
{
    /// <summary>
    /// �O����A�����p���I�ȏ����̊J�n���w������B
    public Task<int> RunAsync(string name, CancellationToken token)
    {
        var tcs = new TaskCompletionSource<int>();
        StartCoroutine(RunCoroutine(name, token, tcs));
        return tcs.Task;
    }

    private IEnumerator RunCoroutine(string name, CancellationToken token, TaskCompletionSource<int> tcs)
    {
        var elased = 0F;
        while (!token.IsCancellationRequested && elased < 5)
        {
            // �����p�������c
            elased += Time.deltaTime;
            Debug.Log($"{name}: {Time.frameCount}");
            yield return null;
        }

        Debug.Log($"{name}���I�����܂���");

        // �������ʂ�Ԃ�����
        tcs.SetResult(Time.frameCount);

    }
}