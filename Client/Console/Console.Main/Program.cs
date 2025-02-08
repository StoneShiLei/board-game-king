// 根据创建一个日志类并实现ILog接口，把接口里的方法都实现一下。
// 可以使用三方Log框架
// 注册日志实例到框架中
Fantasy.Log.Register(new Fantasy.ConsoleLog());

// 初始化框架
Fantasy.Platform.Console.Entry.Initialize(typeof(Program).Assembly);

// 仅当你使用的平台没有每帧更新的功能时，需要执行StartUpdate方法
// 该方法本质是启用一个新的线程进行每帧更新
Fantasy.Platform.Console.Entry.StartUpdate();

// 创建用一个客户端的Scene，也可以把Scene当网络接口使用。
var scene = await Fantasy.Platform.Console.Entry.CreateScene();


Console.ReadKey();