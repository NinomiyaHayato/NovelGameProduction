using System.Collections;
using System.Threading;
using UnityEngine;

public class CoroutineConsumer : MonoBehaviour
{
    [SerializeField]
    private CoroutineProvider _provider;

    void Start()
    {
        StartCoroutine(RunCoroutine());
    }

    private IEnumerator RunCoroutine()
    {
        using var ctsA = new CancellationTokenSource();
        using var ctsB = new CancellationTokenSource();

        var a = _provider.RunAsync("ˆ—1", ctsA.Token);
        var b = _provider.RunAsync("ˆ—2", ctsB.Token);

        while (!a.IsCompleted || !b.IsCompleted)
        {
            if (Input.GetKeyDown(KeyCode.A)) { ctsA.Cancel(); }
            if (Input.GetKeyDown(KeyCode.B)) { ctsB.Cancel(); }
            yield return null;
        }

        Debug.Log($"ˆ—1 Result={a.Result}");
        Debug.Log($"ˆ—2 Result={b.Result}");
    }
}