## 环境要求

- Unity 2022+
- .NET 8.0 SDK
- Visual Studio/VS Code/Rider（任选其一）

## 项目结构

```
├── Client                              # Unity客户端项目
│   ├── Assets                          # Unity资源目录
│   │   ├── Scenes                      # 场景文件
│   │   └── Scripts                     # 客户端脚本
│   └── ProjectSettings                 # Unity项目设置
│
├── Server                              # 服务器项目
│   ├── Server.Main                     # 服务器主程序
│   ├── Server.Entity                   # 实体类型
│   └── Server.Hotfix                   # 核心逻辑
│
└── Config                              # 配置文件
    ├── Excel                           # Excel配置文件
    │   └── Server                      # 服务器配置
    │       ├── MachineConfig.xlsx      # 宿主机配置
    │       ├── ProcessConfig.xlsx      # 进程配置
    │       ├── SceneConfig.xlsx        # 场景配置
    │       └── WorldConfig.xlsx        # 世界配置
    │
    └── NetworkProtocol                 # 网络协议定义
        ├── Inner                       # 服务器间协议
        ├── Outer                       # 客户端-服务器协议
        └── RouteType.Config            # Route消息类型配置
```

## 开发环境配置

1. **服务器开发**
   - 使用VS/VS Code/Rider打开Server解决方案，运行Server.Main程序

2. **客户端开发**
   - 在Unity中打开Client项目

## 网络协议开发

1. **客户端-服务器协议**
   - 在`NetworkProtocol/Outer`目录下定义
   - 支持TCP/KCP/WebSocket/HTTP协议

2. **服务器间协议**
   - 在`NetworkProtocol/Inner`目录下定义

3. **导出协议文件**
   - 使用`Server/Fantasy.Tools.NetworkProtocol`工具导出网络协议文件

## 配置文件管理

1. **Excel配置**
   - 在`Config/Excel`目录下修改配置
   - 使用`Server/Fantasy.Tools.ConfigTable`工具导出JSON

2. **JSON配置**
   - 导出的JSON文件位于`Config/Json`目录
   - 可直接修改JSON文件进行配置调整

## 开发规范

1. **代码风格**
   - 遵循C#代码规范
   - 使用统一的代码格式化工具

2. **提交规范**
   - 每次提交请附带清晰的提交信息
   - 重要更改需要添加相应的文档说明

## 技术支持

- 详细文档：https://www.code-fantasy.com/
- 视频教程：https://www.bilibili.com/video/BV1o7SjYuEPG