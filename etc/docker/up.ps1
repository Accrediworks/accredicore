docker network create accredi --label=accredi
docker-compose -f docker-compose.infrastructure.yml up -d
exit $LASTEXITCODE