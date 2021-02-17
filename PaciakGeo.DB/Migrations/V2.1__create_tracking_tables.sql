create table if not exists "dbo"."TrackingData" (
    "Uid" int unique not null,
    "Timestamp" timestamptz unique not null,
    "Latitude" float not null,
    "Longitude" float not null,
    "Alert" bool not null default false,
    primary key ("Uid")
);
