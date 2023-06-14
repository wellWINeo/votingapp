#!/bin/sh

# Reading admin's password
echo "KEYCLOAK_ADMIN_PASSWORD_FILE: ${KEYCLOAK_ADMIN_PASSWORD_FILE}"
if [ -n "${KEYCLOAK_ADMIN_PASSWORD_FILE}" ]; then
    export KEYCLOAK_ADMIN_PASSWORD=$(cat $KEYCLOAK_ADMIN_PASSWORD_FILE)
else
    >&2 echo 'KEYCLOAK_ADMIN_PASSWORD_FILE not defined' 
fi

# Reading database's password
echo "KEYCLOAK_ADMIN_PASSWORD_FILE: ${KEYCLOAK_DATABASE_PASSWORD_FILE}"
if [ -n "${KEYCLOAK_DATABASE_PASSWORD_FILE}" ]; then
    export KEYCLOAK_DATABASE_PASSWORD=$(cat $KEYCLOAK_DATABASE_PASSWORD_FILE)
else
    >&2 echo 'KEYCLOAK_DATABASE_PASSWORD_FILE not defined' 
fi

/opt/bitnami/scripts/keycloak/run.sh