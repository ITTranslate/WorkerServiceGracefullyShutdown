# Worker Service 优雅退出

[Read the related article](https://ittranslator.cn/dotnet/csharp/2021/05/17/worker-service-gracefully-shutdown.html).

## 创建 Worker Service

```bash
dotnet new worker -n "MyService"
```

## 运行

```bash
dotnet build
dotnet run
```

## 修改 Worker.cs

基于默认的 Worker Service 模板项目，主要的修改在 `Worker` 类。

## 相关项目

- [添加 Serilog 日志记录](https://github.com/ITTranslate/WorkerServiceWithSerilog)
- [.NET Worker Service 作为 Windows 服务运行及优雅退出改进](https://github.com/ITTranslate/WorkerServiceAsWindowsService)
