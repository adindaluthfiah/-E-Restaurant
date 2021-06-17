## [PROSES INSTALASI ed-Toast]

Note: Pastikan Microsoft SQL Server Management Studio Ter-Install pada device user

IMPORT DATABASE:
1. Run Microsoft SSMS
2. Klik kanan pada folder Database di SMSS
3. Klik Import Data-Tier Application
4. Lalu pada setup import, bagian import setting, browse dan pilih file QBISNIS.bacpac di repository Phoenix
5. Lalu pada bagian Database Setting, atur nama database menjadi QBisnis
6. Lalu next hingga proses import data selesai
7. Lalu Add database Q-Bisnis pada Visual Studio 2019.

IMPORT DATABASE KE VISULA STUDIO 2019
1. Buka tools lalu connect to database
2. Pastikan Data Source adalah SQl Server
