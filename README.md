# Money manager application
![.NET](https://img.shields.io/badge/.NET%20FrameWork-4.6-informational)
![NLog](https://img.shields.io/badge/NLog-4.7.9-red)
![OxyPlot](https://img.shields.io/badge/OxyPlot-2.1.0-brightgreen)
## Description
An application project to calculate your budget. 
### Categories
Adding categories and items of expenses / income is called using the context menu by clicking the right mouse button.
### Table
The entry takes place in the table, which highlights expenses in `red` and incomes in `green`.
You can make edits yourself, delete lines. Any update of the table is accompanied by a daily update of 'statistics'.
### Capabilities
* Changing the date and entering data into the table for a specific date
* View charts reflecting the percentage of spending
  * View charts for any day you want
  * Collection of statistics for 7/30/365 days or for all time
* Sorting data in a table
* Fast work, loading, saving and updating occurring in a split second
  * If there are no folders to save, they will be automatically created
* The application uses the **OxyPlot** package to draw diagrams in statistics
## Logs
The application uses the **NLog** package to write logs to the `logs` folder in the main application directory. 
If you want to use them in your works, then set to always `copy the source file` in the build parameters for the `NLog.confifg`.
After five days, logs are automatically deleted
### Download
You can download the archive with the attachment at the link [MoneyManager](https://disk.yandex.ru/d/PV0Yod2mB-3rWA)
