FROM rabbitmq:management-alpine
ENV RABBITMQ_ERLANG_COOKIE "bazinga"
ENV RABBITMQ_SERVER_ADDITIONAL_ERL_ARGS "-rabbitmq_management load_definitions '/opt/definitions.json'"
ADD ./definitions.json /opt/
