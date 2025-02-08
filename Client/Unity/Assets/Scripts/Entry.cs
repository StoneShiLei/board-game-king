using Fantasy.Async;
using UnityEngine;

public class Entry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ��ʼ�����
        Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
    }

    private async FTask StartAsync()
    {
        // ������һ���ͻ��˵�Scene
        var scene = await Fantasy.Platform.Unity.Entry.CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
