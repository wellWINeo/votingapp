FROM node:18-alpine as BUILDER

WORKDIR /source
COPY package.json package-lock.json ./
RUN npm ci

COPY . .
RUN npm run build:production

FROM nginx:stable-alpine-slim as FINAL

COPY ./entrypoint.sh .
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY --from=BUILDER /source/dist/frontend /app

ENTRYPOINT [ "./entrypoint.sh" ]
