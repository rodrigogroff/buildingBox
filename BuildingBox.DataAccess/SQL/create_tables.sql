
DROP TABLE public."User";

CREATE TABLE public."User"
(
    id bigserial NOT NULL,
    "stClientName" character varying(99),
	"fkClientType" bigint,
	"fkCountry" bigint,
	"stCityName" bigint,
	"fkDesiredGMT" bigint,
	"stPassword" character varying(99),
	"stContactEmail" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."User"
    OWNER to postgres;

