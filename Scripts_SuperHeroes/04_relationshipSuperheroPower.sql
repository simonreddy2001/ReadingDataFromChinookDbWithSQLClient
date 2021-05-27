create table SuperheroWithPower(
	SH_Id int not null foreign key references Superhero(SH_Id),
	P_Id int not null foreign key references Power(P_Id),
	constraint PK_SHP primary key (SH_Id, P_Id)
);

