--
-- PostgreSQL database cluster dump
--

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Drop databases (except postgres and template1)
--

DROP DATABASE testtoo;




--
-- Drop roles
--

DROP ROLE postgres;


--
-- Roles
--

CREATE ROLE postgres;
ALTER ROLE postgres WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION BYPASSRLS PASSWORD 'SCRAM-SHA-256$4096:FMzsQCPpHJOs1usbkGDB/A==$9FO3W2z9PdO+bBIG9hQmDc6WAsK8MrOOsG4tVi2UUsc=:BfRSD7hW4qvJK7x+77WgPN+DevpcjAl7ERrFFqOzXfk=';

--
-- User Configurations
--








--
-- Databases
--

--
-- Database "template1" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2 (Debian 16.2-1.pgdg120+2)
-- Dumped by pg_dump version 16.2 (Debian 16.2-1.pgdg120+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

UPDATE pg_catalog.pg_database SET datistemplate = false WHERE datname = 'template1';
DROP DATABASE template1;
--
-- Name: template1; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE template1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE template1 OWNER TO postgres;

\connect template1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE template1; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE template1 IS 'default template for new databases';


--
-- Name: template1; Type: DATABASE PROPERTIES; Schema: -; Owner: postgres
--

ALTER DATABASE template1 IS_TEMPLATE = true;


\connect template1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE template1; Type: ACL; Schema: -; Owner: postgres
--

REVOKE CONNECT,TEMPORARY ON DATABASE template1 FROM PUBLIC;
GRANT CONNECT ON DATABASE template1 TO PUBLIC;


--
-- PostgreSQL database dump complete
--

--
-- Database "postgres" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2 (Debian 16.2-1.pgdg120+2)
-- Dumped by pg_dump version 16.2 (Debian 16.2-1.pgdg120+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE postgres;
--
-- Name: postgres; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE postgres OWNER TO postgres;

\connect postgres

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- PostgreSQL database dump complete
--

--
-- Database "testtoo" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2 (Debian 16.2-1.pgdg120+2)
-- Dumped by pg_dump version 16.2 (Debian 16.2-1.pgdg120+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: testtoo; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE testtoo WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE testtoo OWNER TO postgres;

\connect testtoo

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: AspNetRoleClaims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" uuid NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetRoleClaims" OWNER TO postgres;

--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: AspNetRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoles" (
    "Id" uuid NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);


ALTER TABLE public."AspNetRoles" OWNER TO postgres;

--
-- Name: AspNetUserClaims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" uuid NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetUserClaims" OWNER TO postgres;

--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: AspNetUserLogins; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."AspNetUserLogins" OWNER TO postgres;

--
-- Name: AspNetUserRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserRoles" (
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO postgres;

--
-- Name: AspNetUserTokens; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserTokens" (
    "UserId" uuid NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);


ALTER TABLE public."AspNetUserTokens" OWNER TO postgres;

--
-- Name: AspNetUsers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUsers" (
    "Id" uuid NOT NULL,
    "AgreesToTerms" boolean NOT NULL,
    "Name" text,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);


ALTER TABLE public."AspNetUsers" OWNER TO postgres;

--
-- Name: RefreshTokens; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshTokens" (
    "Id" uuid NOT NULL,
    "AppUserId" uuid NOT NULL,
    "RefreshToken" character varying(64) NOT NULL,
    "ExpirationDt" timestamp with time zone NOT NULL,
    "PreviousRefreshToken" character varying(64),
    "PreviousExpirationDt" timestamp with time zone NOT NULL
);


ALTER TABLE public."RefreshTokens" OWNER TO postgres;

--
-- Name: Sectors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sectors" (
    "Id" uuid NOT NULL,
    "Description" text NOT NULL,
    "SuperSectorId" uuid
);


ALTER TABLE public."Sectors" OWNER TO postgres;

--
-- Name: UserInSectors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserInSectors" (
    "Id" uuid NOT NULL,
    "SectorWithSuperSectorsName" text,
    "AppUserId" uuid NOT NULL,
    "SectorId" uuid NOT NULL
);


ALTER TABLE public."UserInSectors" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
19a06506-fab9-4da8-8d56-189e3cd79494	Admin	ADMIN	\N
\.


--
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
\.


--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
7fa9ff7f-f3ad-4276-b274-f4ae89810a45	19a06506-fab9-4da8-8d56-189e3cd79494
\.


--
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
\.


--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "AgreesToTerms", "Name", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
8555637f-2838-4e10-9f8c-21785f4c780c	t	Peeter	eesti@eesti.ee	EESTI@EESTI.EE	eesti@eesti.ee	EESTI@EESTI.EE	f	AQAAAAIAAYagAAAAEF4zydfRbFQsPKq+rWHm/NnTnRZllBsB7zJHgxC0hDexGoJ8pSvrRMdGOWP3tZ3Sog==	XP3LT72WX76GMGKJAFOKB63ZPLZZIZ5S	0c0c18c0-2f2d-45f8-90b3-41825bdfcef2	\N	f	f	\N	t	0
7fa9ff7f-f3ad-4276-b274-f4ae89810a45	t	Magnar Markvart	admin@admin.ee	ADMIN@ADMIN.EE	admin@admin.ee	ADMIN@ADMIN.EE	f	AQAAAAIAAYagAAAAEM3r0hX/cmsVw+Ab3m2YLRsbxv2kE7KHXoUUKpsxkLo1F0xw1YkOK9kvYTKX5KCJqg==	TJNU4WVOU3MD4KPCMCKEYOFTAB3HCN4S	7510a09c-8665-4e52-9e5d-fadd3f528882	\N	f	f	\N	t	0
\.


--
-- Data for Name: RefreshTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshTokens" ("Id", "AppUserId", "RefreshToken", "ExpirationDt", "PreviousRefreshToken", "PreviousExpirationDt") FROM stdin;
\.


--
-- Data for Name: Sectors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sectors" ("Id", "Description", "SuperSectorId") FROM stdin;
32fc0433-e12f-4017-9b23-927c910fb1f6	Manufacturing	\N
a0b37c00-72bd-4522-a5d5-f0902a66d6a8	Service	\N
acee74c3-cdd4-4c18-93c8-2a485d61d52e	Other	\N
046157a9-a497-420c-b8f1-1234b4bea756	Food and Beverage	32fc0433-e12f-4017-9b23-927c910fb1f6
0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9	Wood	32fc0433-e12f-4017-9b23-927c910fb1f6
0d1709d0-3df8-4462-8770-1da6694a1bc9	Construction Materials	32fc0433-e12f-4017-9b23-927c910fb1f6
11c4d645-baeb-4033-a965-4d39915aea87	Plastic and Rubber	32fc0433-e12f-4017-9b23-927c910fb1f6
170355ac-0996-42cf-a1e5-d3992c187186	Metalworking	32fc0433-e12f-4017-9b23-927c910fb1f6
28caca3c-a99b-4bb9-b19b-11d6e3b07b70	Transport and Logistics	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
3b5a581a-399b-43e5-9cd3-113b9f394c06	Energy technology	acee74c3-cdd4-4c18-93c8-2a485d61d52e
3d78fecc-e4bc-4110-a82c-d6309a818613	Electronics and Optics	32fc0433-e12f-4017-9b23-927c910fb1f6
3ee0c8fc-e5e9-412c-b83a-67de4101153e	Tourism	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
4783bc42-20f7-4218-a346-cb067668cdf5	Printing	32fc0433-e12f-4017-9b23-927c910fb1f6
4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3	Information Technology and Telecommunications	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
4ec419ae-9eeb-49d4-9b6d-383e561e95d0	Business services	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
564886b1-1c65-48fb-99da-bbd047e43e77	Translation services	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
646b7716-9852-45db-ad7c-da6e6772b3bb	Textile and Clothing	32fc0433-e12f-4017-9b23-927c910fb1f6
817dc386-beaf-4b3b-9bb2-4b98c6a32649	Environment	acee74c3-cdd4-4c18-93c8-2a485d61d52e
82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c	Furniture	32fc0433-e12f-4017-9b23-927c910fb1f6
99b24a88-e6f5-43ff-9e23-b5c0e54fc49a	Creative industries	acee74c3-cdd4-4c18-93c8-2a485d61d52e
b6ff692e-c9f8-40b8-8cf6-85ae6991b387	Engineering	a0b37c00-72bd-4522-a5d5-f0902a66d6a8
eae7965e-5ace-44d0-9b94-af116aa356eb	Machinery	32fc0433-e12f-4017-9b23-927c910fb1f6
01f0db6b-5b72-49d9-97c7-101a25e8be27	Telecommunications	4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3
08f64162-a545-4c92-a886-ec7df6713cb8	Machinery components	eae7965e-5ace-44d0-9b94-af116aa356eb
08f9c602-4a72-4b9a-9123-d05dca9570c6	Maritime	eae7965e-5ace-44d0-9b94-af116aa356eb
0c447d9b-3608-4494-86f4-496d74c95815	Rail	28caca3c-a99b-4bb9-b19b-11d6e3b07b70
1246ce33-8daf-4a43-ba2f-267c8edbb743	Bedroom	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
13c56f1c-ccf7-40aa-9c22-67abfbf97b13	Meat &amp; meat products	046157a9-a497-420c-b8f1-1234b4bea756
19b854ef-dd95-4bca-adef-b8da58d537ed	Plastic profiles	11c4d645-baeb-4033-a965-4d39915aea87
19f2d59d-c083-40e1-a09c-6ac38fc42145	Labelling and packaging printing	4783bc42-20f7-4218-a346-cb067668cdf5
1b4dcf27-e168-4ead-9e9c-17f71e8b33e9	Clothing	646b7716-9852-45db-ad7c-da6e6772b3bb
1b5b36a4-214a-482c-b9f1-01f6c6152979	Metal works	170355ac-0996-42cf-a1e5-d3992c187186
1dc14ced-651b-4944-a786-a52424e15a0d	Other	eae7965e-5ace-44d0-9b94-af116aa356eb
2ded67d1-457c-4bd8-8ce8-0080511144c4	Wooden building materials	0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9
3075fb1c-339f-4666-943c-c4d5f10812fb	Construction of metal structures	170355ac-0996-42cf-a1e5-d3992c187186
33a143c7-ca06-42b1-a4b9-75bfab987860	Houses and buildings	170355ac-0996-42cf-a1e5-d3992c187186
37093024-3be1-4be2-8c54-9f921922d90e	Data processing, Web portals, E-marketing	4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3
371a408f-7812-435f-b80a-d3ffb7e301a9	Metal structures	eae7965e-5ace-44d0-9b94-af116aa356eb
372b1d41-619b-4a6e-9d04-f76be8cee6e3	Programming, Consultancy	4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3
408cacab-4d25-4b48-b2dc-971293f78821	Project furniture	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
4485157b-40c4-405d-8d98-a5367b98f74d	Wooden houses	0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9
4b12e7cc-f507-475a-b198-45646f2dc4d2	Bakery &amp; confectionery products	046157a9-a497-420c-b8f1-1234b4bea756
5116d5b8-dd3c-4b6f-baf6-b8a53a3d30f3	Water	28caca3c-a99b-4bb9-b19b-11d6e3b07b70
589bf163-9180-43f0-9cf8-165c5cb2149d	Software, Hardware	4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3
5da3c473-79b4-4bb5-adca-7fa96bd0ab53	Bathroom/sauna	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
77f6ce62-8a5e-44f6-a623-354393d71ea9	Kitchen	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
84fb9773-cf97-4242-97a4-b8bc4244aa02	Textile	646b7716-9852-45db-ad7c-da6e6772b3bb
853c0ac3-2dda-4081-9c49-f9125d975889	Other	046157a9-a497-420c-b8f1-1234b4bea756
86a44339-0353-4950-8666-f56795cd2fbe	Fish &amp; fish products	046157a9-a497-420c-b8f1-1234b4bea756
880b1b11-7a44-4636-87f5-f60b4ca720da	Outdoor	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
9f5941a1-a4ef-4e31-9114-b6333e6e8d44	Plastic goods	11c4d645-baeb-4033-a965-4d39915aea87
a158fdbc-2148-4d6f-856d-7479dd9f31fb	Packaging	11c4d645-baeb-4033-a965-4d39915aea87
a868e04a-6d35-4eb3-8f81-539dfa5aedd8	Beverages	046157a9-a497-420c-b8f1-1234b4bea756
a8e94d75-f5e9-41b1-96f1-eb56551067c3	Office	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
a9b73b0c-0ea3-4792-8522-a741463888b6	Milk &amp; dairy products	046157a9-a497-420c-b8f1-1234b4bea756
ae70e815-feba-43fc-a63c-ca8770c8cf34	Sweets &amp; snack food	046157a9-a497-420c-b8f1-1234b4bea756
c662db43-fe38-47a9-99d5-80f02f2c6eef	Other	0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9
c6c2030d-27af-478b-aeb3-2d87ec872f81	Book/Periodicals printing	4783bc42-20f7-4218-a346-cb067668cdf5
d279196b-fb78-4f6b-927a-f10e32714fc0	Advertising	4783bc42-20f7-4218-a346-cb067668cdf5
d54417b1-dec1-4405-b14a-c1d350e1c750	Air	28caca3c-a99b-4bb9-b19b-11d6e3b07b70
e3a9da1a-9925-4022-ae32-af03f2f217ad	Plastic processing technology	11c4d645-baeb-4033-a965-4d39915aea87
e74d5e79-ea61-45c3-a35e-069fc262afa6	Repair and maintenance service	eae7965e-5ace-44d0-9b94-af116aa356eb
e8d4e310-7b24-41f6-816c-37ce78c727c3	Living room	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
ee504569-4666-4cd9-85a0-a2c9cd0d4e83	Metal products	170355ac-0996-42cf-a1e5-d3992c187186
ee9c0b26-1e9c-4127-8e73-204eb68527c3	Children’s room	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
ef179370-a0ba-413f-b810-d68f0a793446	Other (Furniture)	82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c
f7692977-8c0f-49e2-bf12-0e5cc00c555f	Road	28caca3c-a99b-4bb9-b19b-11d6e3b07b70
f80ad83c-fc72-4073-bb2e-87facabbbfec	Machinery equipment/tools	eae7965e-5ace-44d0-9b94-af116aa356eb
f9349e44-58aa-4976-b0d3-13d342a56733	Manufacture of machinery	eae7965e-5ace-44d0-9b94-af116aa356eb
29692620-cc6b-407c-a27d-ba918c598621	Blowing	e3a9da1a-9925-4022-ae32-af03f2f217ad
31956b83-31e5-47a8-aa27-1817c7ff57ab	Boat/Yacht building	08f9c602-4a72-4b9a-9123-d05dca9570c6
4beb5253-ce43-41cc-ba03-8cbd59ae6b16	Ship repair and conversion	08f9c602-4a72-4b9a-9123-d05dca9570c6
4fc45347-e65b-44ca-b63b-90a5d29737ab	CNC-machining	1b5b36a4-214a-482c-b9f1-01f6c6152979
5b25ef14-4b9d-4706-8ed1-cc7d115984ed	Gas, Plasma, Laser cutting	1b5b36a4-214a-482c-b9f1-01f6c6152979
708a8638-35c2-4b7f-80dc-cfeefeb90d08	Forgings, Fasteners	1b5b36a4-214a-482c-b9f1-01f6c6152979
9732f4cb-8fb4-4e9d-9b5c-8fdb42090ea5	Aluminium and steel workboats	08f9c602-4a72-4b9a-9123-d05dca9570c6
a98d02ea-beaa-41f6-a01c-d48d27a94b2c	MIG, TIG, Aluminum welding	1b5b36a4-214a-482c-b9f1-01f6c6152979
e9c07801-4440-4a8b-9de7-9d3010b0d6d3	Moulding	e3a9da1a-9925-4022-ae32-af03f2f217ad
fdb9e91a-9120-439f-a6a1-ff9356949420	Plastics welding and processing	e3a9da1a-9925-4022-ae32-af03f2f217ad
\.


--
-- Data for Name: UserInSectors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserInSectors" ("Id", "SectorWithSuperSectorsName", "AppUserId", "SectorId") FROM stdin;
195b2489-7669-4d11-bb7b-07be823d9521	(Manufacturing) --> Construction Materials	8555637f-2838-4e10-9f8c-21785f4c780c	0d1709d0-3df8-4462-8770-1da6694a1bc9
03c90b77-cd08-4a8f-8522-90d85e34e582	(Manufacturing) --> Construction Materials	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	0d1709d0-3df8-4462-8770-1da6694a1bc9
1653e573-81d6-4306-affc-d291fda07f46	(Service) --> (Information Technology and Telecommunications) --> Programming, Consultancy	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	372b1d41-619b-4a6e-9d04-f76be8cee6e3
34e9d5a4-2fd7-403c-89e1-b2f63d9de486	(Manufacturing) --> (Machinery) --> Repair and maintenance service	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	e74d5e79-ea61-45c3-a35e-069fc262afa6
50c52c85-30e0-45d0-a573-5de3db817d88	(Service) --> (Information Technology and Telecommunications) --> Data processing, Web portals, E-marketing	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	37093024-3be1-4be2-8c54-9f921922d90e
82d4dc0e-bb4c-4501-b7ec-d32448df1a03	(Manufacturing) --> (Food and Beverage) --> Milk &amp; dairy products	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	a9b73b0c-0ea3-4792-8522-a741463888b6
90f280f6-a3e0-4ecb-9c2c-331a134c3897	(Service) --> Business services	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	4ec419ae-9eeb-49d4-9b6d-383e561e95d0
b47000f5-27eb-41db-a462-e3edbb74f003	(Manufacturing) --> Electronics and Optics	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	3d78fecc-e4bc-4110-a82c-d6309a818613
c791248a-64ed-4981-855f-949ce03d6c30	(Manufacturing) --> (Food and Beverage) --> Sweets &amp; snack food	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	ae70e815-feba-43fc-a63c-ca8770c8cf34
ed02eb68-1271-43a5-8c74-ab5738dd897b	(Service) --> (Information Technology and Telecommunications) --> Software, Hardware	7fa9ff7f-f3ad-4276-b274-f4ae89810a45	589bf163-9180-43f0-9cf8-165c5cb2149d
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240514200948_Initial	8.0.4
\.


--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


--
-- Name: AspNetRoleClaims PK_AspNetRoleClaims; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");


--
-- Name: AspNetRoles PK_AspNetRoles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");


--
-- Name: AspNetUserClaims PK_AspNetUserClaims; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");


--
-- Name: AspNetUserLogins PK_AspNetUserLogins; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");


--
-- Name: AspNetUserRoles PK_AspNetUserRoles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");


--
-- Name: AspNetUserTokens PK_AspNetUserTokens; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");


--
-- Name: AspNetUsers PK_AspNetUsers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");


--
-- Name: RefreshTokens PK_RefreshTokens; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokens"
    ADD CONSTRAINT "PK_RefreshTokens" PRIMARY KEY ("Id");


--
-- Name: Sectors PK_Sectors; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sectors"
    ADD CONSTRAINT "PK_Sectors" PRIMARY KEY ("Id");


--
-- Name: UserInSectors PK_UserInSectors; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserInSectors"
    ADD CONSTRAINT "PK_UserInSectors" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: EmailIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");


--
-- Name: IX_AspNetRoleClaims_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");


--
-- Name: IX_AspNetUserClaims_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");


--
-- Name: IX_AspNetUserLogins_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");


--
-- Name: IX_AspNetUserRoles_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");


--
-- Name: IX_RefreshTokens_AppUserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_RefreshTokens_AppUserId" ON public."RefreshTokens" USING btree ("AppUserId");


--
-- Name: IX_Sectors_SuperSectorId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sectors_SuperSectorId" ON public."Sectors" USING btree ("SuperSectorId");


--
-- Name: IX_UserInSectors_AppUserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserInSectors_AppUserId" ON public."UserInSectors" USING btree ("AppUserId");


--
-- Name: IX_UserInSectors_SectorId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserInSectors_SectorId" ON public."UserInSectors" USING btree ("SectorId");


--
-- Name: RoleNameIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");


--
-- Name: UserNameIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");


--
-- Name: AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: RefreshTokens FK_RefreshTokens_AspNetUsers_AppUserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokens"
    ADD CONSTRAINT "FK_RefreshTokens_AspNetUsers_AppUserId" FOREIGN KEY ("AppUserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: Sectors FK_Sectors_Sectors_SuperSectorId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sectors"
    ADD CONSTRAINT "FK_Sectors_Sectors_SuperSectorId" FOREIGN KEY ("SuperSectorId") REFERENCES public."Sectors"("Id");


--
-- Name: UserInSectors FK_UserInSectors_AspNetUsers_AppUserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserInSectors"
    ADD CONSTRAINT "FK_UserInSectors_AspNetUsers_AppUserId" FOREIGN KEY ("AppUserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: UserInSectors FK_UserInSectors_Sectors_SectorId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserInSectors"
    ADD CONSTRAINT "FK_UserInSectors_Sectors_SectorId" FOREIGN KEY ("SectorId") REFERENCES public."Sectors"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

--
-- PostgreSQL database cluster dump complete
--

