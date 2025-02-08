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
        Debug.Log("������Ӱ�ť");
        _session = Entry.GameScene.Connect("127.0.0.1:38888", NetworkProtocolType.KCP, () =>
        {
            ConnectButton.enabled = false;
            _session.AddComponent<SessionHeartbeatComponent>().Start(2000);
            Debug.Log("���ӳɹ�");
        }, () =>
        {
            Debug.Log("����ʧ��");
        }, () =>
        {
            Debug.Log("���ӶϿ�");
        }, false);
    }

    private void OnSendMessageButtonClick() 
    {
        _session.Send(new C2G_HelloFantay
        {
            Test = "Hello!"
        });

        Debug.Log("�������������һ����Ϣ");
    }

    private async FTask OnCallButtonClick()
    {
        Debug.Log("�������������Ϣ...");
        var res = (G2C_HelloResponse)await _session.Call(new C2G_HelloRequest
        {
            Test = "Hello From Call!"
        });

        Debug.Log($"�յ�������������Ϣ:{res.TestRes}");
    }
}
