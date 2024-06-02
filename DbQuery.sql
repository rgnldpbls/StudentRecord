use StudentRecordDb
go 
create table Student
(
	studentId int identity (240000, 1) primary key,
	FName nvarchar(100) not null,
	MName nvarchar(100),
	LName nvarchar(100) not null,
	Lvl nvarchar(5) not null,
	Section nvarchar(5) not null
)
insert into Student values('John','Flores', 'Smith', '2nd', '1')
insert into Student values('Emily', 'Green', 'Johnson', '1st', '4')
insert into Student values('Liam', 'James', 'Brown', '3rd', '2N')
insert into Student values('Sophia', 'Sy', 'Lee', '1st', '2')