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
- Kibana: `http://localhost:5601`
