use Vaibhav;

create table FitnessCentre(ID int identity(1,1), FullName varchar(100) NOT NULL, EmailAddress varchar(100) NOT NULL, MobileNumber varchar(100) NOT NULL, Statee varchar(100) NOT NULL, City varchar(100) NOT NULL, Gender varchar(100) NOT NULL, isDelete bit default 0);

insert into FitnessCentre values ('Vaibhav Khandekar','vaibhav.gmail.com','1234569870','maharashtra','mumbai','male',0),('Vaibhavi Khandekar','vaibhavi.gmail.com','9870456123','maharashtra','pune','female',0),
('Vaibhav Coolkarni','vaibhau.gmail.com','4569870123','goa','kolva','male',0),('Preeti Yadav','vaibhavi.gmail.com','9876123951','bihar','patna','female',0);

select * from FitnessCentre;

drop table FitnessCentre;
