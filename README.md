# README

# Docker 環境建立

執行 Docker Compose

```bash
$ docker compose -f docker-compose.yaml -p es-poc up -d

# 重新編譯相依服務 Image
$ docker compose -f docker-compose.yaml -p es-poc up -d --build
```

# Endpoint

- Elasticsearch: `http://localhost:9200`

```json
// 如果成功啟動會出現以下內容
{
    "name": "es01",
    "cluster_name": "es-docker-cluster",
    "cluster_uuid": "AJvS2e-US7Ccv985cKu8vg",
    "version": {
        "number": "8.15.2",
        "build_flavor": "default",
        "build_type": "docker",
        "build_hash": "98adf7bf6bb69b66ab95b761c9e5aadb0bb059a3",
        "build_date": "2024-09-19T10:06:03.564235954Z",
        "build_snapshot": false,
        "lucene_version": "9.11.1",
        "minimum_wire_compatibility_version": "7.17.0",
        "minimum_index_compatibility_version": "7.0.0"
    },
    "tagline": "You Know, for Search"
}
```

- Kibana: `http://localhost:5601`
