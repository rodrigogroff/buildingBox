﻿DROP TABLE public."User";
DROP TABLE public."Ticket";
DROP TABLE public."TicketMessage";
DROP TABLE public."TicketWorkFlow";
DROP TABLE public."UserContract";
DROP TABLE public."UserContractState";
DROP TABLE public."UserCustomization";
DROP TABLE public."UserCustomizationStateChange";
DROP TABLE public."UserCustomizationEstimateLog";
DROP TABLE public."UserMeeting";
DROP TABLE public."UserMeetingPerson";
DROP TABLE public."UserMeetingSchedule";
DROP TABLE public."UserContractBill";
DROP TABLE public."BillDetail";

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
	"fkContract" bigint,
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
	"fkContractState" bigint,
	"dtCreation" timestamp without time zone,	
	"stProtocol" character varying(20),
	"stDNS" character varying(200),
	"fkUser" bigint,
	"fkContractType" bigint,
	"fkGMT" bigint,
	"fkContinent" bigint,
	"fkCountry" bigint,
	"fkCity" bigint,
	"nuBillingDay" bigint,
	"nuContractValue" bigint,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserContract"
    OWNER to postgres;

CREATE TABLE public."UserContractState"
(
    id bigserial NOT NULL,
	"dtLog" timestamp without time zone,	
	"fkUser" bigint,
	"fkContract" bigint,
	"fkContractState" bigint,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserContractState"
    OWNER to postgres;

CREATE TABLE public."UserCustomization"
(
    id bigserial NOT NULL,
	"dtCreation" timestamp without time zone,	
	"dtUpdate" timestamp without time zone,	
	"fkUser" bigint,
	"fkContract" bigint,
	"fkCustomizationState" bigint,
	"stProtocol" character varying(20),
	"stVersion" character varying(20),
	"stObjective" character varying(200),
	"nuEstimateHours" bigint,
	"nuEstimateMinutes" bigint,
	"bEstimativeApproval" boolean,
	"dtEstimativeApproval" timestamp without time zone,	
	"bFinalApproval" boolean,
	"dtFinalApproval" timestamp without time zone,	
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserCustomization"
    OWNER to postgres;

CREATE TABLE public."UserCustomizationStateChange"
(
    id bigserial NOT NULL,
	"dtLog" timestamp without time zone,
	"fkUser" bigint,
	"fkCustomization" bigint,
	"fkState" bigint,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserCustomizationStateChange"
    OWNER to postgres;

CREATE TABLE public."UserCustomizationEstimateLog"
(
    id bigserial NOT NULL,
	"dtLog" timestamp without time zone,
	"fkCustomization" bigint,
	"fkUser" bigint,
	"nuHours" bigint,
	"nuMinutes" bigint,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserCustomizationEstimateLog"
    OWNER to postgres;
	
CREATE TABLE public."UserMeeting"
(
    id bigserial NOT NULL,
	"fkUser" bigint,
	"nuDay" bigint,
	"fkMonth" bigint,
	"nuYear" bigint,
	"nuHour" bigint,
	"nuMinute" bigint,
	"fkGMT" bigint,
	"fkMeetingState" bigint,
	"fkMeetingPlace" bigint,
	"stMeetingMotivation" character varying(999),
	"stMeetingDetails" character varying(999),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserMeeting"
    OWNER to postgres;

CREATE TABLE public."UserMeetingPerson"
(
    id bigserial NOT NULL,
	"fkMeeting" bigint,
	"stName" character varying(999),
	"stRole" character varying(999),
	"bConfirmed" boolean,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserMeetingPerson"
    OWNER to postgres;

CREATE TABLE public."UserMeetingSchedule"
(
    id bigserial NOT NULL,
	"fkMeeting" bigint,
	"fkUser" bigint,
	"fkState" bigint,
	"dtLog" timestamp without time zone,
	"stDate" character varying(200),
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserMeetingSchedule"
    OWNER to postgres;

CREATE TABLE public."UserContractBill"
(
    id bigserial NOT NULL,
	"dtLog" timestamp without time zone,
	"dtPayment" timestamp without time zone,
	"fkUser" bigint,
	"fkUserContract" bigint,
	"nuYear" bigint,
	"nuMonth" bigint,
	"bPending" boolean,
	"bCancelled" boolean,
	"stBillId" character varying(12),	
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserContractBill"
    OWNER to postgres;

CREATE TABLE public."BillDetail"
(
    id bigserial NOT NULL,
	"fkUserContractBill" bigint,
	"stItem" character varying(99),	
	"nuValue" bigint,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."BillDetail"
    OWNER to postgres;
	
