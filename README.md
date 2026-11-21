# SalonFlow
## Salon Business Management System

A Windows Forms classroom project using C#, .NET 8, MVC, ADO.NET and the MariaDB server in XAMPP. All main forms have a Visual Studio Designer file. The login and registration screens follow the supplied example with a large title, labels on the left, fields on the right and buttons below.

## 1. Set up the database in one paste

1. Extract the ZIP using **Extract All** in Windows. Keep the solution, project and Database folder together.
2. Open **XAMPP Control Panel**. Click **Start** next to **MySQL** and **Apache**. MySQL stores the records. Apache opens phpMyAdmin.
3. Open [phpMyAdmin](http://localhost/phpmyadmin/) in your browser.
4. On the phpMyAdmin home page, click **SQL** at the top. Open `Database/SalonFlow_Setup.sql` in Notepad. Press **Ctrl+A** and **Ctrl+C**, paste everything into the SQL box, then click **Go** once. You can also choose **Import**, select that same file and click **Import**.
5. Click **salonflow_db** on the left and look for `users`, `customers`, `services`, `appointments`, `bills` and the other tables. The SQL creates the database, tables, starter owner and sample records.

## 2. Open and run the project

1. In **Visual Studio Installer**, install the **.NET desktop development** workload for Visual Studio 2022 and ensure the **.NET 8 SDK** is installed. Use an up-to-date Visual Studio 2022.
2. Double-click **SalonFlow.sln** inside the extracted folder. In Solution Explorer, right-click the solution and choose **Restore NuGet Packages** if packages did not restore automatically. Internet access is needed for the first restore of MySqlConnector.
3. Open **SalonFlow → Database.config** in Solution Explorer. For standard XAMPP settings, keep this line:

   ```text
   Server=127.0.0.1;Port=3306;Database=salonflow_db;User ID=root;Password=;Connection Timeout=5;
   ```

   If MySQL uses port 3307, change `Port=3306` to `Port=3307`. If your local MySQL account has a password, enter it after `Password=`. This line is a C# connection setting. Run only the SQL file in phpMyAdmin. The build copies Database.config beside the executable.

4. Press **F5**. On **SalonFlow - Log in**, enter **owner@salonflow.local** and **SalonDemo!2026**. Change this classroom password in **Change password** after your first sign-in.
5. Choose **Create account** on the login screen to test the customer path. Create staff accounts from **User accounts** while signed in as Owner. To give a stylist access to their schedule and commission, enter the new stylist account's ID when editing their record in **Staff directory**.

### Open a form in the Designer

In Solution Explorer, expand **SalonFlow → Views**, right-click **LoginForm.cs** and choose **View Designer** or press **Shift+F7**. Use the same steps for **RegisterForm.cs** and the other forms. Open the solution with **File → Open → Project/Solution** if you started Visual Studio first. In Solution Explorer, use **Solution View** if you previously opened the directory in Folder View. The Designer entry belongs to **LoginForm.cs**. Expand its arrow to see the nested Designer and resource files. Click the form or a control and press **F4** to see its properties. Select **View Code** to read the click handlers. If the Designer reports a missing reference, build and restore packages first.

## 3. Walk through a booking and payment

1. In **Customer records**, choose a sample customer or add one and note their ID. To edit a record, select the row, click **Load selected**, make changes and click **Add / save**. Click **Clear fields** to start a new record.
2. Open **Appointments** and click **Find booking IDs** for available service, stylist and customer records. The SQL seeds customer **1**, stylist **1** and Haircut service **1**.
3. Enter the three IDs and a future start time in `yyyy-MM-dd HH:mm` format. Click **Book appointment**. Try another booking for the same stylist inside that time to test the overlap check.
4. Select the appointment and update its status to **Checked in**, **In service**, then **Completed**, reselecting its row after each refresh. Note the appointment ID.
5. Open **Billing and payments**. Enter the customer ID, branch ID **1** and completed appointment ID. Click **Create bill**. SalonFlow adds the booked service at the price agreed when it was booked. For a walk-in sale, leave the appointment ID blank and use **Add item** to enter a service or retail product.
6. Select the bill and record a payment. For the sample RWF 5,000 haircut with no tax or discount, enter **Cash** and **6000**. The app records RWF 5,000 and shows RWF 1,000 change. For Mobile money or Card, enter the transaction reference after the payment has been confirmed separately. You can record separate payments against the same balance.
7. Select the bill and click **Preview receipt**. Use **Microsoft Print to PDF** as the printer when saving a PDF. Open **Reports** to view today’s sales by payment method. Use the date range fields for earlier records.

## 4. Screen names

| Visual Studio form | Purpose |
| --- | --- |
| LoginForm | Sign in with an email or phone and password |
| RegisterForm | Create a customer account |
| DashboardForm | Open modules available to the signed-in role |
| CustomersForm | Register, search and edit customers. View completed visits. |
| ServicesForm | Maintain services, prices, durations and availability |
| StaffForm | Maintain the staff directory, branch and commission rate |
| AppointmentsForm | Book, reschedule and update appointments or view a personal schedule |
| QueueForm | Add walk-ins, assign the next customer and update queue status |
| BillingForm | Build a bill, take payments, apply discounts and print receipts |
| InventoryForm | Manage products, adjust stock and identify low stock |
| ExpensesForm | Record expenses and their dates |
| ReportsForm | View and print sales, services, commission, stock, appointment and profit reports |
| AccountsForm | Create staff accounts and change account activation |
| BranchesForm | Maintain branches and branch tax rates |
| AuditForm | Search changes recorded in the audit trail |
| PromotionsForm | Set percentage discounts and validity dates |
| PasswordForm | Change your password |

## 5. How MVC works here

- **Views** contain the WinForms controls and handle button clicks. For instance, **AppointmentsForm** reads the date and selected IDs when you click **Book appointment**.
- **Controllers** check permissions and handle the workflow. `Operations.Book` checks the stylist and service, calculates the end time, checks for overlapping bookings and saves the appointment.
- **Models** contain the signed-in user's `Session`. Database rows are loaded into ADO.NET `DataTable` objects for display in the grids.
- **Data** opens the MySQL connection and runs parameterized commands. An `ExecuteReader` loads rows for a grid. An `ExecuteNonQuery` saves or changes rows. Related writes use transactions so they commit together.

The two course references informed the use of XAMPP, MySqlConnector, ADO.NET commands and CRUD through Windows Forms. The SalonFlow SRS supplied the business workflows and user roles.

## 6. Backup and troubleshooting

- **Database connection fails** — Check that XAMPP MySQL is running and that `Database.config` has the right port and credentials. If `salonflow_db` is missing, run the setup script in phpMyAdmin.
- **phpMyAdmin does not open** — Start Apache and check its HTTP port. For Apache on port 8080, open `http://localhost:8080/phpmyadmin/`.
- **Windows cannot print a PDF** — Check that **Microsoft Print to PDF** is available in Windows before opening the print preview.
- **Create an SQL backup** — With XAMPP MySQL running, right-click `Database/Backup-SalonFlow.ps1` and run it with PowerShell or run it from PowerShell using `& ".\Database\Backup-SalonFlow.ps1"` from the solution folder. It defaults to `C:\xampp`, port 3306 and local root with a blank password. Use `-Port 3307` or `-XamppPath "D:\xampp"` if needed. For password-protected installations, provide `-OptionsFile` pointing to a private MySQL client option file with a `[client]` section containing user and password. The script saves backups under `%LOCALAPPDATA%\SalonFlow\Backups` and keeps at least 30 days. To run daily, use Windows Task Scheduler with program `powershell.exe` and argument `-NoProfile -File "C:\path\to\SalonFlow\Database\Backup-SalonFlow.ps1"`. Verify the first scheduled backup while MySQL is running.

## 7. Desktop scope compared with the SRS

This is a local classroom implementation of the principal workflows. It covers the modules listed above. The SRS also describes a customer web portal, SMS/email and payment-provider integrations, and additional business rules that require more implementation. The desktop app records externally confirmed mobile and card payments manually. It supports branch records and branch-based bills and expenses, with shared stock and service prices. Appointment overlap is checked per stylist, with appointment lists in place of a visual calendar and availability search. Paid appointment commissions use the booked service price and the current stylist rate.

Remaining SRS work includes password recovery, branch switching and per-branch prices and stock, stylist shifts and leave, attendance, service packages and supplies usage, recurring appointments and expenses, deposits, automated no-show and reminder processing, duplicate customer merging, queue estimates, supplier and purchasing flows, cash shifts, tipping, paid-bill refunds, item-level discounts, loyalty redemption, vouchers, customer ratings, additional reports and CSV business export. Daily backups require the Windows schedule above. The web targets for responsiveness, HTTPS, scale and availability have no measured acceptance result for this desktop project.

This edition explicitly registers all 17 forms in the Visual Studio project. Each form contains its main .cs file, its .Designer.cs layout, and its .resx resource file. The package was checked for archive integrity, project wiring and demo password consistency. It still needs its first build and interactive checkout on Windows with Visual Studio and XAMPP.
