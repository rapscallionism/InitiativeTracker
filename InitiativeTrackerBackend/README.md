# INITIATIVE TRACKER

## GETTING STARTED

Make sure to have Docker Desktop running on local in order to run the following commands.

To dockerize and run the project, use the following commands:

```
	docker build -t initiative-backend .
	docker run -p 5000:8080 initiative-backend
```

And make sure to run these commands from the root of the project.
If you intend to run the project in an ephemeral environment, use the following commands:

```
	docker-compose up --build
```

This will (re)build and run the project according to the specifications in the 
[docker compose configuration.](./docker-compose.yml) 

To spin down the composed docker compose, you can use: 

```
	docker-compose down
```

If you want to make sure that, when the containers are being spun down, that all data gets erased between each
start-up, you can use: 

```
	docker-compose down --volumes
```