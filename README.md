# Worker Service 优雅退出

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

添加 Serilog 日志记录：<https://github.com/ITTranslate/WorkerServiceWithSerilog>
