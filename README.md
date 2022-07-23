# CodingTracker
Project 2 from The C# Academy: http://www.thecsharpacademy.com/coding-tracker/  

There is also a youtube video for this program:   
https://www.youtube.com/watch?v=tvrfIMiG3-s&list=PL4G0MUH8YWiBxCvNXnGea4hyRX__uVg6-&index=3  

This program is a very basic CRUD program that uses the console as the user interface.  There are a couple of packages (listed below) that help the programmer complete the program.  

## Packages used in this program
### Configuration Manager
System.Configureation.ConfigurationManager v6.0.0  

In the code exmaple below, ConnectionString becomes a variable for the sqlite database.  

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="ConnectionString" value="Data Source=db.sqlite" />
	</appSettings>
</configuration>
```

### Console Table Extension  
ConsoleTableExt v3.2.0 
The Console Table Extension will automatically format your data into a table in the console:  

```
---------- Coding ----------  
| Id | Date     | Duration |  
----------------------------  
| 1  | 07-14-22 | 03:00    |  
----------------------------  
| 2  | 07-13-22 | 04:00    |  
----------------------------  
| 4  | 07-01-22 | 00:12    |  
----------------------------  
```

### Sqlite DB  
Sqlite DB v6.0.7  
