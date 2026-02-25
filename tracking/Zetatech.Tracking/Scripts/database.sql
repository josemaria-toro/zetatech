-- ====================================================================
-- Database
-- ====================================================================

CREATE DATABASE zetatech WITH OWNER = postgres
                              TEMPLATE = template0
                              ENCODING = 'UTF8'
                              STRATEGY = 'wal_log'
                              LC_COLLATE = 'POSIX'
                              LC_CTYPE = 'POSIX'
                              LOCALE_PROVIDER = 'libc'
                              TABLESPACE = pg_default
                              CONNECTION LIMIT = -1
                              IS_TEMPLATE = False;