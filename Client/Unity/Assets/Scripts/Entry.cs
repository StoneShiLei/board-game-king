using Fantasy;
using Fantasy.Async;
using UnityEngine;

public class Entry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Scene GameScene;

    void Start()
    {
        // 初始化框架
        Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
        StartAsync().Coroutine();
    }

    private async FTask StartAsync()
    {
        // 创建用一个客户端的Scene
        GameScene = await Fantasy.Platform.Unity.Entry.CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
