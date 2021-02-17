create table if not exists "dbo"."Users" (
    "Uid" int unique not null,
    "Name" varchar(512) null,
    "AvatarUrl" text null,
    "ProfileUrl" text null,
    "TrackingEnabled" bool not null default false,
    primary key ("Uid")
);

create table if not exists "dbo"."ApiTokens" (
    "Token" varchar(512) unique not null,
    "Uid" int unique not null,
    primary key ("Token", "Uid")
);
