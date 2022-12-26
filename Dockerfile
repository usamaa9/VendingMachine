FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the src folder and restore dependencies
COPY /src .
RUN dotnet restore

RUN dotnet publish -c Release -o out

# Create the runtime image.
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out .