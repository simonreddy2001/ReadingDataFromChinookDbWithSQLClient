use SuperHeroesDb;
Go

drop table if exists SuperHero;
drop table if exists Assistant;
drop table if exists Power;
Go

create table Superhero(
	SH_Id int primary key identity(1,1) not null,
	SH_Name nvarchar(50) not null, 
	SH_Alias nvarchar(25),
	SH_Origin nvarchar(50)
);

create table Assistant(
	A_Id int primary key identity (1,1) not null,
	A_Name nvarchar(50) not null
);

create table Power(
	P_Id int primary key identity(1,1) not null,
	P_Name nvarchar(50) not null, 
	P_Description nvarchar(100)
);

