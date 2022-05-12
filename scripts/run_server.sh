#!/bin/sh

set -e

IMAGE_NAME=opcuapi-demoserver

TAG=$1

if [ -z ${TAG} ]
  then
    TAG=latest
fi

echo Running ${IMAGE_NAME}:${TAG}

docker run \
  --rm \
  --device /dev/i2c-1 \
  -p 43100-43101:43100-43101 \
  ${IMAGE_NAME}:${TAG}
