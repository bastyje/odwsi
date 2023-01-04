FROM nginx

COPY ./docker/cert/self.pass /etc/keys/self.pass
COPY ./docker/cert/self.key /etc/ssl/private/self.key
COPY ./docker/cert/self.crt /etc/ssl/certs/self.crt
# COPY ./docker/cert/self.pfx /etc/ssl/certs/self.pfx
COPY ./docker/nginx.conf /etc/nginx/nginx.conf

CMD ["nginx", "-g", "daemon off;"]
