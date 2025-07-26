import React from 'react';
import { Card, Typography, Space } from 'antd';

const { Title, Paragraph } = Typography;

/**
 * Dashboard 组件作为首页，展示系统介绍和快捷入口提示。
 */
function Dashboard() {
  return (
    <div style={{ padding: 24 }}>
      <Space direction="vertical" size="large" style={{ width: '100%' }}>
        <Card>
          <Title level={3}>欢迎使用智能 AI 客服与内部助手</Title>
          <Paragraph>
            本系统提供 7×24h 在线客服、企业知识检索、流程审批辅助、智能写作等能力，旨在帮助企业提升客户满意度与内部效率。
          </Paragraph>
        </Card>
        <Card>
          <Title level={4}>快速开始</Title>
          <Paragraph>
            在左侧菜单中选择“智能对话”与 AI 机器人对话，或选择“文档检索”查询公司内文档。
          </Paragraph>
        </Card>
      </Space>
    </div>
  );
}

export default Dashboard;