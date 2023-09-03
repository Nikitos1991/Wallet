SOLUTION SETUP

In order to run the solution following steps should be done 

1) docker installed on the PC
https://docs.docker.com/desktop/install/windows-install/
2) navigate to the folder with docker-compose.yml and Dockerfile  location
3) open command line in scope of that file location
4) execute command : docker-compose build 
5) execute command : docker-compose up
6) navigate to browser url http://localhost:8080/swagger/index.html to see running swagger api 

Resources: https://blog.christian-schou.dk/dockerize-net-core-web-api-with-ms-sql-server/amp/


REQUIREMENTS COVERAGE

● We need a way to create a wallet. ([POST] /wallets)
● We need a way to add funds to a wallet. ([POST] /wallets/{id}/funds)
● We need a way to remove funds from a wallet([DELETE] /wallets/{id}/funds).
● We need a way to query the current state of a wallet.([GET] /wallets/{id})
● The balance of a wallet cannot be negative. (in scope of [DELETE] /wallets/{id}/funds corresponding check was added to verify if sum of transactions are greater then  zero)
● A user can’t spend the same funds twice.
● The client should interact with service with REST APIs(API Implemented according to richardson maturity model).


 
