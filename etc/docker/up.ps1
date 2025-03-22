docker network create acreddi --label=acreddi
docker-compose -f docker-compose.infrastructure.yml up -d
exit $LASTEXITCODE