UPDATE OWSVersion
SET OWSDBVersion='20241027'
WHERE OWSDBVersion IS NOT NULL;

SELECT OWSDBVersion
FROM OWSVersion;

ALTER TABLE Users
ADD COLUMN username varchar(20);

CREATE OR REPLACE FUNCTION public.adduser(_customerguid uuid, _firstname character varying, _lastname character varying, _email character varying, _password character varying, _role character varying)
 RETURNS TABLE(userguid uuid)
 LANGUAGE plpgsql
AS $function$
DECLARE
    _PasswordHash VARCHAR(128);
    _UserGUID     UUID;
BEGIN
    CREATE TEMP TABLE IF NOT EXISTS temp_table
    (
        UserGUID UUID
    ) ON COMMIT DROP;

    _PasswordHash = crypt(_Password, gen_salt('md5'));
    _UserGUID := gen_random_uuid();
    INSERT INTO temp_table (UserGUID) VALUES (_UserGUID);

    INSERT INTO Users (UserGUID, CustomerGUID, FirstName, LastName, Email, PasswordHash, CreateDate, LastAccess,
                       ROLE, Username)
    VALUES (_UserGUID, _CustomerGUID, _FirstName, _LastName, _Email, _PasswordHash, NOW(), NOW(), _Role, _Username);
    RETURN QUERY SELECT *
                 FROM temp_table;
END
$function$

DROP FUNCTION public.adduser(uuid, character varying, character varying, character varying, character varying, character varying)