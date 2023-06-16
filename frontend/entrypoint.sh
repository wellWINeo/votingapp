#!/bin/sh

echo "$BACKEND_HOST:$BACKEND_PORT"
nslookup "$BACKEND_HOST"
ls /app

sed -i "s/{{BACKEND_HOST}}/$BACKEND_HOST/g" /etc/nginx/nginx.conf
sed -i "s/{{BACKEND_PORT}}/$BACKEND_PORT/g" /etc/nginx/nginx.conf

nginx
