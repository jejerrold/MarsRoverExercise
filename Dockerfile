#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app

COPY NasaAPIProject/*.csproj ./NasaAPIProject/
RUN dotnet restore


COPY . .
WORKDIR /app/NasaAPIProject
RUN dotnet build


FROM mcr.microsoft.com/dotnet/framework/runtime:4.8 AS runtime
WORKDIR /app
COPY /bin/Debug .
ENTRYPOINT ["NasaAPIProject.exe"]
