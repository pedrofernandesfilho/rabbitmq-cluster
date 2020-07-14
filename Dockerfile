FROM rabbitmq:management-alpine
ENV RABBITMQ_ERLANG_COOKIE "bazinga"
COPY ./rabbitmq-cluster.conf /etc/rabbitmq/rabbitmq-cluster.conf
