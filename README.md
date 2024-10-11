# ElectricityComparison

Welcome to the Electricity Comparison made by NicoKozume.
This is a project initiated by verivox, to test my skills

## Run the project 

### Frontend
You can use the NX tools to run build and serve the frontend, alternativly use these commands

```shell
npx nx build ElectricityComparisonFrontend
```

### Backend
Use either the standard dotnet cli's or a .NET usable IDE to run the backend, unfortuantly the nx build targets do not work :(

## Docker
You can find the docker compose file inside the ./docker folder. Run 

```shell
docker compose up --build
```

so you can start the container. 
Both, frontend local developement and docker, is available at http://localhost:4200
