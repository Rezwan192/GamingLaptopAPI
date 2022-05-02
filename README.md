Gaming Laptop API

Database Tables: GamingLaptops and GraphicsCards

HTTP Methods + Endpoints:

GET: api/GraphicsCards
GET: api/GraphicsCards/id
GET: api/GamingLaptops
GET: api/GamingLaptops/id
POST: api/GraphicsCards
DELETE: api/GraphicsCards/id
Due to a foreign key constraint, first delete the laptops of the list within the GraphicsCard object at id, using endpoint number 7, before deleting the GraphicsCard object
DELETE: api/GamingLaptops/id
For id, use GraphicsCardId instead of LaptopId

Sample Request Body for POST on api/GraphicsCards:

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
 
Response Model Properties:
statusCode: 200 on success, 400 on failure
statusDescription: varies depending on HTTP method, endpoint, and of course, the success or failure of the request
gamingLaptops (for GET and POST on api/GamingLaptops) - contains either all the GamingLaptop objects in the database or a certain GamingLaptop object, depending on the endpoint  
graphicsCards (for GET and POST on api/GraphicsCards) - contains either all the GraphicsCard objects in the database or a certain GraphicsCard object, depending on the endpoint  
 
Notes:

I originally planned on having a third, Processors table, but I decided to take it out and have it as a column within my GamingLaptops Table
Reason; In my GraphicsCard class, I have a list property, Laptops, which holds all the laptops that contain a specific graphics card. If I were to have a Processor class, I would need to have another list of laptops within it, holding all the laptops that contain a processor. However, since every gaming laptop has a processor and a graphics card, this would mean that if this database was fully complete, the GamingLaptops table would have a duplicate for each distinct laptop within it (one from the GraphicsCard class, and one from the Processors class). There is a probably a way to tackle this issue, but to keep it simple while adhering to the requirements of this project, I chose to make Processor a column in my GamingLaptops table while keeping the GraphicsCard table, as a graphics card is more relevant for gaming than a processor
For deletion on api/GamingLaptops/id, I decided to delete the list of laptops referring to the id of the graphics card, not the laptop, because I thought that since I was adding laptops to the database as lists, through my GraphicsCard class, then it only makes sense to remove those same lists when removing laptops.  
POST does not have a failure response consistent with my response model because the program already checks for a valid graphicsCard object in the argument, before the code inside the method is checked; if the object is null, the program will return its own failure response without checking the code in the method (similar explanation present in comments of POST method in GraphicsCardsController.cs)







