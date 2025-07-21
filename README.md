MyApiProject
API สำหรับจัดการข้อมูล ผู้ใช้ (Users), อุปกรณ์ (Equipments), การยืม (Borrowings), และ รายละเอียดการยืม (Borrowing_Details) พัฒนาด้วย .NET 8.0 และ SQLite. โปรเจกต์นี้สร้างเพื่อวัดความรู้ด้าน backend สำหรับบริษัท PranWorks โดยมีตาราง 4 ตาราง, Foreign Key, คอลัมน์ 5+ ต่อตาราง, และ Seed Data 50 รายการในตาราง Users.
สถานะโปรเจกต์

รันสำเร็จ: รันด้วย dotnet run หรือ dotnet run --environment Development และทดสอบผ่าน Swagger UI ที่ http://localhost:5194/swagger.
Git: โค้ดถูก push ไปที่ https://github.com/Arrakkhammungkun/dotnet-InternTest ด้วย Visual Studio 2022.
ฐานข้อมูล: มีตาราง Users, Equipments, Borrowings, Borrowing_Details พร้อม Seed Data 50 รายการใน Users.
แก้ไข error: แก้ปัญหา no such table: Users โดยใช้ Connection String จาก appsettings.json ใน Program.cs.

ข้อกำหนดระบบ

.NET SDK 8.0
SQLite (ฐานข้อมูล: MyTestDb.db)
Visual Studio 2022
DB Browser for SQLite
dotnet-ef: ติดตั้งด้วย dotnet tool install --global dotnet-ef
Git: ตรวจสอบด้วย git --version

การติดตั้งและรัน

Clone repository:
git clone https://github.com/Arrakkhammungkun/dotnet-InternTest.git
cd dotnet-InternTest


ติดตั้ง dependencies:
dotnet restore


สร้างฐานข้อมูล:
del MyTestDb.db
rmdir /s /q Migrations
dotnet ef migrations add CreateAllTablesWithStaticSeedData
dotnet ef database update


คำสั่งนี้จะสร้าง MyTestDb.db ในโฟลเดอร์รากของโปรเจกต์ (เช่น dotnet-InternTest/MyTestDb.db).


ตรวจสอบ appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=MyTestDb.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}


หมายเหตุ: ใช้ relative path Data Source=MyTestDb.db เพื่อให้ clone แล้วรันได้ทันทีในทุกเครื่อง.


ตรวจสอบ .gitignore:
MyTestDb.db
bin/
obj/
.vs/
*.user
*.suo


รันโปรเจกต์:
dotnet run --environment Development


ตรวจสอบ terminal ว่าเห็น:Connection String: Data Source=MyTestDb.db




ทดสอบ API:

เปิด http://localhost:5194/swagger เพื่อใช้ Swagger UI.



รายการ API และวิธีใช้งาน
API พัฒนาด้วย ASP.NET Core Web API และทดสอบได้ผ่าน Swagger UI (http://localhost:5194/swagger). รายการ API มีดังนี้:
1. User API
จัดการข้อมูลผู้ใช้ (Users).
POST /api/User

คำอธิบาย: สร้างผู้ใช้ใหม่.
Parameters (JSON body):
firstName (string, required): ชื่อ.
lastName (string, required): นามสกุล.
email (string, required): อีเมล.
phone (string, required): เบอร์โทร.
isAdmin (boolean, required): สถานะแอดมิน.


ตัวอย่าง Request:{
  "firstName": "Jane",
  "lastName": "Smith",
  "email": "jane.smith@example.com",
  "phone": "0987654321",
  "isAdmin": true
}


ตัวอย่าง Response (HTTP 201 Created):{
  "userId": 51,
  "firstName": "Jane",
  "lastName": "Smith",
  "email": "jane.smith@example.com",
  "phone": "0987654321",
  "isAdmin": true,
  "createdAt": "2025-07-22T01:04:00Z"
}



GET /api/User

คำอธิบาย: ดึงข้อมูลผู้ใช้ทั้งหมด.
Response (HTTP 200 OK):[
  {
    "userId": 1,
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "phone": "0123456789",
    "isAdmin": false,
    "createdAt": "2025-07-20T00:00:00Z"
  },
  ...
]



GET /api/User/{id}

คำอธิบาย: ดึงข้อมูลผู้ใช้ตาม ID.
Parameter: id (integer, required).
ตัวอย่าง Request: GET /api/User/51
ตัวอย่าง Response (HTTP 200 OK):{
  "userId": 51,
  "firstName": "Jane",
  "lastName": "Smith",
  "email": "jane.smith@example.com",
  "phone": "0987654321",
  "isAdmin": true,
  "createdAt": "2025-07-22T01:04:00Z"
}



2. Equipment API
จัดการข้อมูลอุปกรณ์ (Equipments).
POST /api/Equipment

คำอธิบาย: สร้างอุปกรณ์ใหม่.
Parameters (JSON body):
name (string, required): ชื่ออุปกรณ์.
description (string, required): รายละเอียด.
status (string, required): สถานะ (เช่น Available, Unavailable).


ตัวอย่าง Request:{
  "name": "Laptop",
  "description": "Dell XPS 13",
  "status": "Available"
}


ตัวอย่าง Response (HTTP 201 Created):{
  "equipmentId": 1,
  "name": "Laptop",
  "description": "Dell XPS 13",
  "status": "Available",
  "createdAt": "2025-07-22T01:04:00Z"
}



GET /api/Equipment

คำอธิบาย: ดึงข้อมูลอุปกรณ์ทั้งหมด.
Response (HTTP 200 OK):[
  {
    "equipmentId": 1,
    "name": "Laptop",
    "description": "Dell XPS 13",
    "status": "Available",
    "createdAt": "2025-07-22T01:04:00Z"
  },
  ...
]



3. Borrowing API
จัดการข้อมูลการยืม (Borrowings).
POST /api/Borrowing

คำอธิบาย: สร้างบันทึกการยืมใหม่.
Parameters (JSON body):
userId (integer, required): ID ผู้ใช้.
borrowDate (string, required): วันที่ยืม (ISO 8601).
returnDate (string, optional): วันที่คืน.


ตัวอย่าง Request:{
  "userId": 51,
  "borrowDate": "2025-07-22T01:04:00Z",
  "returnDate": null
}


ตัวอย่าง Response (HTTP 201 Created):{
  "borrowingId": 1,
  "userId": 51,
  "borrowDate": "2025-07-22T01:04:00Z",
  "returnDate": null,
  "createdAt": "2025-07-22T01:04:00Z"
}



GET /api/Borrowing

คำอธิบาย: ดึงข้อมูลการยืมทั้งหมด.
Response (HTTP 200 OK):[
  {
    "borrowingId": 1,
    "userId": 51,
    "borrowDate": "2025-07-22T01:04:00Z",
    "returnDate": null,
    "createdAt": "2025-07-22T01:04:00Z"
  },
  ...
]



4. Borrowing_Detail API
จัดการรายละเอียดการยืม (Borrowing_Details).
POST /api/BorrowingDetail

คำอธิบาย: สร้างรายละเอียดการยืม (เชื่อม Borrowing กับ Equipment).
Parameters (JSON body):
borrowingId (integer, required): ID การยืม.
equipmentId (integer, required): ID อุปกรณ์.
quantity (integer, required): จำนวน.


ตัวอย่าง Request:{
  "borrowingId": 1,
  "equipmentId": 1,
  "quantity": 2
}


ตัวอย่าง Response (HTTP 201 Created):{
  "borrowingId": 1,
  "equipmentId": 1,
  "quantity": 2,
  "createdAt": "2025-07-22T01:04:00Z"
}



GET /api/BorrowingDetail/{borrowingId}/{equipmentId}

คำอธิบาย: ดึงรายละเอียดการยืมตาม ID.
Parameters:
borrowingId (integer, required).
equipmentId (integer, required).


ตัวอย่าง Request: GET /api/BorrowingDetail/1/1
ตัวอย่าง Response (HTTP 200 OK):{
  "borrowingId": 1,
  "equipmentId": 1,
  "quantity": 2,
  "createdAt": "2025-07-22T01:04:00Z"
}



หมายเหตุ

Repository: https://github.com/Arrakkhammungkun/dotnet-InternTest
Connection String: ใช้ relative path Data Source=MyTestDb.db เพื่อให้ clone แล้วรันได้ทันที.
แก้ไข error: ปัญหา no such table: Users แก้โดยใช้ Connection String จาก appsettings.json ใน Program.cs.
Git: ใช้ Visual Studio 2022 สำหรับ commit และ push.
API: รองรับ CRUD สำหรับ User, Equipment, Borrowing, Borrowing_Detail ตามโจทย์ (3+ parameters, 5+ response fields).
ฐานข้อมูล: มี 4 ตาราง (Users, Equipments, Borrowings, Borrowing_Details) พร้อม Foreign Key, 5+ columns ต่อตาราง, และ Seed Data 50 รายการใน Users.
