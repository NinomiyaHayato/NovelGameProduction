using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CoroutineProvider : MonoBehaviour
{
    /// <summary>
    /// 外から、何か継続的な処理の開始を指示する。
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
            // 何か継続処理…
            elased += Time.deltaTime;
            Debug.Log($"{name}: {Time.frameCount}");
            yield return null;
        }

        Debug.Log($"{name}が終了しました");

        // 何か結果を返したい
        tcs.SetResult(Time.frameCount);

    }
}