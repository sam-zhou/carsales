#!/usr/bin/env bash

SCRIPT_DIRECTORY=$(dirname "${BASH_SOURCE[0]}")

java -jar "${SCRIPT_DIRECTORY}/swagger-codegen-cli-2.2.2.jar" \
    generate \
    -i https://boundlss-axa-test.azurewebsites.net/swagger/docs/v1 \
    -l typescript-angular \
    -o src/Boundlss.Coaching/App/service
