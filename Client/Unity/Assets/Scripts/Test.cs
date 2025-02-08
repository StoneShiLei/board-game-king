using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button ConnectButton;
    public Button SendMessageButton;
    public Button CallButton;

    private Session _session;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConnectButton.onClick.AddListener(OnConnectButtonClick);
        SendMessageButton.onClick.AddListener(OnSendMessageButtonClick);
        CallButton.onClick.AddListener(() => OnCallButtonClick().Coroutine());
    }

    private void OnConnectButtonClick()
    {
        Debug.Log("点击连接按钮");
        _session = Entry.GameScene.Connect("127.0.0.1:38888", NetworkProtocolType.KCP, () =>
        {
            ConnectButton.enabled = false;
            _session.AddComponent<SessionHeartbeatComponent>().Start(2000);
            Debug.Log("链接成功");
        }, () =>
        {
            Debug.Log("链接失败");
        }, () =>
        {
            Debug.Log("链接断开");
        }, false);
    }

    private void OnSendMessageButtonClick() 
    {
        _session.Send(new C2G_HelloFantay
        {
            Test = "Hello!"
        });

        Debug.Log("向服务器发送了一条消息");
    }

    private async FTask OnCallButtonClick()
    {
        Debug.Log("向服务器发送消息...");
        var res = (G2C_HelloResponse)await _session.Call(new C2G_HelloRequest
        {
            Test = "Hello From Call!"
        });

        Debug.Log($"收到服务器返回消息:{res.TestRes}");
    }
}
