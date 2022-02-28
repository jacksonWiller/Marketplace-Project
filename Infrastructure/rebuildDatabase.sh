#!/bin/sh
echo "Removendo dirtorio Migrations"
if [ -d Migrations ]; 
    then 
        rm -Rf Migrations;  
        echo "O diretorio Migrations foi removido"
    else
        echo "O diretorio Migrations não existe"
fi

if [ -f ../Web.API/CompreyMarketplace.db ]; 
    then 
        rm -Rf ../Web.API/CompreyMarketplace.db; 
        echo "O Arquivo CompreyMarketplace.db foi removido"
    else
        echo "O Arquivo CompreyMarketplace.db não existe"
fi

echo "Criando Migrations"
dotnet ef --startup-project ../Web.API/Web.API.csproj migrations add init;

echo "Criando Banco de dados"
dotnet ef --startup-project ../Web.API/Web.API.csproj database update;




