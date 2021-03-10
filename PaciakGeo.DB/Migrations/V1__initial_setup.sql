create table if not exists dbo.users
(
    uid                   integer               not null
        constraint users_pkey
            primary key,
    name                  varchar(512),
    avatar_url            text,
    tracking_enabled      boolean default false not null,
    location              text,
    last_updated_location date,
    location_longitude    double precision,
    location_latitude     double precision
);

alter table dbo.users
    owner to paciak_geo;
