alter table Assistant
add SH_ID int not null

alter table Assistant
add constraint FK_SH_Id
foreign key (SH_Id) references SuperHero(SH_Id);

