-- ====================================================================
-- Users
-- ====================================================================

CREATE ROLE u_tracking_ingestor WITH LOGIN PASSWORD '';
GRANT CONNECT ON DATABASE zetatech TO u_tracking_ingestor;
GRANT USAGE ON SCHEMA tracking TO u_tracking_ingestor;
GRANT SELECT ON tracking.t_tracking_api_keys TO u_tracking_ingestor;

CREATE ROLE u_tracking_processor WITH LOGIN PASSWORD '';
GRANT CONNECT ON DATABASE zetatech TO u_tracking_processor;
GRANT USAGE ON SCHEMA tracking TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_dependencies TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_errors TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_events TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_metrics TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_page_views TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_requests TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_tests TO u_tracking_processor;
GRANT SELECT, INSERT ON tracking.t_tracking_traces TO u_tracking_processor;