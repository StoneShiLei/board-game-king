using System.Text;
using CommandLine;
using Fantasy.Exporter;
using Fantasy.Tools;
using Fantasy.Tools.ConfigTable;

try
{
    // 初始化配置
    ExporterSettingsHelper.Initialize();
    // 加载配置
    Console.OutputEncoding = Encoding.UTF8;

    var command = Environment.GetCommandLineArgs();
    if(command != null && command.Length > 1)
    {
        Parser.Default.ParseArguments<ExporterAges>(command)
        .WithNotParsed(error => throw new Exception("Command line format error!"))
        .WithParsed(ages => ExporterAges.Instance = ages);
    }
    else
    {
        Log.Info("请请选择要导出的选项:");
        Log.Info("1. Client");
        Log.Info("2. Server");
        Log.Info("3. All");

        var keyChar1 = Console.ReadLine();
        if (!int.TryParse(keyChar1, out var key1) || key1 is < 1 or > 3)
        {
            Log.Error("无法识别的导出的选项，请输入正确的选项。");
            return;
        }
        ExporterAges.Instance = new ExporterAges() { ExportPlatform = (ExportPlatform)int.Parse(keyChar1.ToString()) };
    }

    Log.Info("请输入你想要做的操作:");
    Log.Info("1:增量导出Excel（包含常量枚举）");
    Log.Info("2:全量导出Excel（包含常量枚举）");

    var keyChar = Console.ReadLine();

    if (!int.TryParse(keyChar, out var key) || key is < 1 or >= (int)ExportType.Max)
    {
        Log.Error("无法识别的导出类型，请输入正确的操作类型。");
        return;
    }
    // 转换用户输入    
    new ExcelExporter((ExportType)key).Run();
}
catch (Exception e)
{
    Log.Error(e);
}
finally
{
    Log.Info("按任意键退出程序");
    Console.ReadKey();
    Environment.Exit(0);
}
