﻿# משתמש בתמונה הבסיסית של .NET SDK כדי לבנות את האפליקציה
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# מעתיק את קבצי הפרויקט ומבצע restore
COPY *.sln ./
COPY Clean.API/*.csproj Clean.API/
COPY Clean.Core/*.csproj Clean.Core/
COPY Clean.Data/*.csproj Clean.Data/
COPY Clean.Service/*.csproj Clean.Service/
RUN dotnet restore

# מעתיק את שאר הקבצים ובונה את האפליקציה
COPY . ./
RUN dotnet publish Clean.API -c Release -o out

# משתמש בתמונה של .NET Runtime כדי להריץ את האפליקציה
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# מגדיר את הפורט שהאפליקציה תאזין עליו
EXPOSE 80

# מפעיל את האפליקציה
ENTRYPOINT ["dotnet", "Clean.API.dll"]
