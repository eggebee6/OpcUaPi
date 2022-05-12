# Set up build environment
FROM mcr.microsoft.com/dotnet/sdk:3.1 as buildenv

WORKDIR /build
COPY . /build

# Build and publish
RUN dotnet restore OpcUaPi.sln \
  --runtime linux-arm64

RUN dotnet publish src/DemoServer/DemoServer.csproj \
  --runtime linux-arm64 \
  --configuration Release \
  --self-contained false \
  --no-restore \
  --output /output

# Create image
FROM mcr.microsoft.com/dotnet/runtime:3.1-bullseye-slim-arm64v8

WORKDIR /output
COPY --from=buildenv /output .

ENTRYPOINT ["dotnet", "./DemoServer.dll"]
