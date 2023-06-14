FROM bitnami/keycloak:21

WORKDIR /opt/custom-scripts
COPY ./init.sh .

ENTRYPOINT [ "./init.sh" ]