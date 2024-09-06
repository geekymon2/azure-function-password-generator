# azure-function-password-generator

Random Password Generator using Azure Functions

# Build and deployment example

- dotnet build --configuration Release
- dotnet publish --configuration Release --output ./publish
- cd ./publish
- Compress-Archive -Path \* -DestinationPath ../passgen-func.zip
- az functionapp deployment source config-zip --src passgen-func.zip --name passgen-func-dev --resource-group Development
