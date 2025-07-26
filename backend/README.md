# 后端服务说明

本目录包含基于 ABP VNext 社区版构建的微服务骨架。每个服务遵循 DDD 分层架构，分为 Domain、Application、HttpApi 等层，以便统一治理和扩展。

## 服务目录

| 服务名称 | 说明 |
| --- | --- |
| **SmartAI.IdentityService** | 提供用户、部门、角色管理及 OAuth2/OIDC 认证授权。可对接 OpenIddict 或 IdentityServer。 |
| **SmartAI.ChatService** | 负责会话上下文管理，接受前端请求、判断调用知识检索或 AI 生成，支持转人工。 |
| **SmartAI.KnowledgeService** | 抓取企业文档，计算 Embedding，并通过向量检索返回相关文档。 |
| **SmartAI.AIIntegrationService** | 集中管理 Prompt 模板，负责调用 LLM（如 OpenAI）并融合检索结果。 |
| **SmartAI.BackgroundJobs** | 后台定时任务，如同步文档、计算向量、清理日志等。 |
| **SmartAI.AdminUI** | 后端 API 供管理界面使用，可配置知识源、Prompt 模板、A/B 测试等。 |
| **SmartAI.LoggingService** | 日志与监控模块，接入 ElasticSearch/Grafana，对重要操作进行审计。 |

## 项目约定

1. **模块化结构**：各服务以独立项目形式存在，通过引用 `Volo.Abp.*` 包实现模块化开发。服务之间通过共享数据库、事件总线 (CAP/Kafka) 交流。
2. **配置文件**：每个服务包含 `appsettings.json`，其中包括数据库连接、JWT 配置、OpenAI 密钥等。请根据实际情况修改。
3. **基础示例**：目前仅提供示例 Controller，实现简单的 REST API，如健康检查接口。业务逻辑需要开发者进一步完善。
4. **运行**：需要安装 .NET 7 SDK (或 ABP 支持的最新版本) 和 Node/NPM（若使用前端静态资源）。在根目录下运行 `dotnet build` 会构建所有项目。