import React, { useState } from 'react';
import { Card, Input, Button, List, Typography, Space } from 'antd';
import axios from 'axios';

const { Text } = Typography;

/**
 * DocumentSearch 组件提供文档检索功能。用户输入关键字后，通过 KnowledgeService 获取匹配文档列表。
 */
function DocumentSearch() {
  const [keyword, setKeyword] = useState('');
  const [results, setResults] = useState([]);
  const [loading, setLoading] = useState(false);

  const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

  const searchDocuments = async () => {
    const trimmed = keyword.trim();
    if (!trimmed) return;
    setLoading(true);
    try {
      const resp = await axios.get(`${API_BASE_URL}/api/knowledge/search`, { params: { query: trimmed } });
      // 假设返回结果为 { items: [{ id, title, snippet, score }] }
      setResults(resp.data?.items ?? []);
    } catch (err) {
      console.error(err);
      setResults([]);
    } finally {
      setLoading(false);
    }
  };

  const renderItem = item => (
    <List.Item key={item.id} style={{ flexDirection: 'column', alignItems: 'flex-start' }}>
      <Space direction="vertical">
        <Text strong>{item.title}</Text>
        <Text type="secondary">相关度：{item.score?.toFixed(2)}</Text>
        <Text>{item.snippet}</Text>
      </Space>
    </List.Item>
  );

  return (
    <Card title="文档检索" style={{ width: '100%' }}>
      <Space style={{ marginBottom: 16, width: '100%' }}>
        <Input
          placeholder="请输入关键词..."
          value={keyword}
          onChange={e => setKeyword(e.target.value)}
          onPressEnter={searchDocuments}
          disabled={loading}
        />
        <Button type="primary" onClick={searchDocuments} loading={loading}>
          查询
        </Button>
      </Space>
      <List
        dataSource={results}
        renderItem={renderItem}
        locale={{ emptyText: '暂无数据，请输入关键字查询。' }}
      />
    </Card>
  );
}

export default DocumentSearch;