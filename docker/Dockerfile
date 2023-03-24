FROM flyway/flyway:latest

RUN wget -q https://download.microsoft.com/download/a/9/1/a91534b0-ed8c-4501-b491-e1dd0a20335a/sqljdbc_12.2.0.0_enu.tar.gz
RUN tar -xzf sqljdbc_12.2.0.0_enu.tar.gz
RUN cp sqljdbc_12.2/enu/mssql-jdbc-12.2.0.jre8.jar /flyway/drivers/mssql-jdbc.jar

COPY ./conf/flyway.conf /flyway/conf/flyway.conf
COPY ./sql /sql/
