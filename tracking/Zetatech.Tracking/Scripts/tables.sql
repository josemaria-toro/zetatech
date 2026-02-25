-- ====================================================================
-- Tables
-- ====================================================================

CREATE TABLE tracking.t_tracking_api_keys
(
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_bln_enabled" boolean NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_str_name" character varying (256) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_api_keys PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_api_keys OWNER to postgres;

CREATE TABLE tracking.t_tracking_dependencies
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_str_data_input" character varying (4096),
    "c_str_data_output" character varying (4096),
    "c_dbl_duration" double precision NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_bln_success" boolean NOT NULL,
    "c_str_target" character varying (256) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_str_type" character varying (32) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_dependencies PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_dependencies OWNER to postgres;

CREATE TABLE tracking.t_tracking_errors
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_str_message" character varying (1024) NOT NULL,
    "c_jsn_metadata" json,
    "c_str_source" character varying (256) NOT NULL,
    "c_str_stack_trace" character varying (4096) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_str_type" character varying (256) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_errors PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_errors OWNER to postgres;

CREATE TABLE tracking.t_tracking_events
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_events PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_events OWNER to postgres;

CREATE TABLE tracking.t_tracking_metrics
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_str_dimension" character varying (256) NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    "c_dbl_value" double precision NOT NULL,
    CONSTRAINT pk_t_tracking_metrics PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_metrics OWNER to postgres;

CREATE TABLE tracking.t_tracking_page_views
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_str_device" character varying (256) NOT NULL,
    "c_dbl_duration" double precision NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_str_ip_address" character varying (15) NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    "c_str_url" character varying (1024),
    "c_str_user_agent" character varying (1024),
    CONSTRAINT pk_t_tracking_page_views PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_page_views OWNER to postgres;

CREATE TABLE tracking.t_tracking_requests
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_str_body" character varying (8196),
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_dbl_duration" double precision NOT NULL,
    "c_str_endpoint" character varying (1024),
    "c_uid_id" uuid NOT NULL,
    "c_str_ip_address" character varying (15) NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_str_response" character varying (8196),
    "c_int_statuscode" integer,
    "c_bln_success" boolean NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_str_type" character varying (32) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_requests PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_requests OWNER to postgres;

CREATE TABLE tracking.t_tracking_tests
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_dbl_duration" double precision NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_str_message" character varying (1024) NOT NULL,
    "c_jsn_metadata" json,
    "c_str_name" character varying (256) NOT NULL,
    "c_bln_success" boolean NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_tests PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_tests OWNER to postgres;

CREATE TABLE tracking.t_tracking_traces
(
    "c_uid_api_key_id" uuid NOT NULL,
    "c_uid_correlation_id" uuid NOT NULL,
    "c_tsp_created_at" timestamp with time zone NOT NULL,
    "c_uid_id" uuid NOT NULL,
    "c_str_message" character varying (1024) NOT NULL,
    "c_jsn_metadata" json,
    "c_str_source" character varying (256) NOT NULL,
    "c_tsp_timestamp" timestamp with time zone NOT NULL,
    "c_str_tracker_ip_address" character varying (15) NOT NULL,
    "c_tsp_updated_at" timestamp with time zone NOT NULL,
    CONSTRAINT pk_t_tracking_traces PRIMARY KEY (c_uid_id)
) TABLESPACE pg_default;

ALTER TABLE tracking.t_tracking_traces OWNER to postgres;