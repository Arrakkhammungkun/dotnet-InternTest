MyApiProject
API สำหรับจัดการข้อมูลผู้ใช้ (User), อุปกรณ์ (Equipment), การยืม (Borrowing), และรายละเอียดการยืม (Borrowing_Detail) ด้วย .NET 8.0 และ SQLite. โปรเจกต์นี้พัฒนาเพื่อวัดความรู้ backend ของบริษัท PranWorks

รันสำเร็จ: รันด้วย dotnet run หรือ dotnet run --environment Development และเข้าถึง Swagger UI ที่ http://localhost:5194/swagger.
Git: โค้ดถูก push ไปที่ https://github.com/Arrakkhammungkun/dotnet-InternTest ด้วย Visual Studio 2022.
ฐานข้อมูล: มีตาราง Users, Equipments, Borrowings, Borrowing_Details พร้อม Seed Data 50 records ใน Users.

ข้อกำหนดระบบ

.NET SDK 8.0
SQLite (ฐานข้อมูล: MyTestDb.db)
Visual Studio 2022
DB Browser for SQLite
dotnet-ef (dotnet tool install --global dotnet-ef)
Git (git --version)

การติดตั้งและรัน

Clone repository:git clone https://github.com/Arrakkhammungkun/dotnet-InternTest.git
cd dotnet-InternTest


ติดตั้ง dependencies:dotnet restore


สร้างฐานข้อมูล:del MyTestDb.db
rmdir /s /q Migrations
dotnet ef migrations add CreateAllTablesWithStaticSeedData
dotnet ef database update


คำสั่งนี้จะสร้าง MyTestDb.db ในโฟลเดอร์รากของโปรเจกต์ (เช่น dotnet-InternTest/MyTestDb.db).



รันโปรเจกต์:dotnet run หรือ dotnet run --environment Development


ตรวจสอบ terminal ว่าเห็น:Connection String: Data Source=MyTestDb.db




ทดสอบ API ผ่าน Swagger UI:
เปิด http://localhost:5194/swagger.



ตัวอย่างรายการ API และวิธีใช้งาน
API ทั้งหมดพัฒนาด้วย ASP.NET Core Web API และทดสอบได้ผ่าน Swagger UI (http://localhost:5194/swagger). รายการ API มีดังนี้:
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
  "createdAt": "2025-07-22T00:42:00Z"
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







หมายเหตุ

Repository: https://github.com/Arrakkhammungkun/dotnet-InternTest
Connection String: ใช้ relative path Data Source=MyTestDb.db เพื่อให้ clone แล้วรันได้ทันที
แก้ไข error: ปัญหา no such table: Users แก้โดยใช้ Connection String จาก appsettings.json ใน Program.cs.
Git: ใช้ Visual Studio 2022 สำหรับ commit และ push.
API: รองรับ CRUD สำหรับ User, Equipment, Borrowing, Borrowing_Detail ตามโจทย์ (3+ parameters, 5+ response fields).
ฐานข้อมูล: มี 4 ตาราง (Users, Equipments, Borrowings, Borrowing_Details) พร้อม Foreign Key, 5+ columns ต่อตาราง, และ Seed Data 50 records ใน Users.
