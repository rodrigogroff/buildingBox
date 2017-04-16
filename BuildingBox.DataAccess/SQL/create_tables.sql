﻿
DROP TABLE public."User";

CREATE TABLE public."User"
(
    id bigserial NOT NULL,
	"dtCreation" timestamp without time zone,
    "stClientName" character varying(99),
	"fkClientType" bigint,
	"fkCountry" bigint,
	"stCityName" character varying(200),
	"fkDesiredGMT" bigint,
	"stPassword" character varying(20),
	"stContactEmail" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."User"
    OWNER to postgres;

