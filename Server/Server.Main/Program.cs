using Fantasy;
using Fantasy.Helper;
using Fantasy.IdFactory;
using Fantasy.NLog;
using Fantasy.Platform.Net;
using Server.Entity;

// 设置ID生成规则
IdFactoryHelper.Initialize(IdFactoryType.World);

// 获取配置文件
var machineConfigText = await FileHelper.GetTextByRelativePath("ServerConfig/MachineConfigData.Json");
var processConfigText = await FileHelper.GetTextByRelativePath("ServerConfig/ProcessConfigData.Json");
var worldConfigText = await FileHelper.GetTextByRelativePath("ServerConfig/WorldConfigData.Json");
var sceneConfigText = await FileHelper.GetTextByRelativePath("ServerConfig/SceneConfigData.Json");

// 初始化配置文件
// 重复初始化方法会覆盖掉上一次的数据，以实现热重载
MachineConfigData.Initialize(machineConfigText);
ProcessConfigData.Initialize(processConfigText);
WorldConfigData.Initialize(worldConfigText);
SceneConfigData.Initialize(sceneConfigText);

// 注册日志模块到框架
Log.Register(new FantasyNLog("Server"));

// 初始化框架，添加程序集到框架中
Entry.Initialize(AssemblyHelper.Assemblies);

// 启动Fantasy.Net
await Entry.Start();