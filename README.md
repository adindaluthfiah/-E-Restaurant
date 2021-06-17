## [PROSES INSTALASI ed-TOAST]

Note: Pastikan Microsoft SQL Server Management Studio (SSMS) Ter-Install pada device user

IMPORT DATABASE:
1. Run Microsoft SSMS
2. Klik kanan pada folder Database di SMSS
3. Klik Import Data-Tier Application
4. Lalu pada setup import, bagian import setting, browse dan pilih file Menu.bacpac pada folder ed-Toast
5. Lalu pada bagian Database Setting, atur nama database menjadi Menu
6. Lalu next hingga proses import data selesai
7. Lalu Add database Menu pada Visual Studio 2019.

IMPORT DATABASE KE VISUAL STUDIO 2019
1. Buka tools lalu connect to database
2. Pastikan Data Source adalah Microsoft SQl Server
   ![image](https://user-images.githubusercontent.com/79047677/122404768-b0f1ee80-cfa9-11eb-8fbf-bf088aae431b.png)
3. Tulis server name sesuai dengan nama server laptop anda, lalu pilih database Menu dan klik OK

MENGUBAH CONFIGURASI
1. Buka file app.config pada Project ed-Toast
2. Ubah setiap connection string sesuai dengan database Menu pada laptop anda, untuk melihat connection stringnya dapat dilihat melalui gambar dibawah ini
   ![image](https://user-images.githubusercontent.com/79047677/122405656-6d4bb480-cfaa-11eb-9c91-130eeef92816.png)
   ![image](https://user-images.githubusercontent.com/79047677/122405871-99673580-cfaa-11eb-81f2-ce0cbb3d237e.png)
3. Contohnya untuk laptop saya connection string dapat ditulis seperti ini :
   ![image](https://user-images.githubusercontent.com/79047677/122406061-c3205c80-cfaa-11eb-9f1a-9f25afa81dcf.png)
4. Sekarang, program sudah siap dijalankan


