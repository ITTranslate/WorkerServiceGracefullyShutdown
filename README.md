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

主要的修改在 `Worker` 类。
