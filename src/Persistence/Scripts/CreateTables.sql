begin transaction;

create table [dbo].[database_information] (
    [database_version] smallint not null
);
insert into [dbo].[database_information] ([database_version]) values (0);

create table [dbo].[diaries] (
    [id] uniqueidentifier not null primary key clustered,
    [title] nvarchar(300) not null,
    [description] nvarchar(max) not null
);

commit;