# azure-function-password-generator

Random Password Generator using Azure Functions

# Build and release

- dotnet build --configuration Release
- dotnet publish --configuration Release --output ./publish
- cd ./publish
- Compress-Archive -Path . -DestinationPath ../passgen-func.zip
- az functionapp deployment source config-zip --src functionapp.zip --name <FunctionAppName> --resource-group <ResourceGroupName>