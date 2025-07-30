import React from 'react';
import { Layout, Menu } from 'antd';
import { Routes, Route, useNavigate } from 'react-router-dom';
import ChatWidget from './components/ChatWidget';
import DocumentSearch from './components/DocumentSearch';
import Dashboard from './components/Dashboard';

const { Header, Content, Footer, Sider } = Layout;

/**
 * 主应用组件，使用 Ant Design 的 Layout 构建基本布局。
 */
function App() {
  const navigate = useNavigate();
  const items = [
    { key: 'dashboard', label: '仪表盘' },
    { key: 'chat', label: '智能对话' },
    { key: 'search', label: '文档检索' }
  ];

  const handleMenuClick = ({ key }) => {
    switch (key) {
      case 'dashboard':
        navigate('/');
        break;
      case 'chat':
        navigate('/chat');
        break;
      case 'search':
        navigate('/search');
        break;
      default:
        navigate('/');
    }
  };

  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Sider collapsible>
        <div style={{ height: 32, margin: 16, color: '#fff', textAlign: 'center' }}>
          AI 助手
        </div>
        <Menu theme="dark" mode="inline" defaultSelectedKeys={['dashboard']} items={items} onClick={handleMenuClick} />
      </Sider>
      <Layout>
        <Header style={{ backgroundColor: '#fff', padding: 0 }}>
          <h2 style={{ marginLeft: 16 }}>智能 AI 客服系统</h2>
        </Header>
        <Content style={{ margin: '16px' }}>
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/chat" element={<ChatWidget />} />
            <Route path="/search" element={<DocumentSearch />} />
          </Routes>
        </Content>
        <Footer style={{ textAlign: 'center' }}>
          © {new Date().getFullYear()} 智能 AI 客服与企业内部助手
        </Footer>
      </Layout>
    </Layout>
  );
}

export default App;
