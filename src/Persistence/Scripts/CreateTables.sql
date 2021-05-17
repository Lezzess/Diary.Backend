begin transaction;

create table [dbo].[database_information] (
    [database_version] smallint not null
);
insert into [dbo].[database_information] ([database_version]) values (0);

create table [dbo].[diary_entries] (
    [id] uniqueidentifier not null primary key clustered,
    [title] nvarchar(100) not null,
    [description] nvarchar(100) not null
);

commit;