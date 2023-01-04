FROM node:16.13.0-alpine as builder
COPY . /app
WORKDIR /app
RUN npm install
RUN npm run build

FROM nginx:1.17.10-alpine
EXPOSE 80

COPY ./docker/self.pass /etc/keys/self.pass
COPY ./docker/snippets /etc/nginx/snippets
COPY ./docker/cert/self.key /etc/ssl/private/self.key
COPY ./docker/cert/self.crt /etc/ssl/certs/self.crt
COPY ./docker/nginx.conf /etc/nginx/nginx.conf
COPY --from=builder /app/dist/angular /usr/share/nginx/html
