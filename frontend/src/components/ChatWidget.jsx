import React, { useState } from 'react';
import { Card, Input, Button, List, Typography, Space } from 'antd';
import axios from 'axios';

const { Text } = Typography;

/**
 * ChatWidget 组件提供智能问答界面。用户在输入框中输入问题，点击“发送”后，组件会调用后端聊天接口获取回复。
 * 当前实现仅作示例，实际部署时需将 `API_BASE_URL` 指向您的网关地址。
 */
function ChatWidget() {
  const [messages, setMessages] = useState([]);
  const [inputValue, setInputValue] = useState('');
  const [loading, setLoading] = useState(false);

  // 默认 API 基地址，可根据部署环境修改
  const API_BASE_URL = process.env.REACT_APP_API_BASE_URL || 'http://localhost:5000';

  /**
   * 发送消息到后端
   */
  const sendMessage = async () => {
    const trimmed = inputValue.trim();
    if (!trimmed) return;

    // 将用户消息添加到列表
    setMessages(prev => [...prev, { role: 'user', content: trimmed }]);
    setInputValue('');
    setLoading(true);

    try {
      // 调用后端 API
      const resp = await axios.post(`${API_BASE_URL}/api/chat/ask`, { question: trimmed });
      const answer = resp.data?.answer || '暂未获取到答案';
      setMessages(prev => [...prev, { role: 'assistant', content: answer }]);
    } catch (err) {
      console.error(err);
      setMessages(prev => [...prev, { role: 'assistant', content: '出错了，请稍后重试。' }]);
    } finally {
      setLoading(false);
    }
  };

  /**
   * 渲染聊天记录
   */
  const renderItem = item => (
    <List.Item>
      <Space direction="vertical" style={{ width: '100%' }}>
        <Text strong>{item.role === 'user' ? '你' : 'AI'}:</Text>
        <Text>{item.content}</Text>
      </Space>
    </List.Item>
  );

  const handleKeyDown = e => {
    if (e.key === 'Enter') {
      sendMessage();
    }
  };

  return (
    <Card title="智能对话" style={{ width: '100%', height: '100%' }}>
      <div style={{ maxHeight: '50vh', overflowY: 'auto', marginBottom: 16 }}>
        <List
          dataSource={messages}
          renderItem={renderItem}
          locale={{ emptyText: '暂无对话，快来提问吧！' }}
        />
      </div>
      <Space style={{ width: '100%' }}>
        <Input
          placeholder="请输入您的问题..."
          value={inputValue}
          onChange={e => setInputValue(e.target.value)}
          onKeyDown={handleKeyDown}
          disabled={loading}
        />
        <Button type="primary" onClick={sendMessage} loading={loading}>
          发送
        </Button>
      </Space>
    </Card>
  );
}

export default ChatWidget;