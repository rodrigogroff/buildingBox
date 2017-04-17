
DROP TABLE public."User";
DROP TABLE public."Ticket";
DROP TABLE public."TicketMessage";
DROP TABLE public."TicketWorkFlow";
DROP TABLE public."UserContract";




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
	
CREATE TABLE public."Ticket"
(
    id bigserial NOT NULL,
	"dtCreation" timestamp without time zone,
	"dtLog" timestamp without time zone,
	"fkUserOpen" bigint,
	"fkTicketState" bigint,
	"stProtocol" character varying(9),
	"stTitle" character varying(200),
	"stDescription" character varying(2000),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Ticket"
    OWNER to postgres;

CREATE TABLE public."TicketMessage"
(
    id bigserial NOT NULL,
	"fkTicket" bigint,
	"fkUser" bigint,
	"dtLog" timestamp without time zone,	
	"stMessage" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."TicketMessage"
    OWNER to postgres;

CREATE TABLE public."TicketWorkFlow"
(
    id bigserial NOT NULL,
	"fkTicket" bigint,
	"fkOldState" bigint,
	"fkNewState" bigint,
	"fkUser" bigint,
	"dtLog" timestamp without time zone,	
	"stMessage" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."TicketWorkFlow"
    OWNER to postgres;


CREATE TABLE public."UserContract"
(
    id bigserial NOT NULL,
	"dtCreation" timestamp without time zone,	
	"fkUser" bigint,
	"fkContractType" bigint,
	"fkGMT" bigint,
	"fkContinent" bigint,
	"fkCountry" bigint,
	"fkCity" bigint,
	"stDNS" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserContract"
    OWNER to postgres;
