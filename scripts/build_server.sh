#!/bin/sh

set -e

DOCKERFILE_PATH=./docker/DemoServer
DOCKERFILE_NAME=Dockerfile

IMAGE_NAME=opcuapi-demoserver

TAG=$1

if [ -z ${TAG} ]
  then
    TAG=latest
fi

echo Using Dockerfile ${DOCKERFILE_PATH}/${DOCKERFILE_NAME}
echo Building ${IMAGE_NAME}:${TAG}

docker build \
  --progress=plain \
  --tag ${IMAGE_NAME}:${TAG} \
  --file ${DOCKERFILE_PATH}/${DOCKERFILE_NAME} \
  .
