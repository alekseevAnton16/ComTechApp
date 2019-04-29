use [ComTechDb]
go

create table Subdivisions
(
	SubdivisionId INT PRIMARY KEY IDENTITY (1, 1),
	SubdivisionName nvarchar(100) not null,
	Subdivision—reateYear DATETIME not null,
	Faculty int not null,
)

create table Lecturers
(
	LecturerId INT PRIMARY KEY IDENTITY (1, 1),
	Surname nvarchar(70) not null,
	FirstName nvarchar(70) not null,
	Patronymic nvarchar(70) null,
	Position nvarchar(70) not null,
	ScienceGrade nvarchar(100) null,
	Note nvarchar(70) null,
	WorkStartDate DATETIME not null,
	SubdivisionId int not null,
)