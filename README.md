# 智能 AI 客服与企业内部 AI 助手

本仓库包含一个基于 ABP VNext 社区版和 React 的示例项目，旨在为企业构建面向外部客户的“智能 AI 客服”和面向内部员工的“企业内部 AI 助手”。项目分为后端（微服务架构）和前端两部分，方便分布式部署与开发。

## 项目概览

此项目参考了高阶设计方案并作了适当调整：

* **前端采用 React**。虽然 ABP 官方提供了 Angular/Blazor 前端模板，但为满足项目需求使用了独立的 React 客户端，与后端通过 REST API 通信。
* **后端基于 ABP VNext 社区版最新稳定版本**。按照模块化思想划分服务，每个服务可以独立部署并水平扩展。
* **服务划分**：IdentityService、ChatService、KnowledgeService、AIIntegrationService、BackgroundJobs、AdminUI、Logging 等。各服务通过 API Gateway (如 Ocelot) 暴露接口，内部通过事件总线/共享数据库协同工作。
* **核心流程**：用户发起对话→ChatService→根据需求调用 KnowledgeService/AIIntegrationService 等→组合结果返回给客户端→后台作业定期更新嵌入向量、清理日志。

本代码只包含基础骨架，未包含所有业务实现；开发者可以在此基础上扩展详细逻辑、权限控制、监控等。若您需要将此代码推送至 GitHub，请自行运行 `git init`、`git add`、`git commit` 等并推送到仓库。

## 仓库结构

```text
.
├── README.md                     # 项目说明
├── backend/                      # 后端微服务项目
│   ├── README.md                # 后端说明
│   └── src/
│       ├── SmartAI.IdentityService/     # 身份与权限服务
│       ├── SmartAI.ChatService/         # 对话服务
│       ├── SmartAI.KnowledgeService/    # 知识检索服务
│       ├── SmartAI.AIIntegrationService/# AI 调用服务
│       ├── SmartAI.BackgroundJobs/      # 后台作业服务
│       ├── SmartAI.AdminUI/             # 管理后台模块（仅后端 API）
│       └── SmartAI.LoggingService/      # 日志与监控模块
└── frontend/                     # 前端 React 应用
    ├── README.md                # 前端说明
    ├── package.json            # npm 包配置
    ├── public/                 # 公共资源
    │   └── index.html
    └── src/                    # React 源码
        ├── index.js
        ├── App.js
        └── components/         # 可复用组件
            ├── ChatWidget.jsx
            ├── DocumentSearch.jsx
            └── Dashboard.jsx
```

## 使用说明

1. **初始化前端**：进入 `frontend` 目录，运行 `npm install` 安装依赖。开发环境可以使用 `npm start` 启动本地服务器，默认监听 `http://localhost:3000`。
2. **初始化后端**：进入 `backend/src`，使用 `dotnet` 命令创建或还原项目所需的依赖。此仓库中的 `.csproj` 文件引用了 ABP VNext 包，需要在安装好 .NET SDK 和配置好 nuget 源后再执行 `dotnet restore`、`dotnet build`。
3. **配置环境**：根据您的实际部署环境配置数据库连接、OpenAI API Key、向量数据库等。在根目录可复制 `.env.example` 为 `.env` 并修改 `REACT_APP_API_BASE_URL`，供前端读取后端地址。后端运行时需要设置以下环境变量：

   - `OPENAI_API_KEY`：调用 OpenAI 接口所需的 API Key。
   - `KNOWLEDGE_SERVICE_URL`：ChatService 访问 KnowledgeService 的地址，默认 `http://localhost:5002`。
   - `AI_SERVICE_URL`：ChatService 访问 AIIntegrationService 的地址，默认 `http://localhost:5003`。

   在生产环境中建议使用 Docker Compose 或 Kubernetes 进行部署，并配置 HTTPS、身份认证等安全设置。

欢迎根据业务需求对代码结构和逻辑进行扩展和修改。

