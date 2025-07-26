# 前端 React 应用说明

此目录存放基于 React 的前端应用。它与后端通过 REST API (如 Ocelot Gateway) 进行交互，实现了智能客服与内部助手的基础界面。

## 功能模块

| 模块 | 说明 |
| --- | --- |
| **ChatWidget** | 对话组件，用户输入问题后通过 API 调用后台获取答案，支持历史记录显示。 |
| **DocumentSearch** | 文档检索页面，可输入关键词查询知识库中的文档并显示 Top‑K 结果。 |
| **Dashboard** | 仪表盘/首页，可整合常用功能入口，如写作助手、日程提醒等。 |

## 快速开始

1. 使用 Node 16+ 和 npm：安装依赖 `npm install`。
2. 开发模式启动：在 `frontend` 目录下运行 `npm start`，访问 `http://localhost:3000` 查看效果。
3. 构建生产包：运行 `npm run build`，生成的静态文件位于 `build` 目录，可交由 Nginx/Apache 或后台程序托管。

## 项目依赖

在 `package.json` 中列出了常用的依赖，包括：

* **react** & **react-dom**：核心库。
* **axios**：用于调用后端 API。
* **react-router-dom**：前端路由。
* **antd**：Ant Design UI 组件库，便于快速构建后台界面。

根据需要可以添加状态管理库（如 Redux、Recoil），或使用其他 UI 框架（如 MUI）。