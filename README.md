# Initiative Tracker Website
Last Updated: 2024/09/19

The purpose of this application is to provide to Dungeons and Dragons Dungeon Masters to be able to keep track of initiative without it being so much of a hassle. 

## Getting Started

### Pre-Requisites

1. Install a [.NET SDK](https://dotnet.microsoft.com/en-us/download)
	- .NET 8.0 is the compatible version for this application
2. Install [Docker Desktop](https://www.docker.com/products/docker-desktop/)
	- Don't need a Docker subscription, just need to have it install the Docker Engine + Docker CLI commands
3. Clone this repository using `git clone https://github.com/nearnum2/InitiativeTracker.git`

From here, you can choose to run it locally or through the docker image. Refer to the "Running the Application" section below 

### Running the Application

#### DotNet/Local

1. Open a terminal (Git Bash, Powershell, etc.)
2. Ensure that the .NET SDK was properly installed: `dotnet --version`
	- Should print out the version of .NET that you have currently installed. This should be >= 8.0
3. Run the application by using `dotnet run`

#### Docker

1. Ensure that Docker Desktop/Engine is on. This can be done by ensuring that Docker Desktop is an open window before executing the below steps.
2. Build the application: `docker build -t initiative_tracker -f Dockerfile .` 
3. Run the dockerized application: `docker run -p 8080:8080 initiative_tracker:latest`
4. Verify that the application is accessible via `http://localhost:8080/`
