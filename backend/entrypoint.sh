#!/bin/sh

if [ -z $DATABASE_PASSWORD_FILE ]; then
    >&2 echo 'empty $DATABASE_PASSWORD_FILE env variable'
    exit -1
fi

export VotingApp__Database__Password=$(cat $DATABASE_PASSWORD_FILE)

dotnet VotingApp.Web.dll