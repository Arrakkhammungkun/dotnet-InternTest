# MyApiProject

API สำหรับจัดการ User, Equipment, Borrowing, และ Borrowing_Detail

## ข้อกำหนดระบบ
- .NET SDK 8.0
- SQLite (ฐานข้อมูล: `MyTestDb.db`)
- Visual Studio 2022
- DB Browser for SQLite
- dotnet-ef (`dotnet tool install --global dotnet-ef`)
- Git (`git --version`)

## การติดตั้งและรัน
1. Clone: `git clone https://github.com/your-username/MyApiProject.git`
2. ติดตั้ง: `dotnet restore`
3. สร้างฐานข้อมูล:
   ```bash
   cd D:\Test_intern\Code\MyApiProject
   del MyTestDb.db
   rmdir /s /q Migrations
   dotnet ef migrations add CreateAllTablesWithStaticSeedData
   dotnet ef database update# MyApiProject
