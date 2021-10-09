# InventoryManagementSystemAPI

Requires .NET 5

1. dotnet tool install --global dotnet-ef
2. dotnet run
3. dotnet user-secrets set "TokenSecretKey" "azxcsdfdsf23123opkfd54adacifjoiweuodier"


dotnet ef database drop --project D:\C#\InventoryManagementSystemAPI\InventoryManagementSystemAPI.Data -s D:\C#\InventoryManagementSystemAPI\InventoryManagementSystemAPII --msbuildprojectextensionspath objlocal

dotnet ef migrations add AddItemDescription --startup-project . --project ../InventoryManagementSystemAPI.data
dotnet ef database update --startup-project . --project ../InventoryManagementSystemAPI.data
