using Fantasy;
using Fantasy.Async;
using UnityEngine;

public class Entry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Scene GameScene;

    void Start()
    {
        // ��ʼ�����
        Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
        StartAsync().Coroutine();
    }

    private async FTask StartAsync()
    {
        // ������һ���ͻ��˵�Scene
        GameScene = await Fantasy.Platform.Unity.Entry.CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
