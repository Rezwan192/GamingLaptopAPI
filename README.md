# Gaming Laptop API

## MySQL Database Tables
- **GraphicsCards**
- **GamingLaptops**

## Endpoints

| HTTP Method | Endpoint | Description |
|--------------|-----------|-------------|
| **GET** | `api/GraphicsCards` | Retrieve all graphics cards |
| **GET** | `api/GraphicsCards/{id}` | Retrieve a specific graphics card |
| **GET** | `api/GamingLaptops` | Retrieve all gaming laptops |
| **GET** | `api/GamingLaptops/{id}` | Retrieve a specific gaming laptop |
| **POST** | `api/GraphicsCards` | Add a new graphics card (and associated laptops) |
| **DELETE** | `api/GraphicsCards/{id}` | Delete a graphics card — delete associated laptops first (see below) |
| **DELETE** | `api/GamingLaptops/{id}` | Delete laptops using **GraphicsCardId** instead of **LaptopId** |

> **Note:**  
> When deleting a graphics card, first remove its associated laptops (using endpoint 7) due to foreign key constraints.

---

## Sample Request Body (POST `api/GraphicsCards`)

```json
{
  "GraphicsCardName": "AMD Radeon RX 6600M",
  "Company": "AMD",
  "ReleaseYear": 2021,
  "BaseClockSpeed": 2.18,
  "BoostClockSpeed": 2.42,
  "TotalMemory": 8,
  "MemoryType": "GDDR6",
  "Laptops": [
    {
      "ProductName": "HP OMEN 16.1\" Gaming Laptop",
      "Company": "HP",
      "ModelNumber": "16-c0012dx",
      "ReleaseYear": 2021,
      "Color": "Mica Silver",
      "Processor": "AMD Ryzen 7 5800H",
      "ScreenSize": 16.1,
      "ScreenResolution": "1920 x 1080",
      "ScreenRefreshRate": 144,
      "BatteryCapacity": 70.9,
      "TotalStorage": 1000,
      "TotalMemory": 16,
      "OperatingSystem": "Windows 11 Home",
      "Height": 0.91,
      "Width": 14.54,
      "Depth": 9.76,
      "Weight": 5.1,
      "IsTouchScreen": false,
      "HasWebCam": true
    },
    {
      "ProductName": "Lenovo 5 15\" Premium with AMD GPU",
      "Company": "Lenovo",
      "ModelNumber": "82NWCTO1WWUS1",
      "ReleaseYear": 2021,
      "Color": "Phantom Blue",
      "Processor": "AMD Ryzen 5 5600H",
      "ScreenSize": 15.6,
      "ScreenResolution": "1920 x 1080",
      "ScreenRefreshRate": 120,
      "BatteryCapacity": 60.0,
      "TotalStorage": 512,
      "TotalMemory": 8,
      "OperatingSystem": "Windows 11 Home",
      "Height": 1.03,
      "Width": 14.29,
      "Depth": 10.24,
      "Weight": 5.65,
      "IsTouchScreen": false,
      "HasWebCam": true
    }
  ]
}
```
### Response Model Properties:
| Property | Description |
|-----------|-------------|
| **statusCode** | 200 on success, 400 on failure |
| **statusDescription** | Varies depending on HTTP method, endpoint, and success or failure of the request |
| **gamingLaptops** | (GET/POST on `api/GamingLaptops`) Contains all GamingLaptop objects or a specific one, depending on the endpoint |
| **graphicsCards** | (GET/POST on `api/GraphicsCards`) Contains all GraphicsCard objects or a specific one, depending on the endpoint |
 
### Notes:

1. A Processors table was considered but removed to avoid duplicate GamingLaptop entries. Instead, the processor is stored as a column in the GamingLaptops table.
2. Laptops are associated with graphics cards through a list within the GraphicsCard class. When deleting laptops, the GraphicsCardId is used to ensure consistency between related records.
   








