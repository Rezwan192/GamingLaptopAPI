# Gaming Laptop API

### Database Tables: 

GamingLaptops and GraphicsCards

### HTTP Methods + Endpoints:

1. GET: api/GraphicsCards
2. GET: api/GraphicsCards/id
3. GET: api/GamingLaptops
4. GET: api/GamingLaptops/id
5. POST: api/GraphicsCards
6. DELETE: api/GraphicsCards/id
    1. Due to a foreign key constraint, first delete the laptops of the list within the GraphicsCard object at id, using endpoint number 7, before deleting the GraphicsCard object
7. DELETE: api/GamingLaptops/id
    1. For id, use GraphicsCardId instead of LaptopId

### Sample Request Body for POST on api/GraphicsCards:

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
            "ProductName": "HP OMEN - 16.1\" inch Gaming Laptop",
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
            "ModelNumber": " 82NWCTO1WWUS1",
            "ReleaseYear": 2021,
            "Color": "Phantom Blue",
            "Processor": "AMD Ryzen 5 5600H",
            "ScreenSize": "15.6",
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
 
### Response Model Properties:
1. statusCode: 200 on success, 400 on failure
2. statusDescription: varies depending on HTTP method, endpoint, and of course, the success or failure of the request
gamingLaptops (for GET and POST on api/GamingLaptops) - contains either all the GamingLaptop objects in the database or a certain GamingLaptop object, depending on the endpoint  
3. graphicsCards (for GET and POST on api/GraphicsCards) - contains either all the GraphicsCard objects in the database or a certain GraphicsCard object, depending on the endpoint  
 
### Notes:

1. I originally planned on having a third, Processors table, but I decided to take it out and have it as a column within my GamingLaptops Table. 
Reason: In my GraphicsCard class, I have a list property, Laptops, which holds all the laptops that contain a specific graphics card. If I were to have a Processor class, I would need to have another list of laptops within it, holding all the laptops that contain a processor. However, since every gaming laptop has a processor and a graphics card, this would mean that if this database was fully complete, the GamingLaptops table would have a duplicate for each distinct laptop within it (one from the GraphicsCard class, and one from the Processors class). While there may be a better way to tackle this issue, I chose to make Processor a column in my GamingLaptops table while keeping the GraphicsCard table, as a graphics card is more relevant for gaming than a processor
2. For deletion on api/GamingLaptops/id, I decided to delete the list of laptops referring to the id of the graphics card, not the laptop, because I thought that since I was adding laptops to the database as lists, through my GraphicsCard class, then it only makes sense to remove those same lists when removing laptops.  








